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
      TableReadModel? rm;
      var service = -1;
      switch (page)
      {
        case "AG100":
          rm = BlazorComponentBaseStatic.ReadFormularTableModel<TableModelBase<AG100TableRowModel>>(s, page, id)?.ReadModel;
          service = 1; // ClientService
          break;
        case "DM200":
          rm = BlazorComponentBaseStatic.ReadFormularTableModel<TableModelBase<DM200TableRowModel>>(s, page, id)?.ReadModel;
          service = 0; // DemoService
          break;
        case "FZ200":
          rm = BlazorComponentBaseStatic.ReadFormularTableModel<TableModelBase<FZ200TableRowModel>>(s, page, id)?.ReadModel;
          service = 2; // PrivateService
          break;
        case "FZ250":
          rm = BlazorComponentBaseStatic.ReadFormularTableModel<TableModelBase<FZ250TableRowModel>>(s, page, id)?.ReadModel;
          service = 2; // PrivateService
          break;
        case "FZ700":
          rm = BlazorComponentBaseStatic.ReadFormularTableModel<TableModelBase<FZ700TableRowModel>>(s, page, id)?.ReadModel;
          service = 2; // PrivateService
          break;
        default:
          rm = null;
          break;
      }
      if (rm != null && service > 0)
      {
        var daten = new ServiceDaten(s.GetUserDaten());
        ServiceErgebnis<string>? r;
        switch (service)
        {
          case 0:
            var csv = ds.GetCsvString(page, rm);
            r = new ServiceErgebnis<string>(csv);
            break;
          case 1:
            r = FactoryService.ClientService.GetCsvString(daten, page, rm);
            break;
          case 2:
            r = FactoryService.PrivateService.GetCsvString(daten, page, rm);
            break;
          default:
            r = null;
            break;
        }
        if (r != null && r.Ok && !string.IsNullOrEmpty(r.Ergebnis))
          return r.Ergebnis;
      }
    }
    var csv0 = $"""
      Seite;Fehler
      {page};CSV-Export nicht implementiert
      """;
    return csv0;
  }
}
