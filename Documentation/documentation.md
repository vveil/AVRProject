# AVR(BI128) Semesterprojekt - Tower Defense in AR
von Dennis Pribe und Niklas Werner

## Linksammlung
[Software-Dokumentation](./software-documentation)  
[Abkürzungsverzeichnis](./abkuerzungsverzeichnis.md)

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

## Reflektion & Fazit
