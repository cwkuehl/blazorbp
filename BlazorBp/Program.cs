// <copyright file="Program.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

using System.Reflection;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using BlazorBp.Base;
using BlazorBp.Components; // für App
using BlazorBp.Components.Pages;
using BlazorBp.Services.Apis;
using BlazorBp.Services.Impl;
using CSBP.Services.Factory;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using NeoSmart.Caching.Sqlite.AspNetCore;

var interactive = Konstanten.Interactive;
var builder = WebApplication.CreateBuilder(args);

// Trace = 0, Debug = 1, Information = 2, Warning = 3, Error = 4, Critical = 5, and None = 6.
builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));

var connect = builder.Configuration["App:ConnectionString"] ?? "Data Source=blazorbp.db";
CSBP.Services.Base.Parameter.Connect = connect;
var daten = new CSBP.Services.Base.ServiceDaten("0", 1, "Administrator", null);
var r1 = FactoryService.ClientService.InitDb(daten);
r1.ThrowAllErrors("InitDb");
var r2 = FactoryService.ClientService.GetOptionList(daten, daten.MandantNr, CSBP.Services.Base.Parameter.Params, null);
r2.ThrowAllErrors("GetOptionList");

// Add services to the container.
if (interactive || true)
  // true wegen InvalidOperationException: Cannot provide a value for property 'AuthenticationStateProvider' on type 'Microsoft.AspNetCore.Components.Authorization.CascadingAuthenticationState'. There is no registered service of type 'Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider'.
  builder.Services.AddRazorComponents(options => options.DetailedErrors = builder.Environment.IsDevelopment()).AddInteractiveServerComponents();
else
  builder.Services.AddRazorComponents(options => options.DetailedErrors = builder.Environment.IsDevelopment());

if (!builder.Environment.IsDevelopment())
{
  builder.Services.AddHsts(options => {
    options.Preload = true;
    options.MaxAge = TimeSpan.FromDays(365);
    options.IncludeSubDomains = true;
  });
}
builder.Services.AddAuthentication(o => {
  o.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
  .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o => {
    o.LoginPath = "/";
    o.ExpireTimeSpan = TimeSpan.FromSeconds(Konstanten.SESSION_TIMEOUT);
    o.Cookie.MaxAge = o.ExpireTimeSpan;
    o.SlidingExpiration = true;
    o.LogoutPath = "/auth/logout";
    o.AccessDeniedPath = "/auth/login";
    o.Cookie.Name = "BlazorBpCookie";
    o.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    o.Cookie.SameSite = SameSiteMode.Strict;
    o.Events = new CookieAuthenticationEvents {
      OnValidatePrincipal = context => {
        if (context.Principal?.Identity is ClaimsIdentity identity && identity.IsAuthenticated) {
          var claims = context.Principal?.Claims;
          if (claims == null)
          {
            context.RejectPrincipal();
            return context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
          }
          else
          {
            var sid = claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid);
            var sidValue = sid?.Value;
            if (sidValue != Konstanten.CLAIM_SID)
            {
              context.RejectPrincipal();
              return context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
          }
          identity.AddClaim(new Claim("foo", "bar"));
        }
        return Task.CompletedTask;
      }
    };
  });
builder.Services.AddAuthorization(options =>
{
  options.AddPolicy("CanadiansOnly", policy => policy.RequireClaim(ClaimTypes.Country, "Canada"));
});
builder.Services.AddEndpointsApiExplorer(); // Entdeckt MapGet-Endpunkte.
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new() { Title = "BlazorBp", Version = "v1" });
  var fn = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
  c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, fn));
});
builder.Services.AddControllers(); // Add MVC with controllers.
var ismem = builder.Configuration["Caching:IsMemoryCache"] ?? "True";
if (ismem == "True")
  builder.Services.AddDistributedMemoryCache();
