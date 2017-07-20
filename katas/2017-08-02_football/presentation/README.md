# Coding Dojo Abseitserkennung

Das Ziel dieser Übung ist es ein Programm zu schreiben, das anhand von Daten 
erkennt ob eine Spielsituation als Abseits angesehen werden kann. 
Dabei muss man sich erstmal die Abseitsregel genauer ansehen, um die Situation 
als solche erkennen zu können.
Anbei 4 Quellen:

- [Wikipedia](https://de.wikipedia.org/wiki/Abseitsregel#Fu.C3.9Fball)
- [DFB](https://www.dfb.de/schiedsrichter/artikel/abseits-oder-nicht-892/)
- [Duden](http://www.duden.de/rechtschreibung/Abseits)
- [Giga](http://www.giga.de/events/bundesliga/artikel/was-ist-abseits-definition-der-regel/)

Die Situation ist ein stark verpixeltes Bild von Oben. Es gibt 5 Testbilder, 
welche das Programm durchlaufen soll, um zu beweisen dass es korrekt funktioniert.

Das Fußballfeld ist 90 x 120 Meter groß.
Ein Spieler kann bis zu 3 x 3 Meter Platz einnehmen. 
Jeder Block, außer die Mittellinie, nimmt 1 Kubikmeter Platz ein.
Dazu gehören Spieler, Ball und Torrahmen.
Nach 60m befindet sich die Mittellinie. 
```
oooooooooooooooooooooooooooooooooooIooooooooooooooooooooooooooooooooooo
oooooooooooooooooooooooooooooooooooIooooooooooooooooooooooooooooooooooo
oooooooooooooooooooooooooooooooooooIooooooooooooooooooooooooooooooooooo
oooooooooooooooooooooooooooooooooooIooooooooooooooooooooooooooooooooooo
IooooooooooooooooooooooooooooooooooIooooooooooooooooooooooooooooooooooI
IooooooooooooooooooooooooooooooooooIooooooooooooooooooooooooooooooooooI
IooooooooooooooooooooooooooooooooooIooooooooooooooooooooooooooooooooooI
IooooooooooooooooooooooooooooooooooIooooooooooooooooooooooooooooooooooI
oooooooooooooooooooooooooooooooooooIooooooooooooooooooooooooooooooooooo
oooooooooooooooooooooooooooooooooooIooooooooooooooooooooooooooooooooooo
oooooooooooooooooooooooooooooooooooIooooooooooooooooooooooooooooooooooo
oooooooooooooooooooooooooooooooooooIooooooooooooooooooooooooooooooooooo
```

Spieler werden durch eine 3x3 Matrix definiert.
Ein "verteidigender" Spieler sieht wie folgt aus: 


```
oxo
oxo
oox
```

Ein einzelner Spieler ist der Schütze, welcher den Ball abschießt. 
Der Ball ist gekennzeichnet als `@`.
Es gibt mindestens zwei attackierende Spieler. Den Schützen und die Person die 
sich möglicherweise im Abseits befindet.

```
o+o
++@
oo+
```

Ein Spieler muss sich nicht bewegen, d.h. er steht nur auf dem Feld und nimmt
nur ein Feld ein. Seinen Minimalplatz. Wenn der angreifende Spieler steht, 
befindet er sich trotzdem im Schuss, d.h. es exisitiert ein mögliches Abseits. 
Wie man bereits sieht sind die Angreifer durch `+` gekennzeichnet und die 
verteidiger durch `x`.

Hier sieht man einen alleinstehenden Verteidiger: 

```
ooo
oxo
ooo
```

Zwischen zwei Teammitgledern ist immer ein Feld Platz. 
Mit `-` zur Anschauung verbildlicht:

```
oo-----oooooooooooo
oo-oxo-----oooooooo
oo-xxo-oox-oooooooo
oo-ooo-xxo-oooooooo
oo-----oxo-oooooooo
oooooo-----oooooooo
``` 

Gegner können auch ineinander dargestell werden. Ein Kopf an Kopf Rennen 
um das Abseits:

```
ooooo+oooooo
oooox++ooooo
oooooxoooooo
oooooooooooo
```

Jede Situation beinhaltet zusätzlich einen Vektor, der angibt, in welche 
Richtung der Ball fliegt.

Damit viel Erfolg und:

```
Ludi incipiant
    „Die Spiele mögen beginnen“
```
