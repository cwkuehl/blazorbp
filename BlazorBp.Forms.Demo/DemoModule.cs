namespace BlazorBp.Forms.Demo;

using BlazorBp.Core.Modules;
using BlazorBp.Forms.Demo.Apis;
using BlazorBp.Forms.Demo.Impl;
using CSBP.Services.Base;
using Microsoft.Extensions.DependencyInjection;

public class DemoModule : IFormModule
{
  public string Key => "Demo";

  public int SortOrder => 200;

  public string SubKey => "submenudemo1";

  public string Icon => "bi bi-screwdriver-nav-menu";

  public bool Expanded => false;

  public IEnumerable<string> RequiredRoles => [UserDaten.RoleAdmin, UserDaten.RoleSuperadmin];

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
}