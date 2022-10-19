ECHO [SCHRITT 0] Arbeitsverzeichnis "xxx" löschen
rd /s /q xxx

ECHO [SCHRITT 1] Arbeitsverzeichnis "xxx" anlegen
mkdir xxx

ECHO [SCHRITT 2] Visual Studio Projekt aus CMakeLists.txt generieren
pushd xxx
cmake -G "Visual Studio 17" ..
if %ERRORLEVEL% NEQ 0 GOTO :FEHLER
popd

ECHO [SCHRITT 3] Visual Studio Projekt übersetzen, Target=Release with Debug Information, also PDBs
pushd xxx
cmake --build . --config RelWithDebInfo
if %ERRORLEVEL% NEQ 0 GOTO :FEHLER
popd

ECHO [SCHRITT 4] Alle Unit Tests ausführen
pushd xxx\bin\RelWithDebInfo
SchachbrettTest.exe --gtest_output=xml:MfcUnitTests.xml
popd


:ERFOLG
ECHO Uebersetzung erfolgreich
GOTO :ENDE

:FEHLER
popd
ECHO Es ist ein Fehler aufgetreten. Der Vorgang wird abgebrochen mit ERRORLEVEL=%ERRORLEVEL%
GOTO :ENDE
:ENDE

