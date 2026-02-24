// <copyright file="TB200Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Tb;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das Formular TB200 Positionen.
/// </summary>
[Serializable]
public class TB200Model : PageModelBase
{
  /// <summary>Holt oder setzt Aktualisieren.</summary>
  [Display(Name = "Aktualisieren", Description = "Aktualisieren")]
  //// [Required(ErrorMessage = "Aktualisieren muss angegeben werden.")]
  public string? Refresh { get; set; }

  /// <summary>Holt oder setzt Chart oder Karte.</summary>
  [Display(Name = "Chart oder Karte", Description = "Chart oder Karte")]
  //// [Required(ErrorMessage = "Chart oder Karte muss angegeben werden.")]
  public string? Chart { get; set; }

  /// <summary>Holt oder setzt Positionen.</summary>
  [Display(Name = "_Positionen", Description = "Positionen")]
  //// [Required(ErrorMessage = "Positionen muss angegeben werden.")]
  public string? Positions { get; set; }

  /// <summary>Holt oder setzt Alle.</summary>
  [Display(Name = "A_lle", Description = "Selektionskriterien zurücksetzen")]
  //// [Required(ErrorMessage = "Alle muss angegeben werden.")]
  public string? All { get; set; }

  /// <summary>Holt oder setzt Suche.</summary>
  [Display(Name = "_Suche", Description = "Suche für Text")]
  //// [Required(ErrorMessage = "Suche muss angegeben werden.")]
  public string? Search { get; set; }

  /// <summary>Holt oder setzt Schließen.</summary>
  [Display(Name = "Schließen", Description = "Schließen")]
  //// [Required(ErrorMessage = "Schließen muss angegeben werden.")]
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
    // SetMandatoryHiddenReadonly(nameof(Angelegt), false, mode == New, true);
    // SetMandatoryHiddenReadonly(nameof(Geaendert), false, mode == New, true);
    // SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, mode == Delete);
  }
}
