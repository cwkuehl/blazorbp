// <copyright file="FZ700Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Fz;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das Formular FZ700 Notizen.
/// </summary>
[Serializable]
public class FZ700Model : PageModelBase
{
  /// <summary>Holt oder setzt Aktualisieren.</summary>
  [Display(Name = "Aktualisieren", Description = "Aktualisieren")]
  //// [Required(ErrorMessage = "Aktualisieren muss angegeben werden.")]
  public string? Refresh { get; set; }

  /// <summary>Holt oder setzt Notizen.</summary>
  [Display(Name = "_Notizen", Description = "Notizen")]
  //// [Required(ErrorMessage = "Notizen muss angegeben werden.")]
  public string? Notizen { get; set; }

  /// <summary>Holt oder setzt Alle.</summary>
  [Display(Name = "A_lle", Description = "Selektionskriterien zurücksetzen")]
  //// [Required(ErrorMessage = "Alle muss angegeben werden.")]
  public string? Alle { get; set; }

  /// <summary>Holt oder setzt Text.</summary>
  [Display(Name = "Te_xt", Description = "Suchtext")]
  //// [Required(ErrorMessage = "Text muss angegeben werden.")]
  public string? Text { get; set; }

  /// <summary>Holt oder setzt Schließen.</summary>
  [Display(Name = "Schließen", Description = "Schließen")]
  //// [Required(ErrorMessage = "Schließen muss angegeben werden.")]
  public string? Schliessen { get; set; }

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  public void SetMhrf(DialogTypeEnum mode)
  {
    if (mode == New)
    {
      // KennwortAlt = null;
    }
    // SetMandatoryHiddenReadonly(nameof(Mandant), true, false, true);
    // SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, mode == Delete);
  }
}
