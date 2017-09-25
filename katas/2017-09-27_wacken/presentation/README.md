# Coding Dojo Königsberger Brückenproblem

Das Ziel dieser Übung ist es ein Programm zu schreiben, welches anhand von gegebenen Daten das Königsberger Brückenproblem löst bzw. erkennt ob es besteht oder nicht.

Anbei 4 Quellen:

- [Wikipedia](https://de.wikipedia.org/wiki/K%C3%B6nigsberger_Br%C3%BCckenproblem)
- [Matheprisma](http://www.matheprisma.uni-wuppertal.de/Module/Koenigsb/)
- [Universität Wien](http://homepage.univie.ac.at/franz.embacher/Lehre/aussermathAnw/Spaziergaenge.html)
- [Mathepedia](http://www.mathepedia.de/Koenigsberger_Brueckenproblem.aspx)

Die Situation ist ein stark verpixeltes Bild von Oben. Es gibt 5 Testbilder, 
welche das Programm durchlaufen soll, um zu beweisen dass es korrekt funktioniert.

Die Karte spiegelt das Wacken Gelände grob und verpixelt wieder.

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

Erklärung zur Karte:
- ```x``` stellt eine leere Fläche dar
- ```-``` stellt eine Wand dar
- ```+``` stellt den begehbaren Weg dar
- ```o``` stellt die Bühne/n dar

Damit viel Erfolg!