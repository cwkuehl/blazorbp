namespace BlazorBp.Forms;

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
}