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
  /// <summary>Holt oder setzt Aktualisieren.</summary>
  [Display(Name = "Aktualisieren", Description = "Aktualisieren")]
  //// [Required(ErrorMessage = "Aktualisieren muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Aktualisieren darf maximal {1} Zeichen lang sein.")]
  public string? Refresh { get; set; }

  /// <summary>Holt oder setzt Datum.</summary>
  [Display(Name = "_Datum", Description = "")]
  //// [Required(ErrorMessage = "Datum muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Datum darf maximal {1} Zeichen lang sein.")]
  public string? Datum { get; set; }

  /// <summary>Holt oder setzt Bilanz.</summary>
  [Display(Name = "_Bilanz", Description = "")]
  //// [Required(ErrorMessage = "Bilanz muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Bilanz darf maximal {1} Zeichen lang sein.")]
  public string? Bilanz { get; set; }

  /// <summary>Holt oder setzt Bücher.</summary>
  [Display(Name = "Bü_cher", Description = "")]
  //// [Required(ErrorMessage = "Bücher muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Bücher darf maximal {1} Zeichen lang sein.")]
  public string? Buecher { get; set; }

  /// <summary>Holt oder setzt Fahrrad.</summary>
  [Display(Name = "_Fahrrad", Description = "")]
  //// [Required(ErrorMessage = "Fahrrad muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Fahrrad darf maximal {1} Zeichen lang sein.")]
  public string? Fahrrad { get; set; }

  /// <summary>Holt oder setzt Chart.</summary>
  [Display(Name = "Diagramm", Description = "")]
  public string? Diagram { get; set; }

  /// <summary>Holt oder setzt Schließen.</summary>
  [Display(Name = "Schließen", Description = "Schließen")]
  //// [Required(ErrorMessage = "Schließen muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Schließen darf maximal {1} Zeichen lang sein.")]
  public string? Schliessen { get; set; }

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  public void SetMhrf(DialogTypeEnum mode)
  {
    if (mode == New || mode == Copy)
    {
      // TODO Nummer = "";
    }
    if (mode == New)
    {
      // TODO Thema = null;
    }
    // TODO SetMandatoryHiddenReadonly(nameof(Nummer), true, false, true, false);
    // SetMandatoryHiddenReadonly(nameof(Thema), true, false, mode == Delete, mode == New);
    // SetMandatoryHiddenReadonly(nameof(Refresh), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Datum), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Bilanz), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Buecher), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Fahrrad), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Schliessen), false, false, false, false)
    // SetMandatoryHiddenReadonly(nameof(Angelegt), false, mode == New, true);
    // SetMandatoryHiddenReadonly(nameof(Geaendert), false, mode == New, true);
    // SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, mode == Delete);
  }
}
