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

  /// <summary>Holt oder setzt Rückgängig.</summary>
  [Display(Name = "Rückgängig", Description = "Rückgängig")]
  //// [Required(ErrorMessage = "Rückgängig muss angegeben werden.")]
  public string? Undo { get; set; }

  /// <summary>Holt oder setzt Wiederherstellen.</summary>
  [Display(Name = "Wiederherstellen", Description = "Wiederherstellen")]
  //// [Required(ErrorMessage = "Wiederherstellen muss angegeben werden.")]
  public string? Redo { get; set; }

  /// <summary>Holt oder setzt Neu.</summary>
  [Display(Name = "Neu", Description = "Neu")]
  //// [Required(ErrorMessage = "Neu muss angegeben werden.")]
  public string? NewAction { get; set; }

  /// <summary>Holt oder setzt Kopieren.</summary>
  [Display(Name = "Kopieren", Description = "Kopieren")]
  //// [Required(ErrorMessage = "Kopieren muss angegeben werden.")]
  public string? Copy { get; set; }

  /// <summary>Holt oder setzt Ändern.</summary>
  [Display(Name = "Ändern", Description = "Ändern")]
  //// [Required(ErrorMessage = "Ändern muss angegeben werden.")]
  public string? Edit { get; set; }

  /// <summary>Holt oder setzt Löschen.</summary>
  [Display(Name = "Löschen", Description = "Löschen")]
  //// [Required(ErrorMessage = "Löschen muss angegeben werden.")]
  public string? Delete { get; set; }

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
      // TODO KennwortAlt = null;
    }
    // TODO SetMandatoryHiddenReadonly(nameof(Mandant), true, false, true);
    // SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, mode == Delete);
  }
}
