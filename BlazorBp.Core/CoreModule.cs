namespace BlazorBp.Core;

using System.Text;
using BlazorBp.Core.Base;
using BlazorBp.Core.Components.Pages;
using BlazorBp.Core.Modules;
using BlazorSpa.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

public class CoreModule : IFormModule
{
  public IEnumerable<MainMenu> GetMainMenues()
  {
    return new List<MainMenu>
    {
    };
  }
  public void ConfigureServices(IServiceCollection services)
  {
    Funktionen.MachNichts();
  }

  public Dictionary<string, Formular> GetForms()
  {
    return new Dictionary<string, Formular>
    {
    };
  }

  /// <summary>Builder-Konfiguration ergänzen.</summary>
  /// <param name="builder">Betroffener WebApplicationBuilder.</param>
  public void ConfigureBuilder(WebApplicationBuilder builder)
  {
    // Trace = 0, Debug = 1, Information = 2, Warning = 3, Error = 4, Critical = 5, and None = 6.
    builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
  }

  public void ConfigureApp(WebApplication app)
  {
    app.MapGet("/downloadcsv/{page}/{id}",
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
    app.MapGet("/downloadhtml/{page}/{id}",
      [Microsoft.AspNetCore.Authorization.Authorize]
    [EndpointSummary("Herunterladen von HTML-Dateien.")]
    [EndpointDescription("Page und ID des Formulars müssen angegeben werden.")]
    (string page, string id, HttpContext context, IServiceProvider sp) =>
      {
        var s = DownloadData.GetHtml(page, id, context, sp);
        if (s != null && s.Length > 0)
          return Results.File(s, "text/html");
        return Results.NotFound();
      });
  }

  /// <summary>Liefert eine Funktion zum Erzeugen von CSV-Dateien.</summary>
  /// <returns>Funktion zum Erzeugen von CSV-Dateien oder null.</returns>
  public Func<string, string, HttpContext, IServiceProvider, (string?, string?)>? GetFuncCsv()
  {
    return null;
  }

  /// <summary>Liefert eine Funktion zum Erzeugen von HTML-Dateien.</summary>
  /// <returns>Funktion zum Erzeugen von HTML-Dateien oder null.</returns>
  public Func<string, string, HttpContext, IServiceProvider, (byte[]?, string?)>? GetFuncHtml()
  {
    return null;
  }
}
