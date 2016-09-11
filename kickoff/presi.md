class: center, middle
background-image: url(background-intro.png)

# .Net Blueprint
## Microservice Architektur

???
Was haben wir überhaupt gemacht  
Wozu ist das gut  
Warum ist das gut  
---
class: left, middle
background-image: url(background.png)

## Wozu dient der Blueprint

* Proof of Concept
  * Designentscheidungen am praxisnahen Beispiel eruieren
  * Risiko-Chancen im Voraus erkennen
  * Vorlage als anfassbare Dokumentation


---
class: left, middle
background-image: url(background.png)

## Wozu dient der Blueprint

* Dem Bootstrapping für das Projekt
  * Programmrahmen für Wiederverwendung erstellen
  * Vorlage der Architektur erstellen
  * Technologien verbinden

---
class: left, middle
background-image: url(background.png)

## Architektur

### Was sind Microservices?

* Kleine Services
* Ein Service bildet nur eine Fachlickeit ab
* Keine direkten abhängigkeiten voneinander

???
Kleine einheit  
Horizontale trennung der fachlichkeiten

---
class: left, middle
background-image: url(background.png)

## Architektur

### Vorteile von Microservices

* Fachliche Trennung
* Geringe Komplexität
* Unabhängig voneinander
  * Einfache Entwicklung
  * Geringere Fehleranfälligkeit
  * Höhere Wartbarkeit

???
Übersichtlich  
Kein versehetnliches umschubsen  
---
class: left, middle
background-image: url(background.png)

## Architektur

### Vorteile von Microservices

* Zukunftssicher durch Austauschbarkeit

???
Chad Fowler!!!  
Einzelne Teile lassen sich austauschen  
Auch durch andere Sprachen  
---
class: left, middle
background-image: url(background.png)

## Architektur

### Frontend

* WPF als Frontend Technologie
  * State-of-the-Art Technologie für die Windows-Plattform
  * Trennung von grafischen User Interface und Code
  * Moderne, einheitliche Darstellung
  * Schnelle Entwicklung
  * Automatisiertes Testen
* Austauschbar gegen andere Technologien
  * Z.B Asp.Net oder Mobile App

---
class: left, middle
background-image: url(background.png)

## Architektur

### Modulare Transportschicht

* HTTP
  * Bewährt und Robust
  * Übersichtlich und Einfach
* AMQP
  * Ausfallsicher
  * Flexibel
  * Komplexe, skalierende Systeme einfacher realisierbar
* Austauschbar

---
class: left, middle
background-image: url(background.png)

## Architektur

### Modulare Datenschicht

* Anbindung verschiedenster Datenquellen
  *	SQL Server, NoSQL Datespeicher (wie z.B. MongoDB) oder REST Service
* Bestehende Strukturen übertragbar
* Rundes Sicherheitskonzept

---
class: left, middle
background-image: url(background.png)

## Architektur

### Autorisierung

* Identity Management über das OAuth2-Protokoll
  * State-of-the-Art Protokoll für Autorisierung
  * Integration in bestehende Infrastruktur (Active Directory)
  * Weitere Applikationen über Single-Sign-On (SSO) einzubinden

---
class: center, middle
background-image: url(background.png)

![architecture](img/architecture.jpg)

---
class: center, middle
background-image: url(background.png)

![process](img/process_anim_1.jpg)

---
class: center, middle
background-image: url(background.png)

![process](img/process_anim_2.jpg)

---
class: center, middle
background-image: url(background.png)

![process](img/process_anim_3.jpg)

---
class: center, middle
background-image: url(background.png)

![process](img/process_anim_4.jpg)

---
class: center, middle
background-image: url(background.png)

![process](img/process_anim_5.jpg)

---
class: center, middle
background-image: url(background.png)

![process](img/process_anim_6.jpg)

---
class: center, middle
background-image: url(background.png)

![process](img/process_anim_7.jpg)

---
class: center, middle
background-image: url(background.png)

![process](img/process_anim_8.jpg)

---
class: center, middle
background-image: url(background.png)

![process](img/process_anim_9.jpg)

---
class: center, middle
background-image: url(background.png)

![process](img/process_anim_10.jpg)

---
class: center, middle
background-image: url(background.png)

## Live Demo

---
class: left, middle
background-image: url(background.png)

## Fazit

* Technische Konzepte wurden bereits entworfen, getestet und stehen
  zur Verfügung
* Neue Anforderungen können schnell und effizient umgesetzt werden


---
class: left, middle
background-image: url(background.png)

## Fazit

* Vorlage an der man sich in der weiteren Entwicklung orientieren kann
 * Gut dokumentierte Struktur für neue Entwickler
 * Wiederverwendbare Strukturen
 * Geringere Zeiten zwischen Auslieferbaren Ständen

---
class: center, middle
background-image: url(background.png)

## Vielen Dank
### Für Eure Aufmerksamkeit
