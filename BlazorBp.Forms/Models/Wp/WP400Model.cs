// <copyright file="WP400Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Forms.Models.Wp;

using System.ComponentModel.DataAnnotations;
using BlazorSpa.Core.Base;
using BlazorSpa.Core.Models;
using CSBP.Services.Base;
using static BlazorSpa.Core.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das Formular WP400 WP-Buchungen.
/// </summary>
[Serializable]
public class WP400Model : PageModelBase
{
  /// <summary>Holt oder setzt die Auswahlliste von Anlagen.</summary>
  public List<ListItem>? AuswahlAnlage { get; set; } = default!;

  /// <summary>Holt oder setzt Anlage.</summary>
  [Display(Name = "_Anlage", Description = "Zu suchende Anlage")]
  //// [Required(ErrorMessage = "Anlage muss angegeben werden.")]
  public string? Anlage { get; set; }

  /// <summary>Holt oder setzt Von.</summary>
  [Display(Name = "_Von", Description = "Ab-Datum für Valuta")]
  public DateTime? Von { get; set; }

  /// <summary>Holt oder setzt Aktualisieren.</summary>
  [Display(Name = "Aktualisieren", Description = "Aktualisieren")]
  public string? Refresh { get; set; }

  /// <summary>Holt oder setzt Schließen.</summary>
  [Display(Name = "Schließen", Description = "Schließen")]
  public string? Schliessen { get; set; }

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  /// <param name="daten">Service-Daten für den Datenbankzugriff.</param>
  public void SetMhrf(DialogTypeEnum mode, ServiceDaten daten)
  {
    if (mode == New || mode == Copy)
    {
      Anlage = null;
      var d = daten.Heute;
      Von = d.AddDays(1 - d.Day).AddMonths(-14);
    }
    SetMandatoryHiddenReadonly(nameof(Anlage), false, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Refresh), false, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Schliessen), false, false, false, false);
  }
}
