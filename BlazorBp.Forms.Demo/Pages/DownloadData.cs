// <copyright file="DownloadData.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Forms.Demo.Pages;

using System.Text;
using BlazorBp.Core.Base;
using BlazorBp.Forms.Demo.Apis;
using BlazorBp.Forms.Demo.Models.Demo;
using BlazorSpa.Base.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

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
    string? fehler = null;
    if (!string.IsNullOrEmpty(page) && !string.IsNullOrEmpty(id) && ds != null && s != null)
    {
      page = page.ToUpper();
      ServiceErgebnis<string>? r = null;
      switch (page)
      {
        case "DM200":
        {
          var rm = BlazorComponentBaseStatic.ReadFormularTableModel<TableModelBase<DM200TableRowModel>>(s, page, id)?.ReadModel;
          var csv = ds.GetCsvString(page, rm);
          r = new ServiceErgebnis<string>(csv);
          break;
        }
        default:
          break;
      }
      if (r != null && r.Ok && !string.IsNullOrEmpty(r.Ergebnis))
      {
        if (r.Ok && !string.IsNullOrEmpty(r.Ergebnis))
          return r.Ergebnis;
        else
          fehler = r.GetErrors();
      }
    }
    var csv0 = $"""
      Seite;Fehler
      {page};{fehler ?? "CSV-Export nicht implementiert"}
      """;
    return csv0;
  }

  /// <summary>Daten für HTML-Dateien lesen.</summary>
  /// <param name="page">Betroffene Seite, z.B. "AG100".</param>
  /// <param name="id">Betroffene Formular-ID.</param>
  /// <param name="context">Betroffener HttpContext.</param>
  /// <param name="sp">Betroffener IServiceProvider.</param>
  /// <returns>Byte-Array oder null.</returns>
  public static byte[]? GetHtml(string page, string id, HttpContext context, IServiceProvider sp)
  {
    var s = context?.Session;
    string? fehler = null;
    if (!string.IsNullOrEmpty(page) && !string.IsNullOrEmpty(id) && s != null)
    {
      page = page.ToUpper();
      ServiceErgebnis<byte[]>? r = null;
      switch (page)
      {
        // case "HH510BL":
        // {
        //   var pm = BlazorComponentBaseStatic.ReadFormularFormModel<HH510Model>(s, "HH510", id);
        //   if (pm != null)
        //   {
        //     r = FactoryService.BudgetService.GetAnnualReport(daten, pm.Von ?? daten.Heute, pm.Bis ?? daten.Heute, pm.Titel, pm.Eb, pm.Gv, pm.Sb);
        //   }
        //   break;
        // }
        default:
          break;
      }
      if (r != null)
      {
        if (r.Ok && r.Ergebnis != null)
          return r.Ergebnis;
        fehler = r.GetErrors();
      }
    }
    var s0 = $"""
      Seite;Fehler
      {page};{fehler ?? "HTML-Export nicht implementiert"}
      """;
    return Encoding.UTF8.GetBytes(s0);
  }
}
