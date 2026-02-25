# Architekturbeschreibung der BlazorBp-Anwendung

## Überblick

BlazorBp ist eine modulare Webanwendung, die auf dem ASP.NET Core Blazor Server-Framework basiert. Die Anwendung folgt einer sauberen Architektur mit getrennten Schichten für Präsentation, Geschäftslogik, Datenverwaltung und Identitätsmanagement. Sie ist für die Verwaltung von Daten in tabellarischer Form optimiert und bietet Funktionen wie Authentifizierung, Autorisierung, Caching und API-Endpunkte.

## Technologiestack

- **Framework**: ASP.NET Core 9.0 mit Blazor Server
- **Sprache**: C# mit Nullable Types und Implicit Usings
- **Datenbank**: SQLite (für Haupt- und Cache-Daten)
- **Authentifizierung**: ASP.NET Core Identity mit Cookie-basierter Authentifizierung
- **Caching**: SQLite-basierte Caching-Option (alternativ In-Memory)
- **API-Dokumentation**: Swagger/OpenAPI
- **Frontend**: Blazor-Komponenten mit Razor-Syntax
- **Styling**: CSS (app.css), Bootstrap (via libman)
- **Build-Tool**: .NET SDK mit dotnet CLI

## Projektstruktur

Die Anwendung ist in mehrere Projekte modularisiert:

### 1. BlazorBp (Hauptprojekt)
Das Kernprojekt der Anwendung, das die Blazor-Komponenten, Seiten und Controller enthält.

**Schlüsselkomponenten:**
- **Program.cs**: Konfiguriert die Anwendung mit Services, Authentifizierung, Middleware und Routing
- **Components/**: Razor-Komponenten für UI-Elemente
  - `App.razor`: Hauptanwendungskomponente
  - `Routes.razor`: Routing-Konfiguration
  - `Auth/`: Authentifizierungs-Komponenten (Signin, Signout)
  - `Controls/`: Wiederverwendbare UI-Komponenten (Header, LabelInputValid, etc.)
  - `Layout/`: Layout-Komponenten
  - `Pages/`: Anwendungsseiten
- **Controllers/**: API-Controller (AuthController, WebserviceController)
- **Models/**: Datenmodelle, organisiert nach Domänen (Ag, Am, Demo, Fz, Tb)
- **Base/**: Basis-Klassen für gemeinsame Funktionalität
  - `TableModelBase<T>`: Basis für tabellarische Datenmodelle mit Paginierung, Sortierung und Suche
  - `PageModelBase`: Basis für Seitenmodelle
  - `BlazorComponentBase`: Basis für Blazor-Komponenten
  - `Formular.cs`, `UseCase.cs`: Geschäftslogik-Basis
- **wwwroot/**: Statische Dateien (CSS, JS, Bilder, Uploads)

**Funktionen:**
- Interaktive Server-Komponenten für dynamische UI
- Session-Management mit konfigurierbarem Timeout
- Content Security Policy (CSP) für Sicherheit
- Swagger-UI für API-Tests
- CSV-Download-Funktionalität

### 2. BlazorBp.Services
Eine Klassenbibliothek für Geschäftslogik und Services.

**Schlüsselkomponenten:**
- **Apis/**: Service-Interfaces (IDemoService)
- **Impl/**: Service-Implementierungen (DemoService)
- **Models/**: Service-spezifische Datenmodelle (Book, Objekt)
- **Base/**: Basis-Service-Klassen

**Funktionen:**
- Abstraktion der Geschäftslogik
- Dependency Injection für lose Kopplung
- Wiederverwendbare Services

### 3. BlazorBp.Tests
Ein Testprojekt für Unit-Tests.

**Schlüsselkomponenten:**
- **GladeParserTests.cs**: Tests für Parser-Funktionalität
- **GlobalUsings.cs**: Globale Using-Direktiven

### 4. Data (Gemeinsam)
Ein Ordner für gemeinsame Datenmodelle und -services außerhalb der Projekte.

## Architekturmuster

### Schichtenarchitektur
Die Anwendung folgt einer klassischen Schichtenarchitektur:

1. **Präsentationsschicht**: Blazor-Komponenten und Razor-Seiten
2. **Anwendungsschicht**: PageModelBase und UseCase-Klassen
3. **Geschäftsschicht**: Services in BlazorBp.Services
4. **Datenschicht**: Entity Framework und SQLite

### Basis-Klassen-Architektur
- **TableModelBase<T>**: Stellt gemeinsame Funktionalität für tabellarische Daten bereit:
  - Paginierung (SelectedPage, PageCount, RowsPerPage)
  - Sortierung (SortColumn)
  - Suche (Search)
  - Zeilenauswahl (SelectedRow, SelectedRows)
  - Spaltensteuerung (VisibleColumns)
- **PageModelBase**: Basis für Seiten mit gemeinsamer Logik
- **BlazorComponentBase**: Erweitert ComponentBase mit zusätzlichen Funktionen

### Dependency Injection
Umfassende Nutzung von DI für:
- Services (IDemoService -> DemoService)
- HttpClient mit Resilience-Policies
- Caching (Memory oder SQLite)
- Authentifizierung und Autorisierung

## Sicherheit

- **Authentifizierung**: Cookie-basierte Authentifizierung mit konfigurierbaren Timeouts
- **Autorisierung**: Policy-basierte Autorisierung (z.B. "CanadiansOnly")
- **CSP**: Strenge Content Security Policy zur Verhinderung von XSS
- **HTTPS**: Erzwingung von HTTPS im Produktionsmodus
- **HSTS**: HTTP Strict Transport Security
- **Anti-Forgery**: CSRF-Schutz für Formulare

## Datenfluss

1. **Benutzerinteraktion**: Blazor-Komponenten erfassen Eingaben
2. **Event-Handling**: Handler-Methoden in PageModels verarbeiten Events
3. **Service-Aufrufe**: Geschäftslogik wird über Services ausgeführt
4. **Datenpersistierung**: Daten werden über Entity Framework in SQLite gespeichert
5. **UI-Updates**: Server-seitige Rendering aktualisiert die UI

## Konfiguration und Deployment

- **appsettings.json**: Umgebungsspezifische Konfiguration
- **launchSettings.json**: Entwicklungsserver-Einstellungen
- **build.sh**: Build-Script für CI/CD
- **Docker-Unterstützung**: Potenziell containerisiert (Dockerfile nicht sichtbar, aber Struktur deutet darauf hin)

## Erweiterbarkeit

Die modulare Struktur ermöglicht einfache Erweiterungen:
- Neue Services können in BlazorBp.Services hinzugefügt werden
- Neue Seiten und Komponenten folgen den Basis-Klassen
- API-Endpunkte können über Controller erweitert werden
- Tests können parallel zur Entwicklung geschrieben werden

## Abhängigkeiten

**Externe Pakete:**
- NeoSmart.Caching.Sqlite.AspNetCore: SQLite-Caching
- Swashbuckle.AspNetCore: API-Dokumentation
- Microsoft.Extensions.Http.Resilience: HTTP-Resilience
- Microsoft.AspNetCore.Identity.*: Identitätsmanagement
- Microsoft.EntityFrameworkCore.*: ORM

**Interne Abhängigkeiten:**
- CSBP.Services: Gemeinsame Service-Bibliothek (externes Projekt)

Diese Architektur bietet eine skalierbare, wartbare und sichere Basis für datenintensive Webanwendungen mit Blazor.