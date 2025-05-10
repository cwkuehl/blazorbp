A simple Blazor Web App.
It is planed to insert all functions of my usual Budget Program.

Prototyp mit ASP.NET Blazor Static Server Side Rendering für ASP.NET WebForms.
Folgende Funktionen sind implementiert:
-sehr restriktive CSP-Konfiguration,
-nur minimale JavaScript-Schnipsel zugelassen,
-alle Pakete im wwwroot-Verzeichnis sind per libman eingebunden und jederzeit aktualisierbar,
-Masterpage mit fast reinem Bootstrap,
-d.h. responsive Design und ohne feste Positionierung,
-Sessions im Speicher mit AddDistributedMemoryCache,
-Infobereich, Menü und geöffnete Formulare an der linken Seite,
-Formulare mit Razor Pages,
-Blazor Components für Steuerelemente mit Tooltip, Accesskey, Autopostback, Autofocus sowie horizontalem und vertikalem Layout,
-Blazor Component für Input (Submit-Button, Text, TextArea, Number, Currency, Date, Checkbox, RadioButton, Hidden, Password), Select (Combobox, Listbox), Label,
-Demo-Seite für Button, TextBox, NumberBox, CurrencyBox, DateBox, Checkbox, RadioButton, ComboBox, ListBox,
-Autopostback für Input und Select mit minimalem Javascript realisiert,
-Kurz nach dem Postback werden alle Steuerelemente disabled, um Doppelklicks zu verhindern,
-Felder sperren und verstecken,
-Fehler-Felder markieren,
-Hintergrundfarbe der Steuerelemente lässt sich auswählen,
-Fokus setzen,
-Default-Schaltfläche (mit Javascript und class btn-primary),
-Aufteilung der Formulare in Areas,
-Formular-Manager mit mehreren Use cases für gleiche Formulare und Umschalten dazwischen,
-Anzeige der offenen Use cases mit Schließen-Button,
-Werte im Model speichern, die nicht per Postback aus dem Formular kommen,
-MVC-AuthController für Globale Funktionen,
-Tabellen mit Blättern, Spalten-Sortierung, Filtern, CSV-Export (Datei herunterladen)
-modale Dialoge mit Components,
-Anzeige der Restzeit für den Ablauf der Sitzung und automatische Abmeldung,
-dynamischer Link zu Hilfe-Seite des aktuellen Formulars,
-Drucken des aktuellen Formulars,
-Nachfrage zum Schließen des Tabs, wenn man angemeldet ist,
-Anmeldung mit POST-Request bei WebAPI über MVC-AuthController,
-Nach der Anmeldung wird Query-Parameter ReturnUrl zum Weiterleiten berücksichtigt,
-Lauffähig unter HTTP und HTTPS, konfigurierbar in der appsettings.json,
-Anmeldung mit Mandant, Benutzer-ID und Kennwort,
-Menü mit Rollen-Berechtigungen,
-Datei hochladen,
-Import von CSV-Dateien,
-Service-Schicht mit Repositories per DLL eingebunden,
-Einbinden von Swagger mit Dokumentation der Endpunkte, URL /swagger/v1/swagger.json,
-REST-Schnittstelle mit Daten im JSON-Format statt WebServices,
-Meldungen-Resources in Service-Schicht,
-Meldungen aus Service-Schicht anzeigen,
-Layout-Idee: keine Revisionsdaten im Header, sondern in optionalen Tabellen-Spalten und im Formular,
-Tabelle mit optional einblendbaren Spalten und Speicherung der Einstellungen,

TODO Folgende Funktionen sind noch nicht implementiert:
-dotnet new razorclasslib -o BlazorBp.Components, Vererbung der Component-Klasse,
-Postback mit abhängigen Auswahllisten,
-Undo und Redo in Formularen,
-Meldungen und Entscheidungen,
-TagHelper-Implementierung für Email, File, Time, Bust mit Demo-Seite,
-Meldungen mit Name des fehlerhaften Steuerelements mit automatischer Fehlermarkierung,
-Formulare und Steuerelemente mit Eigenschaften für Barrierefreihet (Accessibility) versehen,

Konzept für Barrierfreihet:
-Screereader-Unterstützung für blinde und sehbehinderte Menschen,
-Textalternativen für Bilder und Multimediainhalte,
-Untertitelung und Transskriptionen für Audio- und Videoinhalte,
-Tastaturbedienbarkeit für Menschen mit eingeschränkter Beweglichkeit (Fokus, Accesskeys, Tabulator-Reihenfolge),
-Farbschemata mit hohem Kontrast für Menschen mit Farbsehschwächen (Standardeinstellungen von Bootstrap, Schriftart Helvetica und alternativ Arial, siehe https://getbootstrap.com/docs/5.3/getting-started/accessibility/),
-ARIA-Roles und ARIA-Attributes (hauptsächlich für modale Dialoge, siehe https://developer.mozilla.org/en-US/docs/Web/Accessibility/ARIA),

Erkenntnisse:
-Autofocus und Script im Formular funktionieren nicht mit Enhanced Navigation: Daher <script src="_framework/blazor.web.js"></script> auskommentiert. siehe auch https://learn.microsoft.com/en-us/aspnet/core/blazor/javascript-interoperability/static-server-rendering?view=aspnetcore-8.0 => Script blazor.web.js wieder aktiviert, site.js wird im MainLayout automatisch eingebunden, und Fokus wird automatisch gesetzt.
-Debug link in Firefox: about:config, browser.link.open_newwindow 1, browser.link.open_newwindow.restriction 0, browser.link.open_newwindow.override.external 3
