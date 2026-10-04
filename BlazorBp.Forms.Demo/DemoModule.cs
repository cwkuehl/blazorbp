namespace BlazorBp.Forms.Demo;

using System.Text;
using BlazorBp.Core.Base;
using BlazorBp.Core.Modules;
using BlazorBp.Forms.Demo.Apis;
using BlazorBp.Forms.Demo.Impl;
using BlazorBp.Forms.Demo.Pages;
using BlazorSpa.Base.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

public class DemoModule : IFormModule
{
  public IEnumerable<MainMenu> GetMainMenues()
  {
    return new List<MainMenu>
    {
      new MainMenu("Demo", 200, "submenudemo1", "bi bi-screwdriver-nav-menu", false, [UserDaten.RoleAdmin, UserDaten.RoleSuperadmin], [
        new("SSR", "Statisches Server Side Rendering testen", "/demo/dm010", "bi bi-dot-nav-menu"),
        new("Steuerelemente", "Steuerelemente testen", "/demo/dm100", "bi bi-dot-nav-menu"),
        new("Tabelle", "Tabelle testen", "/demo/dm200", "bi bi-dot-nav-menu"),
      ]),
    };
  }

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

  /// <summary>Builder-Konfiguration ergänzen.</summary>
  /// <param name="builder">Betroffener WebApplicationBuilder.</param>
  public void ConfigureBuilder(WebApplicationBuilder builder)
  {
  }

  public void ConfigureApp(WebApplication app)
  {
    app.MapGet("/hello",
      // [Microsoft.AspNetCore.Authorization.Authorize]
      [EndpointSummary("Test API.")]
    [EndpointDescription("Liefert immer 'Hello World'.")]
    () => "Hello World");
  }

  /// <summary>Liefert eine Funktion zum Erzeugen von CSV-Dateien.</summary>
  /// <returns>Funktion zum Erzeugen von CSV-Dateien.</returns>
  public Func<string, string, HttpContext, IServiceProvider, (string?, string?)> GetFuncCsv()
  {
    return DownloadData.GetCsv;
  }

  /// <summary>Liefert eine Funktion zum Erzeugen von HTML-Dateien.</summary>
  /// <returns>Funktion zum Erzeugen von HTML-Dateien.</returns>
  public Func<string, string, HttpContext, IServiceProvider, (byte[]?, string?)> GetFuncHtml()
  {
    return DownloadData.GetHtml;
  }
}