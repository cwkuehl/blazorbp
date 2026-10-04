# Architekturbeschreibung der BlazorBp-Anwendung

## Überblick

BlazorBp ist eine modulare ASP.NET Core-Anwendung für die Verwaltung von Formularen und geschäftlichen Daten mit Blazor. Die aktuelle Implementierung ist kein reines Drei-Schichten-System, sondern ein Modul- und Framework-Design mit zentralen Basisklassen, einem App-Host und mehreren Funktionsmodulen. Die Kernidee ist: Ein gemeinsames UI-Framework liefert Formulare, Menüs, Tabellenlogik, Session-Handling und Sicherheitsmechanismen; die Fachmodule fügen konkrete Bereiche wie Haushalt, Wertpapiere, Benutzerverwaltung oder Demo-Funktionen hinzu.

Die wesentlichen Teilbereiche sind:

- BlazorBp: Host-Webanwendung und Einstiegspunkt
- BlazorBp.Core: Shared-Framework mit Blazor-Basis-Komponenten, Formular-Mechanik und Menü-/Session-Logik
- BlazorBp.Forms: Produktive Fachmodule (Administrierung, Haushalt, Wertpapiere, Energie etc.)
- BlazorBp.Forms.Demo: Demo- und Beispielmodule
- BlazorBp.Tests: Prüfungen für Parser, Code-Regeln und Modbus-Logik
- BlazorSpa.Base: gemeinsame Hilfs- und Basismodelle für CSV, Tabellen und Datenstrukturen

## Technologiestack

- Framework: ASP.NET Core + Blazor Server / interactive server components
- Sprache: C# mit nullable reference types und implicit usings
- Host: WebApplicationBuilder, Razor Components, MVC-Controller, OpenAPI/Swagger
- Authentifizierung: ASP.NET Core Cookie-Authentication
- Session-/Cache-Mechanik: in-memory cache oder SQLite-basierten Cache
- Datenzugriff: Factory-basierte Services über CSBP.Services.Base und CSBP.Services.Factory
- UI-Framework: Razor-Komponenten, eigene Formular- und Tabellensteuerungen
- Styling: Bootstrap + eigene CSS- und libman-gebundene Ressourcen
- Build/Test: .NET 10 solution mit dotnet CLI und xUnit-basierten Tests

## Projektstruktur

### 1. BlazorBp
Das Einstiegspunkt-Projekt und die Web-App.

Schlüsselbestandteile:

- Program.cs
  - registriert alle Module
  - konfiguriert Services, Auth, Session, Swagger, MVC, Caching
  - aktiviert Razor Components mit Interactivity
  - bindet Sicherheits- und CSP-Middleware an
- Components/
  - App.razor, Routes.razor, Layout/, Auth/, Pages/
- Controllers/
  - AuthController.cs, WebserviceController.cs
- wwwroot/
  - statische Assets, JS/CSS, Bibliotheken via libman
- appsettings*.json
  - Konfiguration für DB-Verbindung, SharedPath, TempPath, Caching und Umgebung

Die Host-Anwendung ist der Zusammenschnitt aller Module und stellt die Basis für Routing, Authentifizierung, Sicherheit und API-Endpunkte bereit.

### 2. BlazorBp.Core
Das Kern-Framework der Anwendung.

Wichtige Bereiche:

- Base/
  - FormData.cs, Formular.cs, FormularZustand.cs, PageModelBase.cs, TableModelBase.cs, TableRowModelBase.cs, UseCase.cs, SessionExtensions.cs, BlazorComponentBase.cs, DialogTypeEnum.cs
- Components/
  - Controls/ und Layout/ für wiederverwendbare UI-Blöcke
- Modules/
  - IFormModule.cs, MainMenu.cs, MenuEntry.cs
- Core/
  - HttpClientFactory.cs
- CoreModule.cs
  - liefert die allgemeine Container-Konfiguration, CSV-/HTML-Downloads und allgemeine Endpunkte

Ziel dieses Projekts ist die Standardisierung der Formular- und Seitenmechanik. Es bietet die Basis für:

- Menü- und Bereichsdefinitionen
- gemeinsame Formularregistrierung
- Tabellenmodelle mit Paginierung, Sortierung, Zeilenauswahl, Sichtbarkeiten und CSV-Export
- generische Page-/UseCase-Logik
- wiederverwendbare Blazor-Controls

### 3. BlazorBp.Forms
Das eigentliche Fachmodul der Anwendung.

Zentrale Dateien:

