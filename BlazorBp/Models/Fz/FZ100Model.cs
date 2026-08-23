// <copyright file="FZ100Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Fz;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das Formular FZ100 Statistik.
/// </summary>
[Serializable]
public class FZ100Model : PageModelBase
{
  /// <summary>Holt oder setzt Datum.</summary>
  [Display(Name = "_Datum", Description = "")]
  [Required(ErrorMessage = "Datum muss angegeben werden.")]
  public DateTime? Datum { get; set; }

  /// <summary>Holt oder setzt Bilanz.</summary>
  [Display(Name = "_Bilanz", Description = "")]
  public string? Bilanz { get; set; }

  /// <summary>Holt oder setzt Bücher.</summary>
  [Display(Name = "Bü_cher", Description = "")]
  public string? Buecher { get; set; }

  /// <summary>Holt oder setzt Fahrrad.</summary>
  [Display(Name = "_Fahrrad", Description = "")]
  public string? Fahrrad { get; set; }

  /// <summary>Holt oder setzt Chart.</summary>
  [Display(Name = "Diagramm", Description = "")]
  public string? Diagram { get; set; }

  /// <summary>Holt oder setzt Aktualisieren.</summary>
  [Display(Name = "Aktualisieren", Description = "Aktualisieren")]
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
      Datum = daten.Heute;
    }
    SetMandatoryHiddenReadonly(nameof(Datum), false, false, false, mode == New);
    SetMandatoryHiddenReadonly(nameof(Bilanz), false, false, true, false);
    SetMandatoryHiddenReadonly(nameof(Buecher), false, false, true, false);
    SetMandatoryHiddenReadonly(nameof(Fahrrad), false, false, true, false);
    SetMandatoryHiddenReadonly(nameof(Diagram), false, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Refresh), false, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Schliessen), false, false, false, false);
  }
}