else
{
  var cachefile = builder.Configuration["Caching:Sqlite:ConnectionString"] ?? "cache.db";
  builder.Services.AddSqliteCache(options => {
    options.CachePath = cachefile;
  });
}
// Alternativ mit SQL Server: Package Microsoft.Extensions.Caching.SqlServer v8.0.8
// builder.Services.AddDistributedSqlServerCache(options =>
// {
//     options.ConnectionString = builder.Configuration.GetConnectionString(
//         "DistCache_ConnectionString");
//     options.SchemaName = "dbo";
//     options.TableName = "TestCache";
// });
builder.Services.AddSession();

builder.Services.AddSingleton<IDemoService, DemoService>();
builder.Services.AddHttpClient("HttpClientWithSSLUntrusted").ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
  ClientCertificateOptions = ClientCertificateOption.Manual,
  ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => { return true; },
  SslProtocols = SslProtocols.Tls13,
});
builder.Services.AddFactoryService();

var app = builder.Build();
app.UseFactoryService();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error", createScopeForErrors: true);
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  // app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();
app.UseStatusCodePagesWithReExecute("/StatusCode/{0}");
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();
app.MapControllers();

if (interactive)
  app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
else
  app.MapRazorComponents<App>();

app.Use(async (context, next) =>
{
  // const string POLICY = "script-src 'nonce-{RANDOM}' 'strict-dynamic'; object-src 'none'; base-uri 'none';"; // Nonce-based Strict Policy
  // const string POLICY = "script-src 'sha256-{HASHED_INLINE_SCRIPT}' 'strict-dynamic'; object-src 'none'; base-uri 'none'; report-to /_/csp-reports"; // Hash-based Strict Policy
  // const string POLICY = "default-src 'self'; frame-ancestors 'self'; form-action 'self';"; // The most basic policy
  // const string POLICY = "default-src 'none'; script-src 'self'; connect-src 'self'; img-src 'self'; style-src 'self'; frame-ancestors 'self'; form-action 'self';"; // To tighten further
  if (0 == 0)
  {
    const string POLICY = "default-src 'self'; script-src 'self' 'unsafe-hashes' 'sha256-CUqQNXXMRfh20wSHsbWzap8G4U55uWVlFrnrwSqnd10=' 'sha256-aV5tqRL+qWGkuS9LFLVv5WMI1ldktz5yzpz7ftN2I5k='; img-src 'self' data:; form-action 'self'; frame-ancestors 'none';"; // To prevent all framing of your content
    // const string POLICY = "default-src 'self'; script-src 'self' 'unsafe-hashes' 'sha256-fa0BfrkfoHWYWTFJg9cIEoVa6Mn3OUorfpaz+NXuHCI=' 'sha256-RFWPLDbv2BY+rCkDzsE+0fr8ylGr2R2faWMhq4lfEQc='; connect-src 'self'; img-src 'self' data:; style-src 'self'; form-action 'self'; frame-ancestors 'none';"; // To prevent all framing of your content
    // const string POLICY = "default-src 'self'; script-src 'self' 'unsafe-inline' 'unsafe-eval'; connect-src 'self'; img-src 'self'; style-src 'self'; form-action 'self'; frame-ancestors 'none';";
    // script-src 'unsafe-inline' 'unsafe-eval' for ajax
    // img-src 'self' data: for bootstrap images
    // script-src 'self' 'unsafe-hashes' 'sha256-fa0BfrkfoHWYWTFJg9cIEoVa6Mn3OUorfpaz+NXuHCI=' for hallo();
    // echo -e -n "submitc(\x24(this));" | openssl sha256 -binary | openssl base64
    // Bringt andere Hashes: openssl dgst -sha3-256 -binary file.js | openssl base64 -A
    // 'sha256-ePniVEkSivX/c7XWBGafqh8tSpiRrKiqYeqbG7N1TOE=' document.forms[0].submit()
    // 'sha256-gn6SvwkOt5ByZ8z2lZtOcIQopPyjkBUNz7EbU50dwb8=' submitControl($(this).attr('id'),'form1');
    // 'sha256-JINyXuiE90RdGlUFK8DM5WNxzknp65BaeVE4VuderpY=' submitControl($(this).attr('id'),'formt');
    // 'sha256-CUqQNXXMRfh20wSHsbWzap8G4U55uWVlFrnrwSqnd10=' submitc($(this));
    // 'sha256-aV5tqRL+qWGkuS9LFLVv5WMI1ldktz5yzpz7ftN2I5k=' alert('Hallo'); <script>alert('Hallo');</script>
    context.Response.Headers.Append("Content-Security-Policy", $"{POLICY}");
    // Verhindern von MIME-Typ-Sniffing.
    context.Response.Headers.Append("X-Content-Type-Options", "nosniff");
    // Verhindern von Clickjacking.
    context.Response.Headers.Append("X-Frame-Options", "DENY");
    // Aktivieren von XSS-Schutz.
    context.Response.Headers.Append("X-XSS-Protection", "1; mode=block");
  }
  await next();
});
app.UseCookiePolicy(new CookiePolicyOptions
{
  Secure = CookieSecurePolicy.Always,
  HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always
});
app.UseSession();

