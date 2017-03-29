class: title

# 5Minds Coding Dojo

---

class: content

# Agenda

* Vorstellung

* das Thema

* die Aufgabe

---

class: content

# Wer ist heute Euer Host?

<img src="img/mba.png" class="wrap align-right" width="256" height="256"/>

* Marc Biegota

* Seit April 2016 bei 5Minds

* Senior Software Architekt und leidenschaftlicher Entwickler

* marc.biegota@5minds.de

---
class: content

## Was ist ein Coding Dojo? 

Wikipedia:
* Ein Dojo bezeichnet einen Trainingsraum für verschiedene japanische Kampfkünste. 

* Im übertragenen Sinne steht der Begriff auch für die Gemeinschaft der dort Übenden.

Die Prinzipien der Kampfkünste können und wollen wir uns zunutze machen.
  
---
class: content

## Und warum brauchen wir das?

* Wir sollten unsere Fähigkeiten stets trainieren.

* Wir sollten unsere Gemeinschaft stark halten.

Denn das ist das Fundament unseres Erfolgs!

---
class: content

## Katas

* Der Name stammt aus den japanischen Kampfkünsten und beschreibt grundlegende Übungsformen. 
  * Dabei betont es die Bedeutung von Praxis und Wiederholung für das Lernen.

* Ein Kata bezeichnet in der Programmierung eine kleine, abgeschlossene Übung. 

---
class: content

## Katas
 
* Gibt es für jede Ebene der Softwareentwicklung.
  * Code-, Class-, Application und sogar Architektur-Katas.

* Werden testgetrieben entwickelt.

* Laden dazu ein, auch ausserhalb des Dojo immer wieder neu durchgespielt zu werden.

---
class: content

## Katas - warum immer und immer wieder?

* Grundsätzlich: durch Wiederholung wird effektiv eingeprägt!

* Umsetzung mit einer anderen Programmiersprache.

* Entwicklung unter einem anderen Paradigma
  
  * Prozedural / objektorientiert / funktional / prototypisch

---
class: content

## Katas - warum immer und immer wieder?

* Austausch durch einen anderen Algorithmus mit unterschiedlichen Schwerpunkten.
  
  * kurzer Code
  
  * schnelle Ausführung
  
  * effizienter Speicherverbrauch
  
  * rekursiv statt iterativ oder umgekehrt

---
class: content

## Der Ablauf - Vorstellung der Katas (15 Minuten)

* Pro Dojo können ein oder auch mehrere Katas vorgestellt werden.

* Aber nur ein Kata wird im Dojo bearbeitet.

* Dazu werden die Katas kurz vorgestellt und ggf. das Ziel beschrieben.

* Dann wird kurz über das zu lösende Kata abgestimmt.

* Teambildung (1 bis 3 Personen).
  
---
class: content

## Der Ablauf - Umsetzungsphase (1 Std.)

* Die Teams verteilen sich und setzen das Kata um.

* Die Wahl der Sprache liegt bei den Teams.

---
class: content

## Der Ablauf - Auswertungsphase (1 Std.)

* Die Teams stellen ihre Lösungen vor
  
  * maximal 15 Minuten incl. Diskussion
  
  * Ist die Gruppe zu groß, wird vorher kurz entschieden welche Lösungen gezeigt werden.

---
class: content, center

# Was ist unser Thema?

## Die Langton Ameise

Die Ameise ist eine Turingmaschine mit einem zweidimensionalen Speicher und wurde 1986 von Christopher Langton
entwickelt.  
Sie ist ein Beispiel dafür, dass ein deterministisches System aus einfachen Regeln sowohl für den Menschen visuell
überraschend ungeordnet erscheinende als auch regelmäßig erscheinende Zustände annehmen kann.  
(Wikipedia)

---
class: content

# Die Aufgabe

<img src="img/LangtonsAntAnimated.gif" class="wrap align-right"/>

Benötigt werden zwei Lösungen.

* Die erste Lösung ist das Backend und führt den eigentlichen Algorithmus aus.

* Die zweite Lösung nimmt das Ergebnis der ersten Lösung und stellt es graphisch dar.

---
class: content

# Die Regeln

<img src="img/LangtonsAntAnimated.gif" class="wrap align-right"/>

Die Ameise befindet sich in einem Raster, bestehend aus quadratischen Feldern, die entweder schwarz oder weiß sein
können.  
In der Ausgangssituation sind alle Felder weiß und die Ameise schaut in eine bestimmte Richtung. Der Übergang
zum nächsten Zustand erfolgt nach folgenden Regeln:

1. Auf einem weißen Feld drehe 90 Grad nach rechts; auf einem schwarzen Feld drehe 90 Grad nach links.
2. Wechsle die Farbe des Feldes (weiß nach schwarz oder schwarz nach weiß).
3. Schreite ein Feld in der aktuellen Blickrichtung fort.

---
class: content

# Die Lösung

<img src="img/LangtonsAntAnimated.gif" class="wrap align-right"/>  

* die Funktion nimmt entgegen
  * die Kantenlänge des Feldes
  * die Startposition der Ameise
  * die Blickrichtung der Ameise (n, o , s, w)
  * die Anzahl der Züge 

* die Funktion speichert eine Datei
  * mit einer Zeile pro Zug mit
  * jedem Feld kommasepariert (w, s, nw, ns, ow, os, sw, ss, ww, ws)

---
class: content

# Die Lösung

<img src="img/LangtonsAntAnimated.gif" class="wrap align-right"/>  

* die Oberfläche nimmt entgegen
  * den Pfad der Datei
  * die Zuggeschwindigkeit 

* die Oberfläche gibt aus
  * das Quadratische Spielfeld
  * die jeweilgen Farben
  * ein Ameisensymbol an der korrekten Position mit Drehrichtung
  * die aktuelle Zugnummer

---

class: content, center

## Vielen Dank für Eure Aufmerksamkeit!


