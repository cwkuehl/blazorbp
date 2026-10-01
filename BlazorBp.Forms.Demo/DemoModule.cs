namespace BlazorBp.Forms.Demo;

using BlazorBp.Core.Base;
using BlazorBp.Core.Modules;
using BlazorBp.Forms.Demo.Apis;
using BlazorBp.Forms.Demo.Impl;
using Microsoft.Extensions.DependencyInjection;

public class DemoModule : IFormModule
{
  public string Key => "Demo";

  public int SortOrder => 200;

  public string SubKey => "submenudemo1";

  public string Icon => "bi bi-screwdriver-nav-menu";

  public bool Expanded => false;

  // public IEnumerable<string> RequiredRoles => [UserDaten.RoleAdmin, UserDaten.RoleSuperadmin];
  public IEnumerable<string> RequiredRoles => ["Admin", "Superadmin"];

  public IEnumerable<MenuEntry> GetMenuEntries() =>
  [
    new("SSR", "Statisches Server Side Rendering testen", "/demo/dm010", "bi bi-dot-nav-menu"),
    new("Steuerelemente", "Steuerelemente testen", "/demo/dm100", "bi bi-dot-nav-menu"),
    new("Tabelle", "Tabelle testen", "/demo/dm200", "bi bi-dot-nav-menu"),
  ];

  public void ConfigureServices(IServiceCollection services)
  {
    services.AddSingleton<IDemoService, DemoService>();
  }

  public Dictionary<string, Formular> GetForms()
  {
    return new Dictionary<string, Formular>
    {
      { "DM100", new Formular { Action = "dm100", Area = "demo", Name = "Steuerelemente" } },
      { "DM200", new Formular { Action = "dm200", Area = "demo", Name = "Tabelle" } },
    };
  }
}