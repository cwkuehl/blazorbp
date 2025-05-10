// <copyright file="AG100Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Am;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das Formular AM100 Kennwort ändern.
/// </summary>
[Serializable]
public class AM100Model : PageModelBase
{
  /// <summary>Holt oder setzt die Mandantennummer.</summary>
  [Display(Name = "_Mandant", Description = "Die Mandantennummer ist notwendig.")]
  [Required(ErrorMessage = "Die Mandantennummer muss angegeben werden.")]
  public int Mandant { get; set; }

  /// <summary>Holt oder setzt die Benutzer-ID.</summary>
  [Display(Name = "_Benutzer-ID", Description = "Die Benutzer-ID ist notwendig.")]
  [Required(ErrorMessage = "Die Benutzer-ID muss angegeben werden.")]
  public string? Benutzer { get; set; }

  /// <summary>Holt oder setzt das alte Kennwort.</summary>
  [Display(Name = "_Altes Kennwort", Description = "Das alte Kennwort ist notwendig.")]
  [Required(ErrorMessage = "Das alte Kennwort muss angegeben werden.")]
  public string? KennwortAlt { get; set; }

  /// <summary>Holt oder setzt das neue Kennwort.</summary>
  [Display(Name = "_Neues Kennwort", Description = "Das neue Kennwort ist notwendig.")]
  [Required(ErrorMessage = "Das neue Kennwort muss angegeben werden.")]
  public string? KennwortNeu { get; set; }

  /// <summary>Holt oder setzt das neue Kennwort.</summary>
  [Display(Name = "_Wiederholung", Description = "Die Wiederholung des neuen Kennworts ist notwendig.")]
  [Required(ErrorMessage = "Die Wiederholung des neuen Kennworts muss angegeben werden.")]
  public string? KennwortNeu2 { get; set; }

  /// <summary>Holt oder setzt den OK-Button.</summary>
  [Display(Name = "_OK", Description = "Formular schließen mit Speichern.")]
  public string? Ok { get; set; } = default!;

  /// <summary>Holt oder setzt den Schließen-Button.</summary>
  [Display(Name = "S_chließen", Description = "Formular schließen ohne Speichern.")]
  public string? Schliessen { get; set; } = default!;


  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  public void SetMhrf(DialogTypeEnum mode)
  {
    if (mode == New)
    {
      KennwortAlt = null;
      KennwortNeu = null;
      KennwortNeu2 = null;
    }
    SetMandatoryHiddenReadonly(nameof(Mandant), true, false, true);
    SetMandatoryHiddenReadonly(nameof(Benutzer), true, false, true);
    SetMandatoryHiddenReadonly(nameof(KennwortAlt), true, false, false, mode == New);
    SetMandatoryHiddenReadonly(nameof(KennwortNeu), true, false, false);
    SetMandatoryHiddenReadonly(nameof(KennwortNeu2), true, false, false);
    SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, mode == Delete);
  }
}
