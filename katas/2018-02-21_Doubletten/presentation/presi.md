class: title

# 5Minds Coding Dojo #7

---

class: content

# Heute präsentiert Euch ...

<img src="img/mba.png" class="wrap align-right" width="256" height="256"/>

* Marc Biegota

* Seit April 2016 bei 5Minds

* Senior Software Architekt und leidenschaftlicher Entwickler

* marc.biegota@5minds.de

... die folgende Aufgabe

---
class: content

# Doch vorher...

## Der Ablauf - Vorstellung der Aufgabe(n) (15 Minuten)

* Pro Dojo können ein oder auch mehrere Aufgaben vorgestellt werden.

* Aber nur eine Aufgabe wird im Dojo bearbeitet.

* Dazu werden die Aufgaben kurz vorgestellt und ggf. das Ziel beschrieben.

* Dann wird kurz über das zu lösende Problem abgestimmt.

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

# Dateidubletten finden!

Entwickle eine Bibliothek, mit der man Dateidubletten in einem Verzeichnisbaum
finden kann.

---

class: content

# Dateidubletten finden!

## Das Interface 

```java
interface IDublettenprüfung {
 IEnumerable<IDublette> Sammle_Kandidaten(string pfad);
 IEnumerable<IDublette> Sammle_Kandidaten(string pfad, Vergleichsmodi modus);
 
 IEnumerable<IDublette> Prüfe_Kandidaten(IEnumerable<IDublette> kandidaten);
}
 
interface IDublette {
 IEnumerable<string> Dateipfade {get;} 
}
 
enum Vergleichsmodi {
 Größe_und_Name,
 Größe
}
``` 

---

class: content

# Dateidubletten finden!

## Was passiert?

Zuerst wird die Methode Sammle_Kandidaten() aufgerufen. Sie durchläuft alle
Dateien in einem Verzeichnisbaum und vergleicht Dateien nur sehr grob.
Standardmäßig werden Dateiname und -größe verglichen, auf Wunsch aber auch nur
die Dateigröße. Dateien, die danach für gleich gehalten werden, liefert die
Funktion als IDublette zurück.

---

class: content

# Dateidubletten finden!

## Und dann?


In einem zweiten Pass werden dann potenzielle Dubletten auf ihre tatsächliche
Gleichheit geprüft. Jetzt wird der komplette Inhalt repräsentiert durch einen
[MD5 Hash] verglichen. Dateien, die nun gleich sind, werden wieder als IDublette
zurückgeliefert [1].  

Ressourcen
[MD5 Hash] http://de.wikipedia.org/wiki/Message-Digest_Algorithm_5

Endnoten [1] Bedenke, dass es in einer Liste von Kandidaten Gruppen von
tatsächlichen Dubletten geben kann.

---
class: content, center

Vielen Dank für eure Aufmerksamkeit!
