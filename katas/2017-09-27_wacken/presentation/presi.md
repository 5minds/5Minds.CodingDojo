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
  
---
class: content

## Und warum brauchen wir das?

* Wir sollten unsere Fähigkeiten stets trainieren.

* Wir sollten unsere Gemeinschaft stark halten.

Denn das ist das Fundament unseres Erfolgs!

---
class: content

## Unsere Aufgaben - weniger Kata, eher Raumschiff Enterprise

* Spaß am Neuen steht im Mittelpunkt
* weniger die Repetition
* keine Formalismen

---
class: content

## Der Ablauf - Vorstellung der Aufgabe(n) (15 Minuten)

* Pro Dojo können ein oder auch mehrere Aufgaben vorgestellt werden.

* Aber nur eine Aufgabe wird im Dojo bearbeitet.

* Dazu werden die Aufgaben kurz vorgestellt und ggf. das Ziel beschrieben.

* Dann wird kurz über das zu lösende Aufgabe abgestimmt.

* Teambildung (1 bis 3 Personen).
  
---
class: content

## Der Ablauf - Umsetzungsphase (1 Std.)

* Die Teams verteilen sich und setzen die Aufgabe um.

* Die Wahl der Sprache liegt bei den Teams.

---

class: content

## Der Ablauf - Auswertungsphase (1 Std.)

* Die Teams stellen ihre Lösungen vor
  
  * maximal 15 Minuten incl. Diskussion
  
  * Ist die Gruppe zu groß, wird vorher kurz entschieden welche Lösungen gezeigt werden.

---

class: content

# Der Auftrag

Wir wurden beauftragt ein Programm zu erstellen, welches eine Route findet, mit welcher die Besucher eine bestimmte Anzahl an Bands sehen können, ohne dabei an einer Bühne zwei Mal vorbei zu müssen.


* Sprint 0: PoC - Routenerstellung auf einem statischen Bild


---


class: content

# Das Problem / die Frage

- Das Königsberger Brückenproblem ist eine mathematische Fragestellung des frühen 18. Jahrhunderts, die anhand der sieben Königsberger Pregelbrücken illustriert wurde.
Die Frage war, ob es einen Weg gibt, mit dem man alle sieben Brücken genau einmal überquert und am Ende wieder zum Startpunkt gelangt.
- Auf unser Beispiel bezogen heißt das, dass wir einen weg finden müssen, mit dem wir an einem Punkt starten und bestimmte Bühnen ablaufen können, ohne dabei eine Bühne zweimal sehen zu müssen.
(Siehe Wikipedia)
---

class: content

# Analyse der Karte

Die Situation ist ein stark verpixeltes Bild aus der Vogelperspektive. 

* ```x``` stellt eine leere Fläche dar
* ```-``` stellt eine Wand dar
* ```+``` stellt den begehbaren Weg dar
* ```o``` stellt die Bühne/n dar

---

class: content, center

## Die Karte

