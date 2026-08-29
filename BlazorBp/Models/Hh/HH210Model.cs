// <copyright file="HH210Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Hh;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das nicht modale Formular HH210 Konten.
/// </summary>
[Serializable]
public class HH210Model : PageModelBase
{
  /// <summary>Holt oder setzt Nr..</summary>
  [Display(Name = "Nr.", Description = "Konto-Nr.")]
  //// [Required(ErrorMessage = "Nr. muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Nr. darf maximal {1} Zeichen lang sein.")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt Bezeichnung.</summary>
  [Display(Name = "_Bezeichnung", Description = "Bezeichnung")]
  //// [Required(ErrorMessage = "Bezeichnung muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Bezeichnung darf maximal {1} Zeichen lang sein.")]
  public string? Bezeichnung { get; set; }

  /// <summary>Holt oder setzt Kennzeichen.</summary>
  [Display(Name = "_Kennzeichen", Description = "")]
  //// [Required(ErrorMessage = "Kennzeichen muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Kennzeichen darf maximal {1} Zeichen lang sein.")]
  public string? Kennzeichen0 { get; set; }

  /// <summary>Holt oder setzt Ohne.</summary>
  [Display(Name = "_Ohne", Description = "Ohne Kennzeichen")]
  //// [Required(ErrorMessage = "Ohne muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Ohne darf maximal {1} Zeichen lang sein.")]
  public string? Kennzeichen1 { get; set; }

  /// <summary>Holt oder setzt Eigenkapitel.</summary>
  [Display(Name = "Eigenkapitel", Description = "Eigenkapitel-Konto")]
  //// [Required(ErrorMessage = "Eigenkapitel muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Eigenkapitel darf maximal {1} Zeichen lang sein.")]
  public string? Kennzeichen2 { get; set; }

  /// <summary>Holt oder setzt Gewinn+Verlust.</summary>
  [Display(Name = "Gewinn+Verlust", Description = "Gewinn+Verlust-Konto")]
  //// [Required(ErrorMessage = "Gewinn+Verlust muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Gewinn+Verlust darf maximal {1} Zeichen lang sein.")]
  public string? Kennzeichen3 { get; set; }

  /// <summary>Holt oder setzt Depot.</summary>
  [Display(Name = "Depot", Description = "Depot-Konto")]
  //// [Required(ErrorMessage = "Depot muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Depot darf maximal {1} Zeichen lang sein.")]
  public string? Kennzeichen4 { get; set; }

  /// <summary>Holt oder setzt Kontoart.</summary>
  [Display(Name = "Kontoa_rt", Description = "")]
  //// [Required(ErrorMessage = "Kontoart muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Kontoart darf maximal {1} Zeichen lang sein.")]
  public string? Kontoart0 { get; set; }

  /// <summary>Holt oder setzt Aktiv (AK).</summary>
  [Display(Name = "Aktiv (AK)", Description = "Aktiv-Konto")]
  //// [Required(ErrorMessage = "Aktiv (AK) muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Aktiv (AK) darf maximal {1} Zeichen lang sein.")]
  public string? Kontoart1 { get; set; }

  /// <summary>Holt oder setzt Passiv (PK).</summary>
  [Display(Name = "Passiv (PK)", Description = "Passiv-Konto")]
  //// [Required(ErrorMessage = "Passiv (PK) muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Passiv (PK) darf maximal {1} Zeichen lang sein.")]
  public string? Kontoart2 { get; set; }

  /// <summary>Holt oder setzt Aufwand (AW).</summary>
  [Display(Name = "Aufwand (AW)", Description = "Aufwand-Konto")]
  //// [Required(ErrorMessage = "Aufwand (AW) muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Aufwand (AW) darf maximal {1} Zeichen lang sein.")]
  public string? Kontoart3 { get; set; }

  /// <summary>Holt oder setzt Ertrag (ER).</summary>
  [Display(Name = "Ertrag (ER)", Description = "Ertrag-Konto")]
  //// [Required(ErrorMessage = "Ertrag (ER) muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Ertrag (ER) darf maximal {1} Zeichen lang sein.")]
  public string? Kontoart4 { get; set; }

  /// <summary>Holt oder setzt Gültigkeit von.</summary>
  [Display(Name = "Gültigkeit _von", Description = "")]
  //// [Required(ErrorMessage = "Gültigkeit von muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Gültigkeit von darf maximal {1} Zeichen lang sein.")]
  public string? Von { get; set; }

  /// <summary>Holt oder setzt Bis.</summary>
  [Display(Name = "B_is", Description = "")]
  //// [Required(ErrorMessage = "Bis muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Bis darf maximal {1} Zeichen lang sein.")]
  public string? Bis { get; set; }

  /// <summary>Holt oder setzt Betrag.</summary>
  [Display(Name = "B_etrag", Description = "Betrag am 1. Gültigkeitstag für Aktiv- und Passivkonten, negativ für Aktivkonten.")]
  //// [Required(ErrorMessage = "Betrag muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Betrag darf maximal {1} Zeichen lang sein.")]
  public string? Betrag { get; set; }

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

  /// <summary>Holt oder setzt die letzte Buchung.</summary>
  [Display(Name = "Letzte Buchung", Description = "Letzte Buchung")]
  public string? Buchung { get; set; }

  /// <summary>Holt oder setzt OK.</summary>
  [Display(Name = "_OK", Description = "Dialog mit Speichern schließen")]
  //// [Required(ErrorMessage = "OK muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "OK darf maximal {1} Zeichen lang sein.")]
  public string? Ok { get; set; }

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
    // SetMandatoryHiddenReadonly(nameof(Nummer), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Bezeichnung), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Kennzeichen0), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Kennzeichen1), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Kennzeichen2), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Kennzeichen3), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Kennzeichen4), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Kontoart0), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Kontoart1), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Kontoart2), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Kontoart3), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Kontoart4), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Von), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Bis), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Betrag), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Angelegt), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Geaendert), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Abbrechen), false, false, false, false)
    // SetMandatoryHiddenReadonly(nameof(Angelegt), false, mode == New, true);
    // SetMandatoryHiddenReadonly(nameof(Geaendert), false, mode == New, true);
    // SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, mode == Delete);
  }
}
