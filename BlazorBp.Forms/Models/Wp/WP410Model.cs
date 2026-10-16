// <copyright file="WP410Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Forms.Models.Wp;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Core.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Core.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das nicht modale Formular WP410 WP-Buchungen.
/// </summary>
[Serializable]
public class WP410Model : PageModelBase
{
  /// <summary>Holt oder setzt Nr..</summary>
  [Display(Name = "Nr.", Description = "")]
  //// [Required(ErrorMessage = "Nr. muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Nr. darf maximal {1} Zeichen lang sein.")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt Anlage.</summary>
  [Display(Name = "_Anlage", Description = "")]
  //// [Required(ErrorMessage = "Anlage muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Anlage darf maximal {1} Zeichen lang sein.")]
  public string? Anlage { get; set; }

  /// <summary>Holt oder setzt Datum.</summary>
  [Display(Name = "_Datum", Description = "")]
  //// [Required(ErrorMessage = "Datum muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Datum darf maximal {1} Zeichen lang sein.")]
  public string? Valuta { get; set; }

  /// <summary>Holt oder setzt Preis.</summary>
  [Display(Name = "Preis", Description = "")]
  //// [Required(ErrorMessage = "Preis muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Preis darf maximal {1} Zeichen lang sein.")]
  public string? Preis { get; set; }

  /// <summary>Holt oder setzt Betrag.</summary>
  [Display(Name = "_Betrag", Description = "")]
  //// [Required(ErrorMessage = "Betrag muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Betrag darf maximal {1} Zeichen lang sein.")]
  public string? Betrag { get; set; }

  /// <summary>Holt oder setzt Anteile.</summary>
  [Display(Name = "_Anteile", Description = "")]
  //// [Required(ErrorMessage = "Anteile muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Anteile darf maximal {1} Zeichen lang sein.")]
  public string? Anteile { get; set; }

  /// <summary>Holt oder setzt Preis.</summary>
  [Display(Name = "Preis", Description = "")]
  //// [Required(ErrorMessage = "Preis muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Preis darf maximal {1} Zeichen lang sein.")]
  public string? Preis2 { get; set; }

  /// <summary>Holt oder setzt Zinsen.</summary>
  [Display(Name = "_Zinsen", Description = "")]
  //// [Required(ErrorMessage = "Zinsen muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Zinsen darf maximal {1} Zeichen lang sein.")]
  public string? Zinsen { get; set; }

  /// <summary>Holt oder setzt Buchungstext.</summary>
  [Display(Name = "Buchungste_xt", Description = "")]
  //// [Required(ErrorMessage = "Buchungstext muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Buchungstext darf maximal {1} Zeichen lang sein.")]
  public string? BText { get; set; }

  /// <summary>Holt oder setzt Angelegt.</summary>
  [Display(Name = "Angelegt", Description = "")]
  //// [Required(ErrorMessage = "Angelegt muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Angelegt darf maximal {1} Zeichen lang sein.")]
  public string? Angelegt { get; set; }

  /// <summary>Holt oder setzt Geändert.</summary>
  [Display(Name = "Geändert", Description = "")]
  //// [Required(ErrorMessage = "Geändert muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Geändert darf maximal {1} Zeichen lang sein.")]
  public string? Geaendert { get; set; }

  /// <summary>Holt oder setzt Letzte Buchung.</summary>
  [Display(Name = "Letzte Buchung", Description = "")]
  //// [Required(ErrorMessage = "Letzte Buchung muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Letzte Buchung darf maximal {1} Zeichen lang sein.")]
  public string? Buchung { get; set; }

  /// <summary>Holt oder setzt OK.</summary>
  [Display(Name = "_OK", Description = "")]
  //// [Required(ErrorMessage = "OK muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "OK darf maximal {1} Zeichen lang sein.")]
  public string? Ok { get; set; }

  /// <summary>Holt oder setzt Abbrechen.</summary>
  [Display(Name = "Abbre_chen", Description = "")]
  //// [Required(ErrorMessage = "Abbrechen muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Abbrechen darf maximal {1} Zeichen lang sein.")]
  public string? Abbrechen { get; set; }

  /// <summary>Holt oder setzt Rabatt.</summary>
  [Display(Name = "_Rabatt", Description = "")]
  //// [Required(ErrorMessage = "Rabatt muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Rabatt darf maximal {1} Zeichen lang sein.")]
  public string? Rabatt { get; set; }

  /// <summary>Holt oder setzt HH-Buchung.</summary>
  [Display(Name = "HH-Buchung", Description = "")]
  //// [Required(ErrorMessage = "HH-Buchung muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "HH-Buchung darf maximal {1} Zeichen lang sein.")]
  public string? Hhbuchung { get; set; }

  /// <summary>Holt oder setzt Ändern.</summary>
  [Display(Name = "Ändern", Description = "")]
  //// [Required(ErrorMessage = "Ändern muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Ändern darf maximal {1} Zeichen lang sein.")]
  public string? Hhaendern { get; set; }

  /// <summary>Holt oder setzt Storno.</summary>
  [Display(Name = "Storno", Description = "")]
  //// [Required(ErrorMessage = "Storno muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Storno darf maximal {1} Zeichen lang sein.")]
  public string? Hhstorno { get; set; }

  /// <summary>Holt oder setzt Valuta.</summary>
  [Display(Name = "_Valuta", Description = "")]
  //// [Required(ErrorMessage = "Valuta muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Valuta darf maximal {1} Zeichen lang sein.")]
  public string? Hhvaluta { get; set; }

  /// <summary>Holt oder setzt Betrag.</summary>
  [Display(Name = "Betrag", Description = "")]
  //// [Required(ErrorMessage = "Betrag muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Betrag darf maximal {1} Zeichen lang sein.")]
  public string? Hhbetrag { get; set; }

  /// <summary>Holt oder setzt Ereignis.</summary>
  [Display(Name = "Ereignis", Description = "")]
  //// [Required(ErrorMessage = "Ereignis muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Ereignis darf maximal {1} Zeichen lang sein.")]
  public string? Hhereignis { get; set; }

  /// <summary>Holt oder setzt fixieren.</summary>
  [Display(Name = "fixieren", Description = "Soll der Buchungstext fixiert und nicht durch das Ereignis überschrieben werden?")]
  //// [Required(ErrorMessage = "fixieren muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "fixieren darf maximal {1} Zeichen lang sein.")]
  public string? Fixtext { get; set; }

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  public void SetMhrf(DialogTypeEnum mode)
  {
    if (mode == New || mode == Copy)
    {
      // TODO Nummer = "";
    }
    // TODO SetMandatoryHiddenReadonly(nameof(Nummer), true, false, true, false);
    // SetMandatoryHiddenReadonly(nameof(Thema), true, false, mode == Delete, mode == New);
    // SetMandatoryHiddenReadonly(nameof(Nummer), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Anlage), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Valuta), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Preis), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Betrag), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Anteile), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Preis2), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Zinsen), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(BText), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Angelegt), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Geaendert), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Buchung), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Ok), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Abbrechen), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Rabatt), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Hhbuchung), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Hhaendern), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Hhstorno), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Hhvaluta), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Hhbetrag), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Hhereignis), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Fixtext), false, false, mode == Delete, false);

    // SetMandatoryHiddenReadonly(nameof(Angelegt), false, mode == New, true);
    // SetMandatoryHiddenReadonly(nameof(Geaendert), false, mode == New, true);
    // SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, mode == Delete);
  }
}
