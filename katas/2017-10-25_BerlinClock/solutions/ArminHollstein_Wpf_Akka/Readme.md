# BerlinClock mit WPF und Akka.net

## Wozu dient dieses Repository?

Dieses Repository ist die für den Kennenlerntag am 12.12.2018 erbetene Aufgabenlösung.

## Motivation
* Warum BerlinClock? Spaß. Es flackert und ist bunt ;)  
* Warum WPF? Eignet sich für MVVM.  
* Warum Akka? Neugier. Akka.net wurde von Herr Röber in meinem ersten Gespräch bei Ihnen erwähnt, und war mir bis Dato unbekannt. Ich wollte mal sehen was das ist. Mir ist bewusst, dass die Verwendung von Akka für diese Aufgabe völlig überdimensioniert ist, dennoch denke ich das die Kombination der beiden Punkte:
  * Informieren über Akka
  * Lösen der Aufgabe  
  
  letztendlich weniger zeitaufwendig war als die einzelne Bearbeitung.  

## Setup
Einfach kompilieren und BerlinClockWpfApp.exe starten.

## Aufbau
Das Hauptfenster (MainWindow.xml) enthält für jedes Anzeigeelement:
* Sekunden (Blinker)
* Minuten 1,2,3,4,5,10,15,20,25,30,35,40,45,50,55
* Stunden 1,2,3,4,5,10,15,20
  
ein Usercontrol vom Typ Box (Box.xml) dessen Background-Property an das entsprechende Property des zugehörigen Viewmodels (MainViewModel) gebunden ist.  

Datenquelle ins ein simpler 'Service', der auf Anforderung ein DateTime zurückliefert. Initialisiert wird mit DateTime.Now. Bei weiteren Aufrufen wird ein 'Ticker' hochgezählt, aus dem sich die Zeitkomponente berechnet. Dadurch kann man die Zeit sozusagen beschleunigen. Wird der Service einmal pro Sekunde abgefragt läuft man sozusagen in Echtzeit.  

Die Verbindung von Viewmodel und Service erfolgt durch das Akka Actor-Modell.  

Kernelement des Actor-Modells ist der PublishingTickerActor.
Das Aktoren-Modell enthält folgende Aktoren:
* TickerLookUpActor: 
    * Empfängt: 
        * RefreshTickerMessage
    * Sendet:
        * UpdateTickerMessage  
  
  Der führt aufgrund einer RefreshTickerMessage eine Service-Anfrage durch und teilt das Ergebnis per UpdateTickerMessage dem Anfragenden mit.

* PublishingTickerActor:
    * Empfang:
        * SubscribeToTickerMessage  
        * UnSubscribeFromTickerMessage
        * RefreshTickerMessage
        * UpdateTickerMessage
    * Senden:
        * TickerMessage  
  
  Der PublishingTickerActor ist das Kernelement des Aktoren-Modells. Er implementiert ein Observer-Pattern. Andere Aktoren können sich an dem PublishingTickerActor anmelden, bzw. abmelden (SubscribeToTickerMessage, UnSubscribeFromTickerMessage) und werden bei Bedarf mittels einer TickerMessage benachrichtigt. Wenn der PublishingTickerActor eine RefreshTickerMessage erhält, wird diese an den TickerLookUpActor weitergeleitet. Dieser führt eine Serviceanfrage durch und meldet das Ergebnis mittels UpdateTickerMessage an den PublishingTickerActor zurück. Im Fall eine UpdateTickerMessage erzeugt der PublishingTickerActor eine TickerMessage und teilt diese seinen Subscribern mit. Dem PublishingTickerActor wird beim Erzeugen über einen Scheduler im Sekundentakt eine RefreshTickerMessage gesendet. Über die RefreshTickerMessage kann auch die Taktung erhöht werden (Just for fun)
  
* Bridge Aktoren (für die Verbindung UI und Actor-Modell)
    * HoursActor
        * Empfängt: TickerMessage 
    * MinutesActor
        * Empfängt: TickerMessage
    * SecondsActor
        * Empfängt: TickerMessage   
  
  Die Bridge Aktoren melden sich im MainViewModel bei dem PublishingTickerActor an und werden von diesem mit einer TickerMessage versorgt. Die Bridge Aktoren werden über den Konstruktor mit einem Zeit Slot( 1,2,3,4,5,10,15,20,25,30,35,40,45,50,55 Minuten, bzw. 1,2,3,4,5,10,15,20 Stunden), einer ToggleOn und einer ToggleOff Aktion versorgt. Diese Aktionen sind Methoden des Viewmodels, welche die Properties, die an das Background-Property der 'Usercontrol-Box' im MainWindow gebunden sind, mit dem entsprechenden Farbwert für den Status 'An' oder 'Aus' versorgen.
  
  
# Tests
Getestet wird mit Xunit. Es werden insgesamt 1097 Tests durchgeführt.  
Unit Tests für folgende Aktoren:
* HoursActor: Es werden alle Schaltzustände für die 'StundenBoxen' getestet
* MinutesActor: Es werden alle Schaltzustände für die 'MinutenBoxen' getestet
* SecondsActor: Es werden alle Schaltzustände für den 'Skundenticker' getestet
* TickerLookUpActor: Es wird überprüft ob der Aktor zu einer RefreshTickerMessage eine UpdateTickerMessage mit dem korrekten Zeitwert zurückliefert.  
  
Integrationstest für den PublishingTickerActor:
Die Bridge-Aktoren werden angemeldet und es wird z.Zt. für 2 Testdatensätze die Ergebnisse überprüft.  

Als visuellen Test kann die Taktung der Serviceabfrage über den Schieberegler am oberen Rand des Fensters erhöhen.



# Links
[AKKA.Net Dokumenation](http://getakka.net/articles/actors/testing-actor-systems.html)

# Nuget
* Akka.net
* Akka.DI.AutFac
* Akka.DI.Core
* Akka.TestKit
* AutoFac
* Xunit
* Xunit.runner.visualstudio
