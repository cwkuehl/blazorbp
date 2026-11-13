// <copyright file="AD110Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Forms.Models.Ad;

using System.ComponentModel.DataAnnotations;
using BlazorSpa.Core.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorSpa.Core.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das nicht modale Formular AD110 Personen.
/// </summary>
[Serializable]
public class AD110Model : PageModelBase
{
  /// <summary>Holt oder setzt Nrn. (PSA).</summary>
  [Display(Name = "Nrn. (PSA)", Description = "Person-Nr.")]
  //// [Required(ErrorMessage = "Nrn. (PSA) muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Nrn. (PSA) darf maximal {1} Zeichen lang sein.")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt Nrn. (PSA).</summary>
  [Display(Name = "Nrn. (PSA)", Description = "Person-Nr.")]
  //// [Required(ErrorMessage = "Nrn. (PSA) muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Nrn. (PSA) darf maximal {1} Zeichen lang sein.")]
  public string? SitzNr { get; set; }

  /// <summary>Holt oder setzt Nrn. (PSA).</summary>
  [Display(Name = "Nrn. (PSA)", Description = "Person-Nr.")]
  //// [Required(ErrorMessage = "Nrn. (PSA) muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Nrn. (PSA) darf maximal {1} Zeichen lang sein.")]
  public string? AdressNr { get; set; }

  /// <summary>Holt oder setzt Titel.</summary>
  [Display(Name = "_Titel", Description = "Titel oder Beruf")]
  //// [Required(ErrorMessage = "Titel muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Titel darf maximal {1} Zeichen lang sein.")]
  public string? Titel { get; set; }

  /// <summary>Holt oder setzt Vorname.</summary>
  [Display(Name = "_Vorname", Description = "Vorname")]
  //// [Required(ErrorMessage = "Vorname muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Vorname darf maximal {1} Zeichen lang sein.")]
  public string? Vorname { get; set; }

  /// <summary>Holt oder setzt Prädikat.</summary>
  [Display(Name = "_Prädikat", Description = "Prädikat")]
  //// [Required(ErrorMessage = "Prädikat muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Prädikat darf maximal {1} Zeichen lang sein.")]
  public string? Praedikat { get; set; }

  /// <summary>Holt oder setzt (Nach-)Name.</summary>
  [Display(Name = "(_Nach-)Name", Description = "Nachname oder Firmenname")]
  //// [Required(ErrorMessage = "(Nach-)Name muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "(Nach-)Name darf maximal {1} Zeichen lang sein.")]
  public string? Name1 { get; set; }

  /// <summary>Holt oder setzt Name 2.</summary>
  [Display(Name = "Name 2", Description = "2. Teil des Namens")]
  //// [Required(ErrorMessage = "Name 2 muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Name 2 darf maximal {1} Zeichen lang sein.")]
  public string? Name2 { get; set; }

  /// <summary>Holt oder setzt Geschlecht.</summary>
  [Display(Name = "Geschlecht", Description = "")]
  //// [Required(ErrorMessage = "Geschlecht muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Geschlecht darf maximal {1} Zeichen lang sein.")]
  public string? Geschlecht0 { get; set; }

  /// <summary>Holt oder setzt Neutrum.</summary>
  [Display(Name = "Neutrum", Description = "Weder männlich noch weiblich oder Firma")]
  //// [Required(ErrorMessage = "Neutrum muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Neutrum darf maximal {1} Zeichen lang sein.")]
  public string? Geschlecht1 { get; set; }

  /// <summary>Holt oder setzt Männlich.</summary>
  [Display(Name = "Männlich", Description = "Männlich")]
  //// [Required(ErrorMessage = "Männlich muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Männlich darf maximal {1} Zeichen lang sein.")]
  public string? Geschlecht2 { get; set; }

  /// <summary>Holt oder setzt Weiblich.</summary>
  [Display(Name = "Weiblich", Description = "Weiblich")]
  //// [Required(ErrorMessage = "Weiblich muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Weiblich darf maximal {1} Zeichen lang sein.")]
  public string? Geschlecht3 { get; set; }

  /// <summary>Holt oder setzt Geburt.</summary>
  [Display(Name = "_Geburt", Description = "")]
  //// [Required(ErrorMessage = "Geburt muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Geburt darf maximal {1} Zeichen lang sein.")]
  public string? Geburt { get; set; }

