// <copyright file="DownloadData.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Forms.Components.Pages;

using BlazorBp.Core.Base;
using BlazorBp.Forms.Models.Wp;
using CSBP.Services.Base;
using CSBP.Services.Factory;
using Microsoft.AspNetCore.Http;

/// <summary>
/// Komponente zum Starten von asynchronen, länger laufenden Aufgaben.
/// </summary>
public static class StartTask
{
  /// <summary>Startet eine asynchrone, länger laufende Aufgabe.</summary>
  /// <param name="page">Betroffene Seite, z.B. "AG100".</param>
  /// <param name="id">Betroffene Formular-ID.</param>
  /// <param name="context">Betroffener HttpContext.</param>
  /// <param name="sp">Betroffener IServiceProvider.</param>
  /// <returns>true, wenn die Aufgabe gestartet wurde sowie Fehlermeldung.</returns>
  public static (bool, string?) Do(string page, string id, HttpContext context, IServiceProvider sp)
  {
    var s = context?.Session;
    if (!string.IsNullOrEmpty(page) && !string.IsNullOrEmpty(id) && s != null)
    {
      var daten = new ServiceDaten(s.GetUserDaten());
      page = page.ToUpper();
      switch (page)
      {
        case "EN100":
          {
            var rs = StatusTask.HinzufuegenFunktion(daten.MandantNr, $"QueryQueries", id, kurz: false);
            if (!rs.Ok || rs.Ergebnis == null)
              return (true, rs.GetErrors() ?? "Fehler beim Starten der Aufgabe.");
            var state = rs.Ergebnis;
            var rm = BlazorComponentBaseStatic.ReadFormularTableModel<TableModelBase<WP200TableRowModel>>(s, page, id)?.ReadModel;
            var Model = BlazorComponentBaseStatic.ReadFormularFormModel<WP200Model>(s, page, id);
            if (rm != null && Model != null)
            {
              var r = FactoryService.EnergyService.QueryQueries(daten, Model.Auchinaktiv, rm?.Search, state);
              state.Beenden(r: r);
            }
            else
              state.Beenden();
            return (true, null);
          }
        case "WP200":
          {
            var rs = StatusTask.HinzufuegenFunktion(daten.MandantNr, $"CalculateStocks", id);
            if (!rs.Ok || rs.Ergebnis == null)
              return (true, rs.GetErrors() ?? "Fehler beim Starten der Aufgabe.");
            var state = rs.Ergebnis;
            var rm = BlazorComponentBaseStatic.ReadFormularTableModel<TableModelBase<WP200TableRowModel>>(s, page, id)?.ReadModel;
            var Model = BlazorComponentBaseStatic.ReadFormularFormModel<WP200Model>(s, page, id);
            if (rm != null && Model != null)
            {
              var r = FactoryService.StockService.CalculateStocks(daten, null, Model.Muster, null,
                Model.Bis ?? daten.Heute, Model.Auchinaktiv, rm?.Search, Model.Konfiguration, state);
              state.Beenden(r: r);
            }
            else
              state.Beenden();
            return (true, null);
          }
        case "WP250":
          {
            var rs = StatusTask.HinzufuegenFunktion(daten.MandantNr, $"CalculateInvestments", id);
            if (!rs.Ok || rs.Ergebnis == null)
              return (true, rs.GetErrors() ?? "Fehler beim Starten der Aufgabe.");
            var state = rs.Ergebnis;
            var rm = BlazorComponentBaseStatic.ReadFormularTableModel<TableModelBase<WP250TableRowModel>>(s, page, id)?.ReadModel;
            var Model = BlazorComponentBaseStatic.ReadFormularFormModel<WP250Model>(s, page, id);
            if (rm != null && Model != null)
            {
              var r = FactoryService.StockService.CalculateInvestments(daten, null, null, Model.Wertpapier,
                Model.Bis ?? daten.Heute, Model.Auchinaktiv, rm?.Search, state);
              state.Beenden(r: r);
            }
            else
              state.Beenden();
            return (true, null);
          }
        default:
          break;
      }
    }
    return (false, $"Ungültige Aufgabe: {page}");
  }
}
