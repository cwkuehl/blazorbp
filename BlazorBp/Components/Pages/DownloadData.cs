// <copyright file="DownloadData.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Components.Pages;

using BlazorBp.Base;
using BlazorBp.Models.Ag;
using BlazorBp.Models.Am;
using BlazorBp.Models.Demo;
using BlazorBp.Models.Fz;
using BlazorBp.Models.Tb;
using BlazorBp.Models.Wp;
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
      var daten = new ServiceDaten(s.GetUserDaten());
      ServiceErgebnis<string>? r = null;
      switch (page)
      {
        case "AG100":
        {
          var rm = BlazorComponentBaseStatic.ReadFormularTableModel<TableModelBase<AG100TableRowModel>>(s, page, id)?.ReadModel;
          r = FactoryService.ClientService.GetCsvString(daten, page, rm);
          break;
        }
        case "AG200":
        {
          var rm = BlazorComponentBaseStatic.ReadFormularTableModel<TableModelBase<AG200TableRowModel>>(s, page, id)?.ReadModel;
          r = FactoryService.ClientService.GetCsvString(daten, page, rm);
          break;
        }
        case "AM500":
        {
          var rm = BlazorComponentBaseStatic.ReadFormularTableModel<TableModelBase<AM500TableRowModel>>(s, page, id)?.ReadModel;
          r = FactoryService.ClientService.GetCsvString(daten, page, rm);
          break;
        }
        case "DM200":
        {
          var rm = BlazorComponentBaseStatic.ReadFormularTableModel<TableModelBase<DM200TableRowModel>>(s, page, id)?.ReadModel;
          var csv = ds.GetCsvString(page, rm);
          r = new ServiceErgebnis<string>(csv);
          break;
        }
        case "FZ200":
        {
          var rm = BlazorComponentBaseStatic.ReadFormularTableModel<TableModelBase<FZ200TableRowModel>>(s, page, id)?.ReadModel;
          r = FactoryService.PrivateService.GetCsvString(daten, page, rm);
          break;
        }
        case "FZ250":
        {
          var rm = BlazorComponentBaseStatic.ReadFormularTableModel<TableModelBase<FZ250TableRowModel>>(s, page, id)?.ReadModel;
          r = FactoryService.PrivateService.GetCsvString(daten, page, rm);
          break;
        }
        case "FZ700":
        {
          var rm = BlazorComponentBaseStatic.ReadFormularTableModel<TableModelBase<FZ700TableRowModel>>(s, page, id)?.ReadModel;
          r = FactoryService.PrivateService.GetCsvString(daten, page, rm);
          break;
        }
        case "TB100":
        {
          var pm = BlazorComponentBaseStatic.ReadFormularFormModel<TB100Model>(s, page, id);
          var r2 = pm == null ? null : FactoryService.DiaryService.GetDiaryReport(daten, pm.GetSearchArray(), pm.Position2, pm.From, pm.To);
          if (r2 != null && r2.Ok && r2.Ergebnis != null)
          {
            var csv2 = string.Join(Environment.NewLine, r2.Ergebnis);
            r = new ServiceErgebnis<string>(csv2);
          }
          break;
        }
        case "TB200":
        {
          var rm = BlazorComponentBaseStatic.ReadFormularTableModel<TableModelBase<TB200TableRowModel>>(s, page, id)?.ReadModel;
          r = FactoryService.DiaryService.GetCsvString(daten, page, rm);
          break;
        }
        case "WP200":
        {
          var rm = BlazorComponentBaseStatic.ReadFormularTableModel<TableModelBase<WP200TableRowModel>>(s, page, id)?.ReadModel;
          r = FactoryService.StockService.GetCsvString(daten, page, rm);
          break;
        }
        default:
          break;
      }
      if (r != null && r.Ok && !string.IsNullOrEmpty(r.Ergebnis))
        return r.Ergebnis;
    }
    var csv0 = $"""
      Seite;Fehler
      {page};CSV-Export nicht implementiert
      """;
    return csv0;
  }
}
