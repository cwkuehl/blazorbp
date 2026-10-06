namespace BlazorBp.Forms;

using System.Text;
using BlazorBp.Core.Base;
using BlazorBp.Core.Modules;
using BlazorBp.Forms.Components.Pages;
using BlazorSpa.Base;
using BlazorSpa.Base.Models;
using CSBP.Services.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

public class FormsModule : IFormModule
{
  public IEnumerable<MainMenu> GetMainMenues()
  {
    return new List<MainMenu>
    {
      new MainMenu("Administrator", 100, "submenufile", "bi bi-file-nav-menu", false, [UserDaten.RoleAdmin, UserDaten.RoleSuperadmin], [
        new("Mandanten", "Mandanten bearbeiten", "/ag/ag100", "bi bi-dot-nav-menu"),
        new("Benutzer", "Benutzer bearbeiten", "/ag/ag200", "bi bi-dot-nav-menu"),
      ]),
      new MainMenu("Einstellungen", 110, "submenuuser", "bi bi-person-nav-menu", false, [], [
        new("Kennwort ändern", "Kennwort ändern", "/am/am100", "bi bi-dot-nav-menu"),
        new("Einstellungen", "Einstellungen bearbeiten", "/am/am500", "bi bi-dot-nav-menu"),
      ]),
      new MainMenu("Privat", 120, "submenuprivate", "bi bi-person-nav-menu", true, [], [
        new("Tagebuch", "Tagebuch", "/tb/tb100", "bi bi-dot-nav-menu"),
        new("Positionen", "Positionen bearbeiten", "/tb/tb200", "bi bi-dot-nav-menu"),
        new("Notizen", "Notizen bearbeiten", "/fz/fz700", "bi bi-dot-nav-menu"),
        new("Fahrradstände", "Fahrradstände bearbeiten", "/fz/fz250", "bi bi-dot-nav-menu"),
        new("Fahrräder", "Fahrräder bearbeiten", "/fz/fz200", "bi bi-dot-nav-menu"),
        new("Statistik", "Statistik", "/fz/fz100", "bi bi-dot-nav-menu"),
      ]),
      new MainMenu("Haushalt", 130, "submenubudget", "bi bi-person-nav-menu", true, [], [
        new("Perioden", "Perioden bearbeiten", "/hh/hh100", "bi bi-dot-nav-menu"),
        new("Konten", "Konten bearbeiten", "/hh/hh200", "bi bi-dot-nav-menu"),
        new("Ereignisse", "Ereignisse bearbeiten", "/hh/hh300", "bi bi-dot-nav-menu"),
        new("Buchungen", "Buchungen bearbeiten", "/hh/hh400", "bi bi-dot-nav-menu"),
        new("Schlussbilanz", "Schlussbilanz", "/hh/hh500/SB", "bi bi-dot-nav-menu"),
        new("G+V-Rechnung", "G+V-Rechnung", "/hh/hh500/GV", "bi bi-dot-nav-menu"),
        new("Eröffnungsbilanz", "Eröffnungsbilanz", "/hh/hh500/EB", "bi bi-dot-nav-menu"),
      ]),
      new MainMenu("Wertpapiere", 140, "submenustocks", "bi bi-person-nav-menu", true, [], [
        new("Wertpapiere", "Wertpapiere bearbeiten", "/wp/wp200", "bi bi-dot-nav-menu"),
        new("Konfigurationen", "Konfigurationen bearbeiten", "/wp/wp300", "bi bi-dot-nav-menu"),
        new("Wertpapier-Chart", "Wertpapier-Chart", "/wp/wp100", "bi bi-dot-nav-menu"),
        new("Anlagen", "Anlagen bearbeiten", "/wp/wp250", "bi bi-dot-nav-menu"),
        new("Stände", "Stände bearbeiten", "/wp/wp500", "bi bi-dot-nav-menu"),
      ]),
      new MainMenu("Energie", 150, "submenuenergy", "bi bi-person-nav-menu", true, [], [
        new("Abfrage-Parameter", "Abfrage-Parameter bearbeiten", "/en/en100", "bi bi-dot-nav-menu"),
      ]),
    };
  }
  public void ConfigureServices(IServiceCollection services)
  {
    // services.AddSingleton<IDemoService, DemoService>();
    Funktionen.MachNichts();
  }

  public Dictionary<string, Formular> GetForms()
  {
    return new Dictionary<string, Formular>
    {
      { "AG100", new Formular { Action = "ag100", Area = "ag", Name = "Mandanten" } },
      // { "AG110", new Formular { Action = "ag110", Area = "ag", Name = "Mandant" } },
      { "AG200", new Formular { Action = "ag200", Area = "ag", Name = "Benutzer" } },
      { "AM100", new Formular { Action = "am100", Area = "am", Name = "Kennwort ändern" } },
      { "AM500", new Formular { Action = "am500", Area = "am", Name = "Einstellungen" } },
      { "EN100", new Formular { Action = "en100", Area = "en", Name = "Abfrage-Parameter" } },
      { "FZ100", new Formular { Action = "fz100", Area = "fz", Name = "Statistik" } },
      { "FZ200", new Formular { Action = "fz200", Area = "fz", Name = "Fahrräder" } },
      { "FZ250", new Formular { Action = "fz250", Area = "fz", Name = "Fahrradstände" } },
      { "FZ700", new Formular { Action = "fz700", Area = "fz", Name = "Notizen" } },
      { "HH100", new Formular { Action = "hh100", Area = "hh", Name = "Perioden" } },
      { "HH200", new Formular { Action = "hh200", Area = "hh", Name = "Konten" } },
      { "HH210", new Formular { Action = "hh210", Area = "hh", Name = "Konto" } },
      { "HH300", new Formular { Action = "hh300", Area = "hh", Name = "Ereignisse" } },
      { "HH310", new Formular { Action = "hh310", Area = "hh", Name = "Ereignis" } },
      { "HH400", new Formular { Action = "hh400", Area = "hh", Name = "Buchungen" } },
      { "HH410", new Formular { Action = "hh410", Area = "hh", Name = "Buchung" } },
      // { "HH500" + Constants.KZBI_SCHLUSS, new Formular { Action = "hh500", Area = "hh", Name = HH500_title_SB, Id = Constants.KZBI_SCHLUSS } },
      // { "HH500" + Constants.KZBI_GV, new Formular { Action = "hh500", Area = "hh", Name = HH500_title_GV, Id = Constants.KZBI_GV } },
      // { "HH500" + Constants.KZBI_EROEFFNUNG, new Formular { Action = "hh500", Area = "hh", Name = HH500_title_EB, Id = Constants.KZBI_EROEFFNUNG } },
      { "HH500SB", new Formular { Action = "hh500", Area = "hh", Name = "Schlussbilanz", Id = "SB" } },
      { "HH500GV", new Formular { Action = "hh500", Area = "hh", Name = "G+V-Rechnung", Id = "GV" } },
      { "HH500EB", new Formular { Action = "hh500", Area = "hh", Name = "Eröffnungsbilanz", Id = "EB" } },
      { "HH510", new Formular { Action = "hh510", Area = "hh", Name = "Drucken" } },
      { "TB100", new Formular { Action = "tb100", Area = "tb", Name = "Tagebuch" } },
      { "TB200", new Formular { Action = "tb200", Area = "tb", Name = "Positionen" } },
      { "WP100", new Formular { Action = "wp100", Area = "wp", Name = "Wertpapier-Chart" } },
      { "WP200", new Formular { Action = "wp200", Area = "wp", Name = "Wertpapiere" } },
      { "WP210", new Formular { Action = "wp210", Area = "wp", Name = "Wertpapier" } },
      { "WP250", new Formular { Action = "wp250", Area = "wp", Name = "Anlagen" } },
      { "WP260", new Formular { Action = "wp260", Area = "wp", Name = "Anlage" } },
      { "WP300", new Formular { Action = "wp300", Area = "wp", Name = "Konfigurationen" } },
      { "WP500", new Formular { Action = "wp500", Area = "wp", Name = "Stände" } },
      { "WP510", new Formular { Action = "wp510", Area = "wp", Name = "Stand" } },
    };
  }

  /// <summary>Builder-Konfiguration ergänzen.</summary>
  /// <param name="builder">Betroffener WebApplicationBuilder.</param>
  public void ConfigureBuilder(WebApplicationBuilder builder)
  {
    var connect = builder.Configuration["App:ConnectionString"] ?? "Data Source=blazorbp.db";
    CSBP.Services.Base.Parameter.Connect = connect;
    var daten = new CSBP.Services.Base.ServiceDaten("0", 1, "Administrator", null);
    var r1 = CSBP.Services.Factory.FactoryService.ClientService.InitDb(daten);
    r1.ThrowAllErrors("InitDb");
    var r2 = CSBP.Services.Factory.FactoryService.ClientService.GetOptionList(daten, daten.MandantNr, CSBP.Services.Base.Parameter.Params, null);
    r2.ThrowAllErrors("GetOptionList");
    var sharedpath = builder.Configuration["App:SharedPath"].TrimNull();
    var temppath = builder.Configuration["App:TempPath"].TrimNull();
    CSBP.Services.Base.CsbpBase.SetValues(sharedpath, temppath);
    CSBP.Services.Base.StatusTask.Aufraeumen();
  }

  public void ConfigureApp(WebApplication app)
  {
    app.MapGet("/statustask/{name}",
      [EndpointSummary("Abrufen des Status asynchroner, länger laufender Aufgaben.")]
    [EndpointDescription("Name der Aufgabe muss angegeben werden.")]
    (string name, HttpContext context, IServiceProvider sp) =>
    {
      var s = context?.Session;
      if (string.IsNullOrEmpty(name) || s?.GetUserDaten() == null)
        return Results.BadRequest();
      var daten = new ServiceDaten(s.GetUserDaten());
      var status = StatusTask.GetStatus(daten.MandantNr, [name], true);
      return Results.Text(status, "text/plain; charset=utf-8");
    });
  }

  /// <summary>Liefert eine Funktion zum Erzeugen von CSV-Dateien.</summary>
  /// <returns>Funktion zum Erzeugen von CSV-Dateien oder null.</returns>
  public Func<string, string, HttpContext, IServiceProvider, (string?, string?)>? GetFuncCsv()
  {
    return DownloadData.GetCsv;
  }

  /// <summary>Liefert eine Funktion zum Erzeugen von HTML-Dateien.</summary>
  /// <returns>Funktion zum Erzeugen von HTML-Dateien oder null.</returns>
  public Func<string, string, HttpContext, IServiceProvider, (byte[]?, string?)>? GetFuncHtml()
  {
    return DownloadData.GetHtml;
  }

  /// <summary>Liefert eine Funktion zum Starten von Aufgaben.</summary>
  /// <returns>Funktion zum Starten von Aufgaben oder null.</returns>
  public Func<string, string, HttpContext, IServiceProvider, (bool, string?)>? GetFuncStartTask()
  {
    return StartTask.Do;
  }
}
