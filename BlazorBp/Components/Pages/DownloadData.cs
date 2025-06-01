// <copyright file="DownloadData.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Components.Pages;

using BlazorBp.Base;
using BlazorBp.Models.Ag;
using BlazorBp.Models.Demo;
using BlazorBp.Models.Fz;
using BlazorBp.Services.Apis;
using CSBP.Services.Base;
using CSBP.Services.Factory;

/// <summary>
/// Komponente zum Lesen der Download-Daten.
/// </summary>
public static class DownloadData
{
  /// <summary>Daten für CSV-Dateien lesen.</summary>
  /// <param name="page">Betroffene Seite, z.B. "AG100".</param>
  /// <param name="id">Betroffene Formular-ID.</param>
  /// <param name="context">Betroffener HttpContext.</param>
  /// <param name="sp">Betroffener IServiceProvider.</param>
  /// <returns>CSV-String oder null.</returns>
  public static string? GetCsv(string page, string id, HttpContext context, IServiceProvider sp)
  {
    var ds = sp.GetService<IDemoService>();
    var s = context?.Session;
    if (!string.IsNullOrEmpty(page) && !string.IsNullOrEmpty(id) && ds != null && s != null)
    {
      page = page.ToUpper();
      if (page == "AG100")
      {
        var m = BlazorComponentBaseStatic.ReadFormularTableModel<TableModelBase<AG100TableRowModel>>(s, page, id);
        if (m != null)
        {
          var daten = new ServiceDaten(s.GetUserDaten());
          var r = FactoryService.ClientService.GetCsvString(daten, page, m.ReadModel);
          if (r.Ok)
            return r.Ergebnis;
        }
      }
      else if (page == "DM200")
      {
        var m = BlazorComponentBaseStatic.ReadFormularTableModel<TableModelBase<DM200TableRowModel>>(s, page, id);
        if (m != null)
        {
          var csv = ds.GetCsvString(page, m.ReadModel);
          return csv;
        }
      }
      else if (page == "FZ700")
      {
        var m = BlazorComponentBaseStatic.ReadFormularTableModel<TableModelBase<FZ700TableRowModel>>(s, page, id);
        if (m != null)
        {
          var daten = new ServiceDaten(s.GetUserDaten());
          var r = FactoryService.PrivateService.GetCsvString(daten, page, m.ReadModel);
          if (r.Ok)
            return r.Ergebnis;
        }
      }
    }
    var csv0 = $"""
      Seite;Fehler
      {page};CSV-Export nicht implementiert
      """;
    return csv0;
  }
}
