// <copyright file="WP500Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Wp;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das Formular WP500 Stände.
/// </summary>
[Serializable]
public class WP500Model : PageModelBase
{
  /// <summary>Holt oder setzt die Auswahlliste von Wertpapieren.</summary>
  public List<ListItem>? AuswahlWertpapier { get; set; } = default!;

  /// <summary>Holt oder setzt Wertpapier.</summary>
  [Display(Name = "_Wertpapier", Description = "Zu suchendes Wertpapier")]
  public string? Wertpapier { get; set; }

  /// <summary>Holt oder setzt Datum von.</summary>
  [Display(Name = "Datum _von", Description = "Datum von")]
  public DateTime? Von { get; set; }

  /// <summary>Holt oder setzt Bis.</summary>
  [Display(Name = "_Bis", Description = "Datum bis")]
  public DateTime? Bis { get; set; }

  /// <summary>Holt oder setzt Ausdünnen.</summary>
  [Display(Name = "Ausd_ünnen", Description = "Stände ausdünnen (1 Woche bleibt, 2 Monate Wochenschluss, 10 Monate Monatsschluss, Rest Jahresschluss, erster und letzter bleiben)")]
  public string? Thin { get; set; }

  /// <summary>Holt oder setzt Refresh.</summary>
  [Display(Name = "Aktualisieren", Description = "Aktualisieren der Liste")]
  public string? Refresh { get; set; }

  /// <summary>Holt oder setzt Schließen.</summary>
  [Display(Name = "Schließen", Description = "Schließen")]
  public string? Schliessen { get; set; }

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  /// <param name="daten">Die Service-Daten.</param>
  public void SetMhrf(DialogTypeEnum mode, ServiceDaten daten)
  {
    if (mode == New || mode == Copy)
    {
      Wertpapier = null;
      Von = daten.Heute.AddMonths(-3);
      Bis = daten.Heute;
    }
    if (mode == New)
    {
      Functions.MachNichts();
    }
    SetMandatoryHiddenReadonly(nameof(Schliessen), false, false, false, false);
  }
}