  /// <summary>Holt oder setzt Person-Status.</summary>
  [Display(Name = "Person-Status", Description = "")]
  //// [Required(ErrorMessage = "Person-Status muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Person-Status darf maximal {1} Zeichen lang sein.")]
  public string? PersonStatus0 { get; set; }

  /// <summary>Holt oder setzt Aktuell.</summary>
  [Display(Name = "Aktuell", Description = "Person wird ausgedruckt")]
  //// [Required(ErrorMessage = "Aktuell muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Aktuell darf maximal {1} Zeichen lang sein.")]
  public string? PersonStatus1 { get; set; }

  /// <summary>Holt oder setzt Alt.</summary>
  [Display(Name = "Alt", Description = "Person wird nicht ausgedruckt")]
  //// [Required(ErrorMessage = "Alt muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Alt darf maximal {1} Zeichen lang sein.")]
  public string? PersonStatus2 { get; set; }

  /// <summary>Holt oder setzt Sitz.</summary>
  [Display(Name = "S_itz", Description = "Bezeichnung für den Sitz")]
  //// [Required(ErrorMessage = "Sitz muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Sitz darf maximal {1} Zeichen lang sein.")]
  public string? Name { get; set; }

  /// <summary>Holt oder setzt Straße.</summary>
  [Display(Name = "St_raße", Description = "Straße ohne Hausnummer")]
  //// [Required(ErrorMessage = "Straße muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Straße darf maximal {1} Zeichen lang sein.")]
  public string? Strasse { get; set; }

  /// <summary>Holt oder setzt Hausnr..</summary>
  [Display(Name = "Hausnr.", Description = "Hausnummer")]
  //// [Required(ErrorMessage = "Hausnr. muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Hausnr. darf maximal {1} Zeichen lang sein.")]
  public string? Hausnr { get; set; }

  /// <summary>Holt oder setzt Postfach.</summary>
  [Display(Name = "Postfach", Description = "Postfach")]
  //// [Required(ErrorMessage = "Postfach muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Postfach darf maximal {1} Zeichen lang sein.")]
  public string? Postfach { get; set; }

  /// <summary>Holt oder setzt Staat.</summary>
  [Display(Name = "Staat", Description = "Abkürzung für Staat, D für Deutschland")]
  //// [Required(ErrorMessage = "Staat muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Staat darf maximal {1} Zeichen lang sein.")]
  public string? Staat { get; set; }

  /// <summary>Holt oder setzt Plz.</summary>
  [Display(Name = "Plz", Description = "Postleitzahl")]
  //// [Required(ErrorMessage = "Plz muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Plz darf maximal {1} Zeichen lang sein.")]
  public string? Plz { get; set; }

  /// <summary>Holt oder setzt Ort.</summary>
  [Display(Name = "Ort", Description = "Ort")]
  //// [Required(ErrorMessage = "Ort muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Ort darf maximal {1} Zeichen lang sein.")]
  public string? Ort { get; set; }

  /// <summary>Holt oder setzt Telefon.</summary>
  [Display(Name = "Telefon", Description = "Telefonnummer")]
  //// [Required(ErrorMessage = "Telefon muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Telefon darf maximal {1} Zeichen lang sein.")]
  public string? Telefon { get; set; }

  /// <summary>Holt oder setzt Fax.</summary>
  [Display(Name = "Fax", Description = "Faxnummer bzw. weitere Telefonnummer")]
  //// [Required(ErrorMessage = "Fax muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Fax darf maximal {1} Zeichen lang sein.")]
  public string? Fax { get; set; }

  /// <summary>Holt oder setzt Mobil.</summary>
  [Display(Name = "Mobil", Description = "Handy-Nummer")]
  //// [Required(ErrorMessage = "Mobil muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Mobil darf maximal {1} Zeichen lang sein.")]
  public string? Mobil { get; set; }

  /// <summary>Holt oder setzt Homepage.</summary>
  [Display(Name = "Homepage", Description = "URL der Homepage")]
  //// [Required(ErrorMessage = "Homepage muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Homepage darf maximal {1} Zeichen lang sein.")]
  public string? Homepage { get; set; }