- FormsModule.cs
  - definiert `IFormModule`-Implementierung
  - registriert Menüs und Formulare
  - initialisiert DB-Verbindung und Standard-Daten
  - setzt gemeinsame Optionen und Status-Tasks
- Models/
  - domänenspezifische Modelle pro Bereich (`Ag`, `Am`, `En`, `Fz`, `Hh`, `Tb`, `Wp`)
- Components/Pages/
  - Seiten für Mandanten, Benutzer, Kennworteinstellungen, Haushaltsdaten, Wertpapiere und Energie

Die bisherige Modulstruktur umfasst die Bereiche:

- Administrator: Mandanten, Benutzer
- Einstellungen: Kennwort ändern, Einstellungen
- Privat: Tagebuch, Positionen, Notizen, Fahrradstände, Fahrräder, Statistik
- Haushalt: Perioden, Konten, Ereignisse, Buchungen, Abschluss- und Eröffnungsbilanzen
- Wertpapiere: Wertpapiere, Konfigurationen, Chart, Anlagen, Stände
- Energie: Abfrage-Parameter

### 4. BlazorBp.Forms.Demo
Demosystem für UI- und Formularbeispiele.

Wichtige Teile:

- DemoModule.cs
- Pages/Demo/
- Models/Demo/
- Controls/
- Apis/IDemoService.cs, Impl/DemoService.cs

Das Modul dient als Referenz für wiederverwendbare Controls und Formularanwendungen und zeigt die Erweiterbarkeit der Architektur mit zusätzlichen Modulen.

### 5. BlazorBp.Tests
Testprojekt für Validierung und Code-Qualität.