```
xxxxxxxxxxxxxxxxxxxxxxxxxx---------------xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
xxxxxxxxxxxxxxxxxxxxxxxxxx-+++++++++++++-xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
xxxxxxxxxxxxxxxxxxxxxxxxxx-+++++++++++++-xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
xxxxxxxxxxxxxxxxxxxxxxxxxx-+++++++++++++-xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
xxxxxxxxxxxxxxxxxxxxxxxxxx-+++++++ooo+++-xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
xxxxxxxxxxxxxxxxxxxxxxxxxx-+++++++o8o+++-xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
xxxxxxxxxxxxxxxxxxxxxxxxxx-+++++++ooo+++-xxxxxxxxxxxxxxx------------------xxxxxxx
xxxxxxxxxxxxxxxxxxxxxxxxxx-+++++++++++++-xxxxxxxxxxxxxxx-++++++++++++++++-xxxxxxx
xxxxxxxxxxxxxxxxxxxxxxxxxx-+++++++++++++-xxxxxxxxxxxxxxx-++++++++++++++++-xxxxxxx
xxxxxxxxxxxxxxxxxxxxxxxxxx-+++++++++++++-xxxxxxxxxxxxxxx-++++++++++++++++-xxxxxxx
xxxxxxxxxxxxxxxxxxxxxxxxxx-+++++++++++++-xxxxxxxxxxxxxxx-++++++++++++++++-xxxxxxx
xxxxxxxxxxxxxxxxxxxxxxxxxx-+++++++++++++-xxxxxxxxxxxxxxx-++++++++++++++++-xxxxxxx
xxxxxxxxxxxxxxxxxxxxxxxxxx-+++++++++++++-xxxxxxxxxxxxxxx-++++++++++++++++-xxxxxxx
xxxxxxxxxxxxxxxxxxxxxxxxxx-+++++++++++++-xxxxxxxxxxxxxxx-++++++++++++++++-xxxxxxx
xxxxxxxxxxxxxxxxxxxxxxxxxx-+++++++++++++-xxxxxxxxxxxxxxx-+++++++++ooo+ooo-xxxxxxx
xxxxxxxxxxxxxxxxxxxxxxxxxx-+++++++++++++-xxxxxxxxxxxxxxx-+++++++++o4o+o5o-xxxxxxx
xxxxxxxxxxxxxxxxxxxxxxxxxx-++++ooo++++++-xxxxxxxxxxxxxxx-+++++++++ooo+ooo-xxxxxxx
xxxxxxxxxxxxxxxxxxxxxxxxxx-++++o6o++++++-xxxxxxxxxxxxxxx-++++++++++++++++-xxxxxxx
xxxxxxxxxxxxxxxxxxxxxxxxxx-++++ooo++++++-xxxxxxxxxxxxxxx-++++++++++++++++-xxxxxxx
xxxxx-----------------------+--------+-------------------+-----------------------
xxxx--+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
xxx--+++-------------------------------------------------------------------------
xx--+++--xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
xx-+++++-x-----------------------------------------------x-----------xxxxxxxxxxxx
---++-++---+++++++++++++++++++++++++++++++++++++++++++++-x-+++++++++-xxxxxxxxxxxx
-+++---+++++++++++++++++++++++++++++++++++++++++++++++++-x-+++++++++-xxxxxxxxxxxx
+++--x-----+++++++++++++++++++++++++++++++++++++++++++++---+++++++++-xxxxxxxxxxxx
----xxxxxx-+++++++++++++++++++++++++++++++++++++++++++++++++++++++++-xxxxxxxxxxxx
xxxxxxxxxx-+++++++++++++++++++++++++++++++++++++++++++++---+++++++++-xxxxxxxxxxxx
xxxxxxxxxx-+++++++++++++++++++++++++++++++++++++++++++++-x-+++++++++-xxxxxxxxxxxx
xxxxxxxxxx-+++++++++++++++++++++++++++++++++++++++++++++-x-+++++++++-xxxxxxxxxxxx
xxxxxxxxxx-+++++++++++++++++++++++++++++++++++++++++++++-x-+++++++++-xxxxxxxxxxxx
xxxxxxxxxx-+++++++++++++++++++++++++++++++++++++++++++++-x-+++++++++-xxxxxxxxxxxx
xxxxxxxxxx-+++++++++++++++++++++++++++++++++++++++++++++-x-+++++++++-xxxxxxxxxxxx
xxxxxxxxxx-ooo++++++++++++++++++++++++++++++-++-++-------x-----------xxxxxxxxxxxx
xxxxxxxxxx-o7o+++++++++++++++++++++++++++++--++-++-xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
xxxxxxxxxx-ooo+++++++++++++++++++++++--------++-++------xxxxxxxxxxxxxxxxxxxxxxxxx
xxxxxxxxxx-++++++++++++++++++---------+++++++++++++++++-xxxxxxxxxxxxxxxxxxxxxxxxx
xxxxxxxxxx-++++++++++++-------+++++++++++++++++++++++++-xxxxxxxxxxxxxxxxxxxxxxxxx
xxxxxxxxxx--------+-----+++++++++++++++++++++++++++++++-xxxxxxxxxxxxxxxxxxxxxxxxx
xxxxxxxxxx-++++++++++++++++++++++++++++++++++++++++++++-xxxxxxxxxxxxxxxxxxxxxxxxx
xxxxxxxxxx-++++++++++++++++++++++++++++++++++++++++++++-xxxxxxxxxxxxxxxxxxxxxxxxx
xxxxxxxxxx-++++++++++++++++++++++++++++++++++++++++++++-xxxxxxxxxxxxxxxxxxxxxxxxx
xxxxxxxxxx-++++++++++++++++++++++++++++++++++++++++++++-xxxxxxxxxxxxxxxxxxxxxxxxx
xxxxxxxxxx-++++++++++++++++++++++++++++++++++++++++++++-xxxxxxxxxxxxxxxxxxxxxxxxx
xxxxxxxxxx-++++++++++++++++++++++++++++++++++++++++++++-xxxxxxxxxxxxxxxxxxxxxxxxx
xxxxxxxxxx-++++++++++++++++++++++++++++++++++++++++++++-xxxxxxxxxxxxxxxxxxxxxxxxx
xxxxxxxxxx-+++++ooo++++++++++++++ooo+++++++++++++ooo+++-xxxxxxxxxxxxxxxxxxxxxxxxx
xxxxxxxxxx-+++++o3o++++++++++++++o2o+++++++++++++o1o+++-xxxxxxxxxxxxxxxxxxxxxxxxx
xxxxxxxxxx-+++++ooo++++++++++++++ooo+++++++++++++ooo+++-xxxxxxxxxxxxxxxxxxxxxxxxx
xxxxxxxxxx----------------------------------------------xxxxxxxxxxxxxxxxxxxxxxxxx
```

---

class: content, center

## Zusätzliche Informationen

Link: 
https://github.com/5minds/5Minds.CodingDojo/tree/develop/katas/2017-09-27_wacken

---

class: content, center

# Was ist die Aufgabe?

## Interpretiert 4 Karten/Abläufe!

Siehe Handout! 

---

class: content, center

Vielen Dank für eure Aufmerksamkeit!
