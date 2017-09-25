## Das Problem / die Frage

- Wir müssen ein Programm schreiben, welches erkennt ob es einen Weg gibt bestimmte Bands/Bühnen in einem festgelegtem Zeitplan zu sehen, ohne dabei eine Band/Bühne zweimal zu sehen.

## Das Spielfeld

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
# Analyse der Karte

Die Situation ist ein stark verpixeltes Bild aus der Vogelperspektive. 

* ```x``` stellt eine leere Fläche dar
* ```-``` stellt eine Wand dar
* ```+``` stellt den begehbaren Weg dar
* ```o``` stellt die Bühne/n dar

## Zusätzliche Informationen

Link: 
https://github.com/5minds/5Minds.CodingDojo/tree/develop/katas/2017-09-27_wacken
