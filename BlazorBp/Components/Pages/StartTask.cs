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
/// Komponente zum Starten von asynchronen, länger laufenden Aufgaben.
/// </summary>
public static class StartTask
{
  /// <summary>Startet eine asynchrone, länger laufende Aufgabe.</summary>
  /// <param name="page">Betroffene Seite, z.B. "AG100".</param>
  /// <param name="id">Betroffene Formular-ID.</param>
  /// <param name="context">Betroffener HttpContext.</param>
  /// <param name="sp">Betroffener IServiceProvider.</param>
  public static void Do(string page, string id, HttpContext context, IServiceProvider sp)
  {
    var s = context?.Session;
    if (!string.IsNullOrEmpty(page) && !string.IsNullOrEmpty(id) && s != null)
    {
      var daten = new ServiceDaten(s.GetUserDaten());
      page = page.ToUpper();
      var state = new System.Text.StringBuilder();
      var cancel = new System.Text.StringBuilder();
      switch (page)
      {
        case "WP200":
          var rm = BlazorComponentBaseStatic.ReadFormularTableModel<TableModelBase<WP200TableRowModel>>(s, page, id)?.ReadModel;
          var Model = BlazorComponentBaseStatic.ReadFormularFormModel<WP200Model>(s, page, id);
          if (rm != null && Model != null)
          {
            var r = FactoryService.StockService.CalculateStocks(daten, null, Model.Muster, null,
              Model.Bis ?? daten.Heute, Model.Auchinaktiv, rm?.Search, Model.Konfiguration, state, cancel);
          }
          break;
        default:
          break;
      }
    }
  }
}
