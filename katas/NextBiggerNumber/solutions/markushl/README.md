# NextBiggerNumber

Implementierung der NextBiggerNumber Kata in C# (.NET Core 2.1) als Konsolenanwendung.
Als Unit Testing Framework wurde [xUnit](https://xunit.net/)  Version 2.4.0 verwendet.

## Erstellung

```shell
$ markushl\NextBiggerNumber\NextBiggerNumber>dotnet build
```

## Unit Testing

```shell
$ markushl\NextBiggerNumber\NextBiggerNumber>dotnet test
```
##### Output:
```shell
Testlauf für "C:\Git\katas\NextBiggerNumber\solutions\markushl\NextBiggerNumber\NextBiggerNumber.Tests\bin\Debug\netcoreapp2.1\NextBiggerNumber.Tests.dll" (.NETCoreApp,Version=v2.1)
Microsoft (R) Testausführungs-Befehlszeilentool Version 16.1.0
Copyright (c) Microsoft Corporation. Alle Rechte vorbehalten.

Die Testausführung wird gestartet, bitte warten...

Der Testlauf war erfolgreich.
Total tests: 8
     Passed: 8
Testausführungszeit: 1,7013 Sekunden
```

## Benutzung

```shell
$ markushl\NextBiggerNumber\NextBiggerNumber>dotnet run
Program for determining the next largest number with the same digits.
Please enter a natural number: 312
The next largest number of 312 is 321.
```

## Autoren

* Markus Hlacer
