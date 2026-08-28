// <copyright file="HH100Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Hh;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das Formular HH100 Perioden.
/// </summary>
[Serializable]
public class HH100Model : PageModelBase
{
  /// <summary>Holt oder setzt die Auswahlliste von Perioden.</summary>
  public List<ListItem>? AuswahlPerioden { get; set; } = default!;

  /// <summary>Holt oder setzt Perioden.</summary>
  [Display(Name = "_Perioden", Description = "Perioden")]
  public string? Perioden { get; set; }

  /// <summary>Holt oder setzt Anfang.</summary>
  [Display(Name = "Anfang", Description = "Anfangsdatum der ersten Periode")]
  public string? Anfang { get; set; }

  /// <summary>Holt oder setzt Ende.</summary>
  [Display(Name = "Ende", Description = "Enddatum der letzten Periode")]
  public string? Ende { get; set; }

  /// <summary>Holt oder setzt die Auswahlliste von Laenge.</summary>
  public List<ListItem>? AuswahlLaenge { get; set; } = default!;

  /// <summary>Holt oder setzt Periodenlänge.</summary>
  [Display(Name = "Perioden_länge", Description = "Länge der neuen Periode")]
  [Required(ErrorMessage = "Periodenlänge muss angegeben werden.")]
  public string? Laenge { get; set; }

  /// <summary>Holt oder setzt die Auswahlliste von Art.</summary>
  public List<ListItem>? AuswahlArt { get; set; } = default!;

  /// <summary>Holt oder setzt Art.</summary>
  [Display(Name = "_Art", Description = "Postion der neuen Periode.")]
  [Required(ErrorMessage = "Art muss angegeben werden.")]
  public string? Art { get; set; }

  /// <summary>Holt oder setzt Neu.</summary>
  [Display(Name = "Neu", Description = "Neue Periode an gewählter Position erzeugen")]
  public string? New { get; set; }

  /// <summary>Holt oder setzt Löschen.</summary>
  [Display(Name = "Löschen", Description = "Löschen der ausgewählten Periode")]
  public string? Delete { get; set; }

  /// <summary>Holt oder setzt Aktualisieren.</summary>
  [Display(Name = "Aktualisieren", Description = "Aktualisieren")]
  public string? Refresh { get; set; }

  /// <summary>Holt oder setzt Schließen.</summary>
  [Display(Name = "Schließen", Description = "Schließen")]
  public string? Schliessen { get; set; }

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  public void SetMhrf(DialogTypeEnum mode)
  {
    if (mode == DialogTypeEnum.New)
    {
      Functions.MachNichts();
    }
    SetMandatoryHiddenReadonly(nameof(Perioden), false, false, false, mode == DialogTypeEnum.New);
    SetMandatoryHiddenReadonly(nameof(Anfang), false, false, true, false);
    SetMandatoryHiddenReadonly(nameof(Ende), false, false, true, false);
    SetMandatoryHiddenReadonly(nameof(Laenge), false, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Art), false, false, false, false);
    SetMandatoryHiddenReadonly(nameof(New), false, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Delete), false, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Refresh), false, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Schliessen), false, false, false, false);
  }
}
