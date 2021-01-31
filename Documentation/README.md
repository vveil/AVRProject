# Einrichtungshinweise
[Startseite der Dokumentation](./documentation.md)
## Getting Started

### Vorraussetzungen
* verwendete Unity-Version: 2019.4.12
* Smartphone mit mindestens Android 7 zum Testen

### Installation
1. Klone das Repository von GitHub  
`git clone https://github.com/vveil/AVRProject.git`
2. Füge das Projekt im _Unity Hub_ über _ADD_ hinzu.
3. Öffne das Projekt
4. Installiere folgende Packages über den Package Manager (ggf. muss aktiviert werden, dass preview-packages angezeigt werden)
    1. XR Interaction Toolkit (v. 0.9.4)
    2. ARCore XR Plugin (v. 2.1.11)
    3. AR Foundation (2.1.8)
5. Erzeuge in den _Project Settings_ im Bereich _XR > ARCore_ eine Konfiguration
6. Setze im Bereich _XR Plug-in Management_ im _Android_-Tab den Haken bei _ARCore_
7. Im Bereich _Player_ im _Android_-Tab unter _Other Settings_ aktiviere _Auto Graphics API_ und wähle als _Minimum API Level_ _Android 7.0 'Nougat' (API Level 24)_ aus
6. Installiere den _MapTileGridCreator_ über den _Asset Store_

## Bauen & Ausführen
1. Öffne die `Build Settings`
2. Stelle als Plattform `Android` ein und füge die Szene `AR Tower Defense` hinzu.
3. Schließe ein Android-Gerät an, welches den Anforderungen entspricht
4. Aktiviere `USB-Debugging` in den Entwicklereinstellungen des Smartphones
5. Baue das Projekt mit einem Klick auf `Build and run` in den `Build Settings`

## Ausgabe von Log-Nachrichten
Ggf. ist es interessant Log-Nachrichten auslesen zu können, während die AR-App auf dem Smartphone läuft. Um dies zu ermöglichen befolge diese Schritte:
1. Öffne ein Terminal/Kommandozeile
2. Installiere `adb` (android-debug-bridge)
3. Verbinde das Smartphone über USB
4. Mit dem Befehl `adb devices` sollte dir das angeschlossene Smarthone angezeigt werden.
5. Starte nun die App, die Log-Nachrichten ausgeben soll.
6. Gib jetzt im Terminal den Befehl `adb logcat -s Unity` ein.
7. Es sollten die jetzt alle Log-Nachrichten vom Smartphone mit den Keyword `Unity` angezeigt werden.

## Dokumentation
Neben den Einrichtungshinweisen gibt es eine ausführlichere Dokumentation zu diesem Projekt, welche [hier](./documentation.md) gefunden werden kann.