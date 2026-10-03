// <copyright file="ProgramCore.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Core;

using System.Text;
using BlazorBp.Core.Components.Pages;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

public static class ProgramCore
{
  /// <summary>Hauptprogramm.</summary>
  /// <param name="app">Die Webanwendung.</param>
  public static void ConfigureApp(WebApplication app)
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
}
