# Analyse einer Abseitssituation

Die Situation ist ein stark verpixeltes Bild von Oben. 

* Das Fußballfeld ist 45 x 60 Meter groß.
* Ein Spieler kann bis zu 3 x 3 Meter Platz einnehmen.
* Jedes Feld, außer die Mittellinie, nimmt 1 Quadratmeter Platz ein.
* Nach 30 Metern befindet sich die Mittellinie. 

## Abseitsregeln

Abseits ist wenn:

* der Spieler der gegnerischen Torlinie näher ist als der Ball und
* sich weniger als zwei gegnerische Spieler, egal ob Torwart oder Feldspieler, 
auf gleicher Höhe mit ihm oder vor ihm befinden und
* er sich in der gegnerischen Spielhälfte befindet.

## Das Spielfeld

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

## Die Spielertypen

```
oxo    ooo    +oo    o+o    +++
oxo    oxo    ++o    ++@    +++
oox    ooo    o++    oo+    +++
```


Verteidiger - minimaler Verteidiger - Angreifer - Angreifer mit Ball - maximaler Angreifer

## Positionierung

Zwischen zwei Teammitgliedern ist immer ein Feld Platz. 

Mit `-` zur Anschauung verbildlicht:

```
oo-----oooooooooooo
oo-oxo-----oooooooo
oo-xxo-oox-oooooooo
oo-ooo-xxo-oooooooo
oo-----oxo-oooooooo
oooooo-----oooooooo
``` 

## Zweikampf

Spieler von zwei Mannschaften können auch ineinander dargestellt werden. 

Ein Zweikampf um den geflankten Ball:

```
ooooo+oooooo
oooox++ooooo
oooooxoooooo
oooooooooooo
```

## Zusätzliche Informationen

Link: 
https://github.com/5minds/5Minds.CodingDojo/tree/develop/katas/2017-08-02_football
