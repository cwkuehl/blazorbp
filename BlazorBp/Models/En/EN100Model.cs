// <copyright file="EN100Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.En;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das Formular EN100 Abfrage-Parameter.
/// </summary>
[Serializable]
public class EN100Model : PageModelBase
{
  /// <summary>Holt oder setzt Aktualisieren.</summary>
  [Display(Name = "Aktualisieren", Description = "Aktualisieren")]
  //// [Required(ErrorMessage = "Aktualisieren muss angegeben werden.")]
  public string? Refresh { get; set; }

  /// <summary>Holt oder setzt Status.</summary>
  [Display(Name = "Status", Description = "Status der Berechnung wird angezeigt.")]
  public string? Status { get; set; }

  /// <summary>Holt oder setzt auch inaktive.</summary>
  [Display(Name = "auch inaktive", Description = "Sollen auch inaktive Wertpapiere angezeigt werden?")]
  public bool Auchinaktiv { get; set; }

  /// <summary>Holt oder setzt Parameter abfragen.</summary>
  [Display(Name = "Parameter abfragen", Description = "Soll die Abfrage von allen ausgewählten Parameter gestartet werden?")]
  public string? Berechnen { get; set; }

  /// <summary>Holt oder setzt Schließen.</summary>
  [Display(Name = "Schließen", Description = "Schließen")]
  public string? Schliessen { get; set; }

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  /// <param name="daten">Service-Daten für den Datenbankzugriff.</param>
  public void SetMhrf(DialogTypeEnum mode, ServiceDaten daten)
  {
    if (mode == New)
    {
      Auchinaktiv = true;
    }
    SetMandatoryHiddenReadonly(nameof(Status), false, false, true, false);
  }
}
