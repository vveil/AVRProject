# AVR(BI128) Semesterprojekt - Tower Defense in AR
von Dennis Pribe und Niklas Werner  

- [AVR(BI128) Semesterprojekt - Tower Defense in AR](#avrbi128-semesterprojekt---tower-defense-in-ar)
  - [Konzeption - Tower Defense Genre als Basis](#konzeption---tower-defense-genre-als-basis)
  - [Projekt Vision - AR Tower Defense](#projekt-vision---ar-tower-defense)
    - [Grundlegender Spielaufbau](#grundlegender-spielaufbau)
    - [Voraussichtliche Themen Umsetzung](#voraussichtliche-themen-umsetzung)
  - [Umsetzung & Testen](#umsetzung--testen)
  - [Fazit](#fazit)
  - [Linksammlung](#linksammlung)

## Konzeption - Tower Defense Genre als Basis
Das Tower Defense Spielprinzip beschreibt ein Genre, in dem ein Spieler versucht, erscheinende Gegner daran zu hindern von einem Startpunkt aus ihr Ziel zu erreichen. Dies gelingt ihm, indem die Gegner vor Erreichen des Ziels mittels Abwehrmechaniken unschädlich gemacht werden.  
Es gibt diverse Ausprägungen bzw. Varianten des Spielprinzips, im Folgenden werden einige beschrieben:
1. Fest vogegebener Weg von Start Richtung Ziel
    * Der Spieler platziert Abwehrmachniken am Rand des Weges, um die Gegner zu stoppen.
    * Der Gegner kann die Abwermechaniken meistens nicht beschädigen bzw. zerstören.
2. Meherere fest vorgegeben Wege von Start Richtung Ziel
    * Der spiler platziert Abwehrmechaniken auf den Wegen, um die Gegner zu bremsen bzw. zu stoppen.
    * Der Gegner kann diese Abwehrmechaniken beschädigen bzw. zerstören.
3. Kein fest vorgegebener Weg von Start Richtung Ziel.
    * Der Spieler platziert Abwehrmechaniken strategisch, um den Weg des Gegners künstlich zu verlängern, damit genügend Zeil bleibt den Gegner zu stoppen.
    * Der Gegner kann die Abwehrmechaniken meist nicht beschädigen bzw. zerstören.
    * Dem Gegner muss es möglich bleiben, das Ziel theoretisch jederzeit zu erreichen.

Für die AR Umsetzung eines Tower Defense Spiels auf einem Smartphone wurde in diesem Projekt Variante 3 gewählt.

## Projekt Vision - AR Tower Defense
In der Abbildung wird Variante 3 anhand einer konkreten Projekt Vision veranschaulicht. Im Folgenden wird außerdem erläutert welche Interaktionen und Themen in diesem Projekt geplant und voraussichtlich umgesetzt werden.
[![AR Tower Defense Vision](./artowerdefensevision.png)](artowerdefensevision.png)

### Grundlegender Spielaufbau
Die Arena kann zu Spielbeginn auf einer geeigneten (AR begünstigenden) Oberfläche horizontal platziert werden. Anfangs ist die komplette Arena mit begehbaren Hexagons ausgelegt, welche dem Gegner einen direkten Pfad von Start Richtung Ziel ermöglichen. Der Spieler platziert Abwehrtürme, um diesen direkten Weg durch eine Art künstliches Labyrinth zu verlängern. Der Gegner nimmt auf dem Weg zum Ziel durch die Labyrinth bildenden Abwehrtürme im besten Fall tödlichen schaden. Das Spiel ist Runden/Wellen basiert. Von Runde zu Runde muss das Labyrinth strategisch erweitert werden, um den wachsenden Gegnerwellen Einhalt zu gebieten. Der Spieler kann AR bedingt jederzeit andere Blickwinkel einnehmen, indem er sich mit dem Smartphone um die Arena herumbewegt. Das Spiel ist gewonnen, wenn alle Wellen bewältigt wurden und verloren, wenn eine gewisse Anzahl an Gegnern, über die verschiedenen Wellen hinweg, das Ziel erreicht haben.

### Voraussichtliche Themen Umsetzung
Im Rahmen der Entwicklung dieser Unity Applikation werden voraussichtlich folgenden Themen der allgemeinen Projektanforderung umgesetzt:
1. Ein User Interface zum Platzieren der Arena und Abwehrtürme
2. Navigation Mesh in Form von begehbaren Hexagons und dessen Manipulation durch
Abwehrturm Hexagons, welche unter Umständen anliegende Hexagons blockieren.
3. Artificial Intelligence in Form von autonomen Gegnern, die auf dem Weg zum Ziel versuchen
den kürzesten Weg zu nehmen.
4. Audio in Form von Spielsound
5. Texturen in Form von Optischen Designmitteln

## Umsetzung & Testen
Zur Umsetzung des Projekts ist zu sagen, dass nicht alle Ziele, die in der [Projekt Vision](#projekt-vision---ar-tower-defense) genannt wurden, umgesetzt werden konnten.  
Allerdings konnten die Bereiche User Interface, `NavMesh` in Kombination mit AI, Collision und Audio umgesetzt werden. Auf mehrere Waves verteilt erscheinen immer wieder NPCs, welche daran gehindert werden müssen das Ziel zu erreichen. Erreicht ein NPC dennoch das Ziel werden dem Spieler Lebenspunkte abgezogen. Sinken die Lebenspunkte auf 0 hat der Spieler verloren. Mit Hilfe des _MapTileGridCreators_ aus dem Asset Store wurde eine Map erstellt, welche bei Nutzung der App in AR durch einen Touch auf das Display gesetzt werden kann. Nach setzen der Map kann per Touch auf eine Fläche der Map ein Turm platziert werden. Dieser greift NPCs an und macht diesen Schaden. Geschieht dies, wird ein Sound abgespielt. Weiterhin wurden Skripte erstellt, welche die UI, das Verhalten der NPCs, das Platzieren von Türmen sowie das generelle Spielverhalten verwalten.
Welche Skripte, 3D Modelle sowie Materials selbst erstellt wurden kann [hier](./eigenleistung.md) eingesehen werden.  
Die verschiedenen Funktionen der App wurden im Verlauf der Entwicklung mehrfach getestet. Bei Abgabe des Ghost Prototypes wurde festgestellt, dass es möglich ist, einen Tower so zu platzieren, dass die NPCs nicht mehr das Ziel erreichen können. Daraufhin wurde dieser Bug von den Entwicklern behoben und erneut getestet. Der Test wurde durchgeführt, in dem ein Smartphone an den Lapttop angeschlossen wurde, das Projekt über `Build and run` gebaut und gestartet wurde und probiert wurde, ob es weiterhin möglich ist, den NPCs den Weg zu versperren. Durch den Test wurde festgestellt, dass dies nun nicht mehr möglich ist.  
Um festzustellen, ob das UI und die Verwendung der App intuitiv ist, wurde die App 2 Kommilitonen gezeigt, welche ohne weitere Erklärungen das Spiel spielen sollten. Dabei kam heraus, dass einem der Kommilitonen nach dem Druck auf `Start` nicht klar war, wie er die Map platzieren kann. Aufgrund dessen wurde ein ?-`Button` hinzugefügt. Bei Druck auf den Button erscheint eine kurze Anleitung, wie das Spiel funktioniert. Der andere Kommilitone fand sich direkt im Spiel zurecht.

## Fazit
Abschließend lässt sich sagen, dass zwar nicht alle Elemente aus der Vision des Projekts umgesetzt werden konnten, es aber dennoch ein erfolgreiches Projekt geworden ist. Es wurde ein AR Tower Defense Spiel erstellt, welches zum Abschluss des Projekts spielbar ist. Durch die praktische Umsetzung des Projekts konnte viel im Bereich UI und NavMesh & AI gelernt werden.

## Linksammlung
[Einrichtungshinweise](./README.md)  
[Liste der Eigenleistungen](./eigenleistung.md)  
[Software-Dokumentation](./software-documentation.md)  
[Abkürzungsverzeichnis](./abkuerzungsverzeichnis.md)