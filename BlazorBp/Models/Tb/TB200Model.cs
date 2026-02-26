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
  /// <summary>Holt oder setzt Chart oder Karte.</summary>
  [Display(Name = "Karte", Description = "Aufruf der Position in einer Karte")]
  //// [Required(ErrorMessage = "Chart oder Karte muss angegeben werden.")]
  public string? Chart { get; set; }

  /// <summary>Holt oder setzt Aktualisieren.</summary>
  [Display(Name = "Aktualisieren", Description = "Aktualisieren")]
  //// [Required(ErrorMessage = "Aktualisieren muss angegeben werden.")]
  public string? Refresh { get; set; }

  /// <summary>Holt oder setzt Schließen.</summary>
  [Display(Name = "Schließen", Description = "Schließen")]
  //// [Required(ErrorMessage = "Schließen muss angegeben werden.")]
  public string? Schliessen { get; set; }

  /// <summary>Holt oder setzt den Link für Map.</summary>
  public string? MapHref { get; set; } = default!;

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  public void SetMhrf(DialogTypeEnum mode)
  {
    if (mode == New || mode == Copy)
    {
      // Nummer = "";
    }
    if (mode == New)
    {
      // Thema = null;
    }
    // SetMandatoryHiddenReadonly(nameof(Nummer), true, false, true, false);
  }
}
