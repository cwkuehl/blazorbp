// <copyright file="HH410Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Hh;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das nicht modale Formular HH410 Buchungen.
/// </summary>
[Serializable]
public class HH410Model : PageModelBase
{
  /// <summary>Holt oder setzt Nr..</summary>
  [Display(Name = "Nr.", Description = "Buchung-Nr.")]
  //// [Required(ErrorMessage = "Nr. muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Nr. darf maximal {1} Zeichen lang sein.")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt Valuta.</summary>
  [Display(Name = "_Valuta", Description = "")]
  //// [Required(ErrorMessage = "Valuta muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Valuta darf maximal {1} Zeichen lang sein.")]
  public string? Valuta { get; set; }

  /// <summary>Holt oder setzt Betrag.</summary>
  [Display(Name = "_Betrag", Description = "Betrag")]
  //// [Required(ErrorMessage = "Betrag muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Betrag darf maximal {1} Zeichen lang sein.")]
  public string? Betrag { get; set; }

  /// <summary>Holt oder setzt Summe.</summary>
  [Display(Name = "Summe", Description = "Summe")]
  //// [Required(ErrorMessage = "Summe muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Summe darf maximal {1} Zeichen lang sein.")]
  public string? Summe { get; set; }

  /// <summary>Holt oder setzt Ereignis.</summary>
  [Display(Name = "_Ereignis", Description = "Ereignis")]
  //// [Required(ErrorMessage = "Ereignis muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Ereignis darf maximal {1} Zeichen lang sein.")]
  public string? Ereignis { get; set; }

  /// <summary>Holt oder setzt Sollkonto.</summary>
  [Display(Name = "_Sollkonto", Description = "Sollkonto")]
  //// [Required(ErrorMessage = "Sollkonto muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Sollkonto darf maximal {1} Zeichen lang sein.")]
  public string? Sollkonto { get; set; }

  /// <summary>Holt oder setzt Habenkonto.</summary>
  [Display(Name = "Habe_nkonto", Description = "Habenkonto")]
  //// [Required(ErrorMessage = "Habenkonto muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Habenkonto darf maximal {1} Zeichen lang sein.")]
  public string? Habenkonto { get; set; }

  /// <summary>Holt oder setzt Buchungstext.</summary>
  [Display(Name = "Buchungste_xt", Description = "Buchungstext")]
  //// [Required(ErrorMessage = "Buchungstext muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Buchungstext darf maximal {1} Zeichen lang sein.")]
  public string? BText { get; set; }

  /// <summary>Holt oder setzt Beleg.</summary>
  [Display(Name = "Bele_g", Description = "Belegnummer")]
  //// [Required(ErrorMessage = "Beleg muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Beleg darf maximal {1} Zeichen lang sein.")]
  public string? BelegNr { get; set; }

  /// <summary>Holt oder setzt Neue Nr..</summary>
  [Display(Name = "Neue N_r.", Description = "Neue Belegnummer berechnen")]
  //// [Required(ErrorMessage = "Neue Nr. muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Neue Nr. darf maximal {1} Zeichen lang sein.")]
  public string? NeueNr { get; set; }

  /// <summary>Holt oder setzt Vom.</summary>
  [Display(Name = "Vom", Description = "")]
  //// [Required(ErrorMessage = "Vom muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Vom darf maximal {1} Zeichen lang sein.")]
  public string? BelegDatum { get; set; }

  /// <summary>Holt oder setzt Angelegt.</summary>
  [Display(Name = "Angelegt", Description = "Datum, Uhrzeit und Benutzer, der die Daten angelegt hat")]
  //// [Required(ErrorMessage = "Angelegt muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Angelegt darf maximal {1} Zeichen lang sein.")]
  public string? Angelegt { get; set; }

  /// <summary>Holt oder setzt Geändert.</summary>
  [Display(Name = "Geändert", Description = "Datum, Uhrzeit und Benutzer, der die Daten geändert hat")]
  //// [Required(ErrorMessage = "Geändert muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Geändert darf maximal {1} Zeichen lang sein.")]
  public string? Geaendert { get; set; }

  /// <summary>Holt oder setzt Letzte Buchung.</summary>
  [Display(Name = "Letzte Buchung", Description = "Letzte Buchung")]
  //// [Required(ErrorMessage = "Letzte Buchung muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Letzte Buchung darf maximal {1} Zeichen lang sein.")]
  public string? Buchung { get; set; }

  /// <summary>Holt oder setzt OK.</summary>
  [Display(Name = "_OK", Description = "Dialog mit Speichern schließen")]
  //// [Required(ErrorMessage = "OK muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "OK darf maximal {1} Zeichen lang sein.")]
  public string? Ok { get; set; }

  /// <summary>Holt oder setzt Kontentausch.</summary>
  [Display(Name = "Kon_tentausch", Description = "Kontentausch")]
  //// [Required(ErrorMessage = "Kontentausch muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Kontentausch darf maximal {1} Zeichen lang sein.")]
  public string? Kontentausch { get; set; }

  /// <summary>Holt oder setzt Addition.</summary>
  [Display(Name = "_Addition", Description = "Addtion, Multiplikation, Division zur Summe")]
  //// [Required(ErrorMessage = "Addition muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Addition darf maximal {1} Zeichen lang sein.")]
  public string? Addition { get; set; }

  /// <summary>Holt oder setzt Abbrechen.</summary>
  [Display(Name = "Abbre_chen", Description = "Dialog ohne Speichern schließen")]
  //// [Required(ErrorMessage = "Abbrechen muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Abbrechen darf maximal {1} Zeichen lang sein.")]
  public string? Abbrechen { get; set; }

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
    // SetMandatoryHiddenReadonly(nameof(Nummer), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Valuta), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Betrag), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Summe), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Ereignis), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Sollkonto), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Habenkonto), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(BText), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(BelegNr), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(NeueNr), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(BelegDatum), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Angelegt), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Geaendert), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Buchung), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Ok), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Kontentausch), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Addition), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Abbrechen), false, false, mode == Delete, false);

    // SetMandatoryHiddenReadonly(nameof(Angelegt), false, mode == New, true);
    // SetMandatoryHiddenReadonly(nameof(Geaendert), false, mode == New, true);
    // SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, mode == Delete);
  }
}
