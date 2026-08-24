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
  /// <summary>Holt oder setzt Aktualisieren.</summary>
  [Display(Name = "Aktualisieren", Description = "Aktualisieren")]
  //// [Required(ErrorMessage = "Aktualisieren muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Aktualisieren darf maximal {1} Zeichen lang sein.")]
  public string? Refresh { get; set; }

  /// <summary>Holt oder setzt Perioden.</summary>
  [Display(Name = "_Perioden", Description = "Perioden")]
  //// [Required(ErrorMessage = "Perioden muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Perioden darf maximal {1} Zeichen lang sein.")]
  public string? Perioden { get; set; }

  /// <summary>Holt oder setzt Anfang.</summary>
  [Display(Name = "Anfang", Description = "Anfangsdatum der ersten Periode")]
  //// [Required(ErrorMessage = "Anfang muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Anfang darf maximal {1} Zeichen lang sein.")]
  public string? Anfang { get; set; }

  /// <summary>Holt oder setzt Ende.</summary>
  [Display(Name = "Ende", Description = "Enddatum der letzten Periode")]
  //// [Required(ErrorMessage = "Ende muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Ende darf maximal {1} Zeichen lang sein.")]
  public string? Ende { get; set; }

  /// <summary>Holt oder setzt Periodenlänge.</summary>
  [Display(Name = "Perioden_länge", Description = "")]
  //// [Required(ErrorMessage = "Periodenlänge muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Periodenlänge darf maximal {1} Zeichen lang sein.")]
  public string? Laenge0 { get; set; }

  /// <summary>Holt oder setzt Monat.</summary>
  [Display(Name = "Monat", Description = "Monatliche Periode")]
  //// [Required(ErrorMessage = "Monat muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Monat darf maximal {1} Zeichen lang sein.")]
  public string? Laenge1 { get; set; }

  /// <summary>Holt oder setzt Vierteljahr.</summary>
  [Display(Name = "Vierteljahr", Description = "Vierteljährliche Periode")]
  //// [Required(ErrorMessage = "Vierteljahr muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Vierteljahr darf maximal {1} Zeichen lang sein.")]
  public string? Laenge2 { get; set; }

  /// <summary>Holt oder setzt Halbjahr.</summary>
  [Display(Name = "Halbjahr", Description = "Halbjährliche Periode")]
  //// [Required(ErrorMessage = "Halbjahr muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Halbjahr darf maximal {1} Zeichen lang sein.")]
  public string? Laenge3 { get; set; }

  /// <summary>Holt oder setzt Jahr.</summary>
  [Display(Name = "Jahr", Description = "Jährliche Periode")]
  //// [Required(ErrorMessage = "Jahr muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Jahr darf maximal {1} Zeichen lang sein.")]
  public string? Laenge4 { get; set; }

  /// <summary>Holt oder setzt Art.</summary>
  [Display(Name = "_Art", Description = "")]
  //// [Required(ErrorMessage = "Art muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Art darf maximal {1} Zeichen lang sein.")]
  public string? Art0 { get; set; }

  /// <summary>Holt oder setzt Anfang.</summary>
  [Display(Name = "Anfang", Description = "Neue Periode am Anfang einfügen")]
  //// [Required(ErrorMessage = "Anfang muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Anfang darf maximal {1} Zeichen lang sein.")]
  public string? Art1 { get; set; }

  /// <summary>Holt oder setzt Ende.</summary>
  [Display(Name = "Ende", Description = "Neue Periode am Ende einfügen")]
  //// [Required(ErrorMessage = "Ende muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Ende darf maximal {1} Zeichen lang sein.")]
  public string? Art2 { get; set; }

  /// <summary>Holt oder setzt Schließen.</summary>
  [Display(Name = "Schließen", Description = "Schließen")]
  public string? Schliessen { get; set; }

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  public void SetMhrf(DialogTypeEnum mode)
  {
    if (mode == New)
    {
      // TODO Thema = null;
    }
    // TODO SetMandatoryHiddenReadonly(nameof(Nummer), true, false, true, false);
    // SetMandatoryHiddenReadonly(nameof(Thema), true, false, mode == Delete, mode == New);
    // SetMandatoryHiddenReadonly(nameof(Refresh), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Perioden), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Anfang), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Ende), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Laenge0), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Laenge1), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Laenge2), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Laenge3), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Laenge4), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Art0), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Art1), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Art2), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Schliessen), false, false, false, false)
    // SetMandatoryHiddenReadonly(nameof(Angelegt), false, mode == New, true);
    // SetMandatoryHiddenReadonly(nameof(Geaendert), false, mode == New, true);
    // SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, mode == Delete);
  }
}
