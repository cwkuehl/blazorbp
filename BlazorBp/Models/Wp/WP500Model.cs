// <copyright file="WP500Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Wp;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das Formular WP500 Stände.
/// </summary>
[Serializable]
public class WP500Model : PageModelBase
{  /// <summary>Holt oder setzt .</summary>
  [Display(Name = "", Description = "")]
  //// [Required(ErrorMessage = " muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = " darf maximal {1} Zeichen lang sein.")]
  public string? Refresh { get; set; }

  /// <summary>Holt oder setzt Stände.</summary>
  [Display(Name = "_Stände", Description = "")]
  //// [Required(ErrorMessage = "Stände muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Stände darf maximal {1} Zeichen lang sein.")]
  public string? Staende { get; set; }

  /// <summary>Holt oder setzt Datum von.</summary>
  [Display(Name = "Datum _von", Description = "")]
  //// [Required(ErrorMessage = "Datum von muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Datum von darf maximal {1} Zeichen lang sein.")]
  public string? Von { get; set; }

  /// <summary>Holt oder setzt Bis.</summary>
  [Display(Name = "_Bis", Description = "")]
  //// [Required(ErrorMessage = "Bis muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Bis darf maximal {1} Zeichen lang sein.")]
  public string? Bis { get; set; }

  /// <summary>Holt oder setzt Alle.</summary>
  [Display(Name = "A_lle", Description = "")]
  //// [Required(ErrorMessage = "Alle muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Alle darf maximal {1} Zeichen lang sein.")]
  public string? All { get; set; }

  /// <summary>Holt oder setzt Wertpapier.</summary>
  [Display(Name = "_Wertpapier", Description = "")]
  //// [Required(ErrorMessage = "Wertpapier muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Wertpapier darf maximal {1} Zeichen lang sein.")]
  public string? Wertpapier { get; set; }

  /// <summary>Holt oder setzt Ausdünnen.</summary>
  [Display(Name = "Ausd_ünnen", Description = "")]
  //// [Required(ErrorMessage = "Ausdünnen muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Ausdünnen darf maximal {1} Zeichen lang sein.")]
  public string? Thin { get; set; }

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
    // SetMandatoryHiddenReadonly(nameof(Angelegt), false, mode == New, true);
    // SetMandatoryHiddenReadonly(nameof(Geaendert), false, mode == New, true);
    // SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, mode == Delete);
  }
}
