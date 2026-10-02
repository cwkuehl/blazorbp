namespace BlazorBp.Forms.Demo;

using System.Text;
using BlazorBp.Core.Base;
using BlazorBp.Core.Modules;
using BlazorBp.Forms.Demo.Apis;
using BlazorBp.Forms.Demo.Impl;
using BlazorBp.Forms.Demo.Pages;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
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

  public void ConfigureApp(WebApplication app)
  {
    app.MapGet("/hello",
      // [Microsoft.AspNetCore.Authorization.Authorize]
      [EndpointSummary("Test API.")]
      [EndpointDescription("Liefert immer 'Hello World'.")]
      () => "Hello World");
    app.MapGet("/demodownloadcsv/{page}/{id}",
      [Microsoft.AspNetCore.Authorization.Authorize]
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
    app.MapGet("/demodownloadhtml/{page}/{id}",
      [Microsoft.AspNetCore.Authorization.Authorize]
    [EndpointSummary("Herunterladen von HTML-Dateien.")]
    [EndpointDescription("Page und ID des Formulars müssen angegeben werden.")]
    (string page, string id, HttpContext context, IServiceProvider sp) =>
    {
      var s = DownloadData.GetHtml(page, id, context, sp);
      if (s != null && s.Length > 0)
        return Results.File(s, "text/html");
      return Results.NotFound();
    });
  }
}