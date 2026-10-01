namespace BlazorBp.Forms;

using BlazorBp.Core.Base;
using BlazorBp.Core.Modules;
using BlazorSpa.Base;
using Microsoft.Extensions.DependencyInjection;

public class FormsModule : IFormModule
{
  public string Key => "Administrator";

  public int SortOrder => 100;

  public string SubKey => "submenufile";

  public string Icon => "bi bi-file-nav-menu";

  public bool Expanded => false;

  // public IEnumerable<string> RequiredRoles => [UserDaten.RoleAdmin, UserDaten.RoleSuperadmin];
  public IEnumerable<string> RequiredRoles => ["Admin", "Superadmin"];

  public IEnumerable<MenuEntry> GetMenuEntries() =>
  [
    new("Mandanten", "Mandanten bearbeiten", "/ag/ag100", "bi bi-dot-nav-menu"),
    new("Benutzer", "Benutzer bearbeiten", "/ag/ag200", "bi bi-dot-nav-menu"),
  ];

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
}