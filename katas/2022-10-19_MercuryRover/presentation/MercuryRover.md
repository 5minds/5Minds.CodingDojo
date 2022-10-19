# Mercury Rover

Die GeSA (Gelsenkirchener Space Agency) plant eine Mission zum Merkur. Dafür wurde ein Rover gebaut, der von der Erde aus ferngesteuert werden soll. Deine Aufgabe ist es, die gesendeten Befehle zu interpretieren und den Rover zu steuern.

Die Befehle werden als Kommagetrennte Liste gesendet und dann vom Rover abgearbeitet.
Am Ende der Liste steht die erwartete Position des Rovers hinter dem “->” Zeichen. (“R90, F10, R270, F50, B10 -> 40, 10”)

Ein Befehl besteht immer aus einem Kommando und einem Wert.

Folgende Kommandos sind möglich:
- F: Forward
  - Bewege den Rover, um den angegebene Wert, in die aktuelle Richtung Vorwärts
  - F10: Bewege den Rover um zehn Schritte Vorwärts
- B: Backward
  - Bewege den Rover, um den angegebene Wert, entgegengesetzt der aktuellen Richtung
  - B12: Bewege den Rover um zwölf Schritte Rückwärts
- R: Right
  - Drehe den Rover um die angegebene Gradzahl nach Rechts. Mögliche Werte sind: 0, 90, 180, 270, 360
  - R90: Drehe den Rover um 90° nach Rechts.
- L: Left
  - Drehe den Rover um die angegebene Gradzahl nach Links. Mögliche Werte sind: 0, 90, 180, 270, 360
  - L180: Drehe den Rover um 180° nach Links.


Folgende Annahmen werden für den Start getroffen:
- Der Rover startet immer auf Position 0,0
- Er schaut beim Start immer nach Osten
- Er wird sich von der Startposition aus immer nach Süden und Norden bewegen. (Also nicht in den negativen Bereich fahren)

## Erweiterung

Der Rover lädt eine Karte seiner Umgebung und bewegt sich über diese. Da die Karte Hindernisse (Krater, Felsblöcke) enthält, muss er die Umgebung scannen und bei den Befehlen überprüfen, ob er gegen ein Hindernis fahren würde. Ist dies der Fall, gibt er einen Fehler zurück.

Auf der Karte wird eine befahrbare Fläche mit einem ‘.’ angegeben, eine Krater mit einem ‘O’ und ein Felsblock mit einer ‘#’.

```
.O..........O.......
.........O..........
....................
....................
O...#...O..#........
.O........O.........
.O..O.#.............
...................O
```

Das Handout, die Liste der Befehle und die Karte findest du unter:

https://github.com/5minds/5Minds.CodingDojo/katas/2022-10-19_MercuryRover/presentation/assets/ 


Let’s fly to Mercury…