app.MapGet("/hello",
  [EndpointSummary("Test API.")]
  [EndpointDescription("Liefert immer 'Hello World'.")]
  () => "Hello World");
app.MapGet("/download/{page}/{id}",
  [EndpointSummary("Herunterladen von CSV-Dateien.")]
  [EndpointDescription("Page und ID des Formulars müssen angegeben werden.")]
  (string page, string id, HttpContext context, IServiceProvider sp) =>
{
  // var cs = sp.GetService<IClientService>();
  var s = DownloadData.GetCsv(page, id, context, sp);
  if (!string.IsNullOrEmpty(s))
    return Results.Text(s, "text/csv", Encoding.UTF8);
  return Results.NotFound();
});

// app.UseStaticFiles(new StaticFileOptions()
// {
//   // Add the other folder, using the Content Root as the base
//   FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "wwwroot/help"))
// });

app.UseSwagger();
app.UseSwaggerUI(c =>
{
  // Aufruf mit /swagger
  c.SwaggerEndpoint("v1/swagger.json", "BlazorBp API V1");
  // Bei app.UseSwaggerUI funktioniert automatische Abmeldung mit /auth/logout nicht, wenn RoutePrefix nicht gesetzt ist.
  c.RoutePrefix = "swagger";
});

app.Run();

/*

dotnet new sln -o blazorbp
dotnet new blazor --auth Individual -o BlazorBp
dotnet new classlib -o BlazorBp.Services
dotnet new xunit -o BlazorBp.Tests
dotnet sln blazorbp.sln add ./BlazorBp/BlazorBp.csproj ./BlazorBp.Services/BlazorBp.Services.csproj ./BlazorBp.Tests/BlazorBp.Tests.csproj
dotnet add ./BlazorBp/BlazorBp.csproj reference ./BlazorBp.Services/BlazorBp.Services.csproj
dotnet add ./BlazorBp.Tests/BlazorBp.Tests.csproj reference ./BlazorBp.Services/BlazorBp.Services.csproj
dotnet ef database update
update AspNetUsers set EmailConfirmed=1;
Projekt BlazorBp in BlazorBp.Identity umbenannt.
dotnet new blazor -o BlazorBp
dotnet add ./BlazorBp/BlazorBp.csproj reference ./BlazorBp.Services/BlazorBp.Services.csproj
dotnet sln blazorbp.sln add ./BlazorBp/BlazorBp.csproj
dotnet add package NeoSmart.Caching.Sqlite.AspNetCore

Services.dll hinzufügen:
dotnet sln add ../csbp/CSBP.Services/CSBP.Services.csproj
dotnet add ./BlazorBp/BlazorBp.csproj reference ../csbp/CSBP.Services/CSBP.Services.csproj
dotnet add ./BlazorBp.Services/BlazorBp.Services.csproj reference ../csbp/CSBP.Services/CSBP.Services.csproj

Authorisierung mit Cookies: https://www.youtube.com/watch?v=B3zvX_CWKVc

Swagger für Endpoints:
dotnet add package Swashbuckle.AspNetCore

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

*/