  /// <summary>Holt oder setzt Email.</summary>
  [Display(Name = "Email", Description = "Email-Adresse")]
  //// [Required(ErrorMessage = "Email muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Email darf maximal {1} Zeichen lang sein.")]
  public string? Email { get; set; }

  /// <summary>Holt oder setzt Bemerkung.</summary>
  [Display(Name = "Bemerkung", Description = "")]
  //// [Required(ErrorMessage = "Bemerkung muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Bemerkung darf maximal {1} Zeichen lang sein.")]
  public string? Notiz { get; set; }

  /// <summary>Holt oder setzt Sitz-Status.</summary>
  [Display(Name = "Sitz-Status", Description = "")]
  //// [Required(ErrorMessage = "Sitz-Status muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Sitz-Status darf maximal {1} Zeichen lang sein.")]
  public string? SitzStatus0 { get; set; }

  /// <summary>Holt oder setzt Aktuell.</summary>
  [Display(Name = "Aktuell", Description = "Sitz wird ausgedruckt")]
  //// [Required(ErrorMessage = "Aktuell muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Aktuell darf maximal {1} Zeichen lang sein.")]
  public string? SitzStatus1 { get; set; }

  /// <summary>Holt oder setzt Alt.</summary>
  [Display(Name = "Alt", Description = "Sitz wird nicht ausgedruckt")]
  //// [Required(ErrorMessage = "Alt muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Alt darf maximal {1} Zeichen lang sein.")]
  public string? SitzStatus2 { get; set; }

  /// <summary>Holt oder setzt # gleiche Adresse.</summary>
  [Display(Name = "# gleiche Adresse", Description = "Wie oft wird diese Adresse insgesamt verwendet?")]
  //// [Required(ErrorMessage = "# gleiche Adresse muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "# gleiche Adresse darf maximal {1} Zeichen lang sein.")]
  public string? AdresseAnzahl { get; set; }

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

  /// <summary>Holt oder setzt OK.</summary>
  [Display(Name = "_OK", Description = "Dialog mit Speichern schließen")]
  //// [Required(ErrorMessage = "OK muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "OK darf maximal {1} Zeichen lang sein.")]
  public string? Ok { get; set; }

  /// <summary>Holt oder setzt Adresse Duplizieren.</summary>
  [Display(Name = "Adresse Duplizieren", Description = "Aktuelle Adresse so kopieren, dass die Daten bei bestehenden Verwendungen nicht geändert werden")]
  //// [Required(ErrorMessage = "Adresse Duplizieren muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Adresse Duplizieren darf maximal {1} Zeichen lang sein.")]
  public string? AdresseDupl { get; set; }

  /// <summary>Holt oder setzt Adresse Wechseln.</summary>
  [Display(Name = "Adresse _Wechseln", Description = "Andere Adressdaten auswählen")]
  //// [Required(ErrorMessage = "Adresse Wechseln muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Adresse Wechseln darf maximal {1} Zeichen lang sein.")]
  public string? AdresseWechseln { get; set; }

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
      // Nummer = "";
    }

    // TODO SetMandatoryHiddenReadonly(nameof(Nummer), true, false, true, false);
    // SetMandatoryHiddenReadonly(nameof(Thema), true, false, mode == Delete, mode == New);
    // SetMandatoryHiddenReadonly(nameof(Nummer), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Titel), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Vorname), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Praedikat), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Name1), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Name2), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Geschlecht0), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Geschlecht1), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Geschlecht2), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Geschlecht3), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Geburt), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(PersonStatus0), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(PersonStatus1), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(PersonStatus2), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Name), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Strasse), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Hausnr), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Postfach), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Staat), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Plz), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Ort), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Telefon), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Fax), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Mobil), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Homepage), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Email), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Notiz), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(SitzStatus0), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(SitzStatus1), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(SitzStatus2), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(AdresseAnzahl), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Angelegt), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Geaendert), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(AdresseDupl), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(AdresseWechseln), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Angelegt), false, mode == New, true);
    SetMandatoryHiddenReadonly(nameof(Geaendert), false, mode == New, true);
    SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, mode == Delete);
    SetMandatoryHiddenReadonly(nameof(Abbrechen), false, false, false, false);
  }
}