- GladeParserTests.cs
- ModbusTests.cs
- CodeRules/*
- Generator.cs

Diese Tests prüfen Parser- und Code-Qualitätsregeln sowie fachliche Logiken.

### 6. BlazorSpa.Base
Gemeinsame Basisbibliothek mit allgemeinen Daten- und Hilfsfunktionen.

- Csv/*: Reader/Writer für CSV-Verarbeitung
- Models/TableReadModel.cs
- Models/UserDaten.cs
- Services/Message.cs, ServiceErgebnis.cs, MessageException.cs
- Funktionen.cs, Konstanten.cs

Diese Bibliothek liefert Services und Datenstrukturen, die von mehreren Modulen gemeinsam genutzt werden.

## Architekturmuster und Designprinzipien

### Modularer Modul-Container
Die zentrale Architekturrichtlinie ist die `IFormModule`-Schnittstelle.

Jedes Modul kann durch Implementierung dieser Schnittstelle Folgendes bereitstellen:

- `GetMainMenues()`: Menüeinträge und Rollenrechte
- `GetForms()`: Formularregister mit Action-, Area- und Name-Informationen
- `ConfigureBuilder(WebApplicationBuilder)`: Builder-spezifische Initialisierung
- `ConfigureServices(IServiceCollection)`: Service-Registrierung
- `GetFuncCsv()`, `GetFuncHtml()`: Export-/Download-Funktionen

In Program.cs werden alle Module gesammelt und Schritt für Schritt registriert. Dadurch bleibt die Anwendung erweiterbar, ohne die Host-Logik zu verändern.

### Formular- und Seitenarchitektur
Die Formulare basieren auf eigenen Grundklassen:

- `PageModelBase`: Basis für Seiten- und Formular-Modelle
- `TableModelBase<T>`: gemeinsame Tabellenlogik
- `TableRowModelBase`: Datensatzmodell für tabellarische Darstellungen
- `UseCase`: Zustands- und Ablaufmodell eines Formular-Use-Cases
- `Formular`: registrierte Formularmetadaten (Action, Area, Name, Id)
- `BlazorComponentBase`: Grundlage für UI-Komponenten

Diese Klassen bündeln häufige Aufgaben wie:

- Paginierung, Sortierung, Filterung
- Zeilenauswahl und Mehrfachauswahl
- Zugriff auf offene Formulare
- Dialog- und Zustandsverwaltung
- Komponenten-/UI-Funktionen

### App-Host mit zentraler Composition Root
Program.cs ist die Composition Root der Anwendung. Dort werden:

- Module registriert
- Services dem DI-Container hinzugefügt
- Authentifizierung und Autorisierung konfiguriert
- Routing und Blazor-Interaktivität aktiviert
- Swagger, MVC-Controller und Caching initialisiert
- CSP- und Sicherheits-Middleware aktiviert

Damit ist die eigentliche Architektur weniger eine klassische Schichtenarchitektur als eine Composition-orientierte Architektur mit klarer zentraler Zusammenstellung.

## Sicherheitsarchitektur

Die aktuelle Implementierung enthält mehrere Sicherheitsmechanismen:

- Cookie-Authentifizierung mit konfiguriertem Timeout und Session-Handling
- `OnValidatePrincipal` prüft das Principal sowie die Claim-Identität
- `AccessDeniedPath`, `LogoutPath` und Login-Pfad sind gesetzt
- `AddAuthorization` mit Policy `CanadiansOnly`
- `UseAntiforgery()` aktiviert CSRF-Schutz
- `UseHsts()` im Produktionsmodus
- `UseHttpsRedirection()` erzwingt HTTPS
- strenge Content Security Policy (CSP) per Middleware
- Cookie-Sicherheit: Secure, HttpOnly, SameSite Strict

## Caching, Sitzung und Datenhaltung

Die Anwendung verwendet verschiedene Mechanismen:

- Session im Speicher (`AddDistributedMemoryCache` als Standard)
- alternativ SQLite-basierter Cache (`AddSqliteCache`)
- zentrale Session-Timeout-Definition über `BlazorBp.Base.Konstanten.SESSION_TIMEOUT`
- Aufräum-/Statuslogik über `StatusTask.Aufraeumen()`

Die Datenzugriffsschicht setzt auf `CSBP.Services.Factory.FactoryService.ClientService` und eine zentrale Verbindungszeichenfolge (`App:ConnectionString`), nicht auf eine eigene EF-Core-Model-Schicht im Host-Projekt.

## API- und Web-Endpunkte

Die Anwendung bietet zusätzlich zur Blazor-UI mehrere HTTP-/Web-API-Bereiche:

- MVC-Controller: AuthController.cs, WebserviceController.cs
- Minimal-API-Endpunkte für Download-Funktionen (`/downloadcsv/{page}/{id}` und `/downloadhtml/{page}/{id}`)
- `MapControllers()` für MVC-Routing
- Swagger/OpenAPI über `/swagger/v1/swagger.json`

Diese API-Komponenten dienen sowohl der Authentifizierung als auch der Daten-/Datei-Interaktion innerhalb der Formular-Umgebung.

## Datenfluss

Der typische Datenfluss in der Anwendung ist:

1. Benutzer navigiert in der Blazor-UI zu einem Formularbereich.
2. Das Modul registriert das Formular über `IFormModule.GetForms()`.
3. Die Formularseite wird durch das Framework auf Basis von `PageModelBase` und `Formular` aufgebaut.
4. Benutzeraktionen lösen Events und Postbacks aus.
5. UI-State, Formulardaten und Tabelleinträge werden über gemeinsame Modelle verwaltet.
6. Fachlogik wird über Factory-/Service-Objekte ausgeführt.
7. Ergebnisse werden im UI gerendert und bei Bedarf als CSV/HTML exportiert.

## Erweiterbarkeit

Die aktuelle Architektur ist bewusst auf Erweiterbarkeit ausgelegt:

- neue Fachbereiche können als neues `IFormModule` ergänzt werden
- neue Menüs werden in `GetMainMenues()` definiert
- neue Formulare werden in `GetForms()` registriert
- UI-Komponenten und Table-Pattern können wiederverwendet werden
- Seiten und Modelle folgen derselben Basisklassenstruktur

Diese Modularität ist ein zentrales Architekturmerkmal und die wichtigste Grundlage für die vorhandenen Bereiche (Haushalt, Wertpapiere, Energie, Demo).

## Konfigurations- und Deployment-Aspekte

Die Anwendung nutzt konventionelle ASP.NET Core-Konfigurationen:

- `appsettings.json` / `appsettings.Development.json`
- `launchSettings.json`
- libman-basierte Frontend-Bibliotheken im `wwwroot`
- SQL-/DB-Konfiguration über `App:ConnectionString`
- Caching-Konfiguration über `Caching:IsMemoryCache` und `Caching:Sqlite:ConnectionString`

## Fazit

Die aktuelle Implementierung entspricht einem modularen Blazor-Framework mit zentralem Host, einem gemeinsamen Core-Framework und fachlichen Modulen. Die wichtigsten Architekturelemente sind:

- Modulare Zusammensetzung über `IFormModule`
- zentrale Formular- und Tabelle-Logik im Core-Projekt
- fachliche Erweiterung über Module wie `BlazorBp.Forms`
- Sicherheits- und Session-Mechanik direkt im Host
- Datenzugriff über externe Service-/Factory-Schicht statt direktes EF-Core-Model

Diese Struktur macht die Anwendung deutlich erweiterbar, aber gleichzeitig stark an die vorhandene Formular- und Geschäftsanwendungslogik gebunden.