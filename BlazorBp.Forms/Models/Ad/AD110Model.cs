// <copyright file="AD110Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Forms.Models.Ad;

using System.ComponentModel.DataAnnotations;
using BlazorSpa.Base;
using BlazorSpa.Core.Base;
using BlazorSpa.Core.Models;
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
  [Display(Name = "Person-Nr.", Description = "Person-Nr.")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt Sitz-Nr.</summary>
  [Display(Name = "Sitz-Nr.", Description = "Sitz-Nr.")]
  public string? SitzNr { get; set; }

  /// <summary>Holt oder setzt Adress-Nr.</summary>
  [Display(Name = "Adress-Nr.", Description = "Adress-Nr.")]
  public string? AdressNr { get; set; }

  /// <summary>Holt oder setzt Titel.</summary>
  [Display(Name = "_Titel", Description = "Titel oder Beruf")]
  [MaxLength(40, ErrorMessage = "Titel darf maximal {1} Zeichen lang sein.")]
  public string? Titel { get; set; }

  /// <summary>Holt oder setzt Vorname.</summary>
  [Display(Name = "_Vorname", Description = "Vorname")]
  [MaxLength(40, ErrorMessage = "Vorname darf maximal {1} Zeichen lang sein.")]
  public string? Vorname { get; set; }

  /// <summary>Holt oder setzt Prädikat.</summary>
  [Display(Name = "_Prädikat", Description = "Prädikat")]
  [MaxLength(40, ErrorMessage = "Prädikat darf maximal {1} Zeichen lang sein.")]
  public string? Praedikat { get; set; }

  /// <summary>Holt oder setzt (Nach-)Name.</summary>
  [Display(Name = "(_Nach-)Name", Description = "Nachname oder Firmenname")]
  [Required(ErrorMessage = "(Nach-)Name muss angegeben werden.")]
  [MaxLength(40, ErrorMessage = "(Nach-)Name darf maximal {1} Zeichen lang sein.")]
  public string? Name1 { get; set; }

  /// <summary>Holt oder setzt Name 2.</summary>
  [Display(Name = "Name 2", Description = "2. Teil des Namens")]
  [MaxLength(40, ErrorMessage = "Name 2 darf maximal {1} Zeichen lang sein.")]
  public string? Name2 { get; set; }

  /// <summary>Holt oder setzt die Liste von Geschlecht.</summary>
  public List<ListItem>? AuswahlGeschlecht { get; set; }

  /// <summary>Holt oder setzt Geschlecht.</summary>
  [Display(Name = "Geschlecht", Description = "Geschlecht der Person oder Neutrum für Firma")]
  public string? Geschlecht { get; set; }

  /// <summary>Holt oder setzt Geburt.</summary>
  [Display(Name = "_Geburt", Description = "Geburtsdatum der Person")]
  public DateTime? Geburt { get; set; }

  /// <summary>Holt oder setzt die Liste von Person-Status.</summary>
  public List<ListItem>? AuswahlPersonStatus { get; set; }

  /// <summary>Holt oder setzt Person-Status.</summary>
  [Display(Name = "Person-Status", Description = "Legt fest, ob die Person ausgedruckt wird.")]
  public string? PersonStatus { get; set; }

  /// <summary>Holt oder setzt Sitz.</summary>
  [Display(Name = "S_itz", Description = "Bezeichnung für den Sitz")]
  [MaxLength(40, ErrorMessage = "Sitz darf maximal {1} Zeichen lang sein.")]
  public string? Name { get; set; }

  /// <summary>Holt oder setzt Straße.</summary>
  [Display(Name = "St_raße", Description = "Straße ohne Hausnummer")]
  [MaxLength(40, ErrorMessage = "Straße darf maximal {1} Zeichen lang sein.")]
  public string? Strasse { get; set; }

  /// <summary>Holt oder setzt Hausnr..</summary>
  [Display(Name = "Hausnr.", Description = "Hausnummer")]
  [MaxLength(20, ErrorMessage = "Hausnr. darf maximal {1} Zeichen lang sein.")]
  public string? Hausnr { get; set; }

  /// <summary>Holt oder setzt Postfach.</summary>
  [Display(Name = "Postfach", Description = "Postfach")]
  [MaxLength(10, ErrorMessage = "Postfach darf maximal {1} Zeichen lang sein.")]
  public string? Postfach { get; set; }

  /// <summary>Holt oder setzt Staat.</summary>
  [Display(Name = "Staat", Description = "Abkürzung für Staat, D für Deutschland")]
  [MaxLength(3, ErrorMessage = "Staat darf maximal {1} Zeichen lang sein.")]
  public string? Staat { get; set; }

  /// <summary>Holt oder setzt Plz.</summary>
  [Display(Name = "Plz", Description = "Postleitzahl")]
  [MaxLength(10, ErrorMessage = "Plz darf maximal {1} Zeichen lang sein.")]
  public string? Plz { get; set; }

  /// <summary>Holt oder setzt Ort.</summary>
  [Display(Name = "Ort", Description = "Ort")]
  //// [Required(ErrorMessage = "Ort muss angegeben werden.")]
  [MaxLength(40, ErrorMessage = "Ort darf maximal {1} Zeichen lang sein.")]
  public string? Ort { get; set; }

  /// <summary>Holt oder setzt Telefon.</summary>
  [Display(Name = "Telefon", Description = "Telefonnummer")]
  [MaxLength(40, ErrorMessage = "Telefon darf maximal {1} Zeichen lang sein.")]
  public string? Telefon { get; set; }

  /// <summary>Holt oder setzt Fax.</summary>
  [Display(Name = "Fax", Description = "Faxnummer bzw. weitere Telefonnummer")]
  [MaxLength(40, ErrorMessage = "Fax darf maximal {1} Zeichen lang sein.")]
  public string? Fax { get; set; }

  /// <summary>Holt oder setzt Mobil.</summary>
  [Display(Name = "Mobil", Description = "Handy-Nummer")]
  [MaxLength(40, ErrorMessage = "Mobil darf maximal {1} Zeichen lang sein.")]
  public string? Mobil { get; set; }

  /// <summary>Holt oder setzt Homepage.</summary>
  [Display(Name = "Homepage", Description = "URL der Homepage")]
  [MaxLength(100, ErrorMessage = "Homepage darf maximal {1} Zeichen lang sein.")]
  public string? Homepage { get; set; }

  /// <summary>Holt oder setzt Email.</summary>
  [Display(Name = "Email", Description = "Email-Adresse")]
  [MaxLength(40, ErrorMessage = "Email darf maximal {1} Zeichen lang sein.")]
  public string? Email { get; set; }

  /// <summary>Holt oder setzt Bemerkung.</summary>
  [Display(Name = "Bemerkung", Description = "")]
  [MaxLength(255, ErrorMessage = "Bemerkung darf maximal {1} Zeichen lang sein.")]
  public string? Notiz { get; set; }

  /// <summary>Holt oder setzt die Liste von Sitz-Status.</summary>
  public List<ListItem>? AuswahlSitzStatus { get; set; }

  /// <summary>Holt oder setzt Sitz-Status.</summary>
  [Display(Name = "Sitz-Status", Description = "Legt fest, ob der Sitz ausgedruckt wird.")]
  public string? SitzStatus { get; set; }

  /// <summary>Holt oder setzt # gleiche Adresse.</summary>
  [Display(Name = "# gleiche Adresse", Description = "Wie oft wird diese Adresse insgesamt verwendet?")]
  public string? AdresseAnzahl { get; set; }

  /// <summary>Holt oder setzt Angelegt.</summary>
  [Display(Name = "Angelegt", Description = "Datum, Uhrzeit und Benutzer, der die Daten angelegt hat")]
  public string? Angelegt { get; set; }

  /// <summary>Holt oder setzt Geändert.</summary>
  [Display(Name = "Geändert", Description = "Datum, Uhrzeit und Benutzer, der die Daten geändert hat")]
  public string? Geaendert { get; set; }

  /// <summary>Holt oder setzt OK.</summary>
  [Display(Name = "_OK", Description = "Dialog mit Speichern schließen")]
  public string? Ok { get; set; }

  /// <summary>Holt oder setzt Adresse Duplizieren.</summary>
  [Display(Name = "Adresse Duplizieren", Description = "Aktuelle Adresse so kopieren, dass die Daten bei bestehenden Verwendungen nicht geändert werden")]
  public string? AdresseDupl { get; set; }

  /// <summary>Holt oder setzt Adresse Wechseln.</summary>
  [Display(Name = "Adresse _Wechseln", Description = "Andere Adressdaten auswählen")]
  public string? AdresseWechseln { get; set; }

  /// <summary>Holt oder setzt Abbrechen.</summary>
  [Display(Name = "Abbre_chen", Description = "Dialog ohne Speichern schließen")]
  public string? Abbrechen { get; set; }

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public void From(AdSitz m)
  {
    (
      Nummer,
      SitzNr,
      AdressNr,
      Titel,
      Vorname,
      Praedikat,
      Name1,
      Name2,
      Geschlecht,
      Geburt,
      PersonStatus,
      Name,
      Postfach,
      Telefon,
      Fax,
      Mobil,
      Homepage,
      Email,
      Notiz,
      SitzStatus,
      Angelegt,
      Geaendert
    ) = (
      m.Person?.Uid,
      m.Uid,
      m.Address?.Uid,
      m.Person?.Titel,
      m.Person?.Vorname,
      m.Person?.Praedikat,
      m.Person?.Name1,
      m.Person?.Name2,
      m.Person?.Geschlecht,
      m.Person?.Geburt,
      Funktionen.ToString(m.Person?.Person_Status),
      m.Name,
      m.Postfach,
      m.Telefon,
      m.Fax,
      m.Mobil,
      m.Homepage,
      m.Email,
      m.Bemerkung,
      Funktionen.ToString(m.Sitz_Status),
      ModelBase.FormatDateOf(m.Angelegt_Am, m.Angelegt_Von),
      ModelBase.FormatDateOf(m.Geaendert_Am, m.Geaendert_Von)
    );
  }

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  public void SetMhrf(DialogTypeEnum mode)
  {
    if (mode == Copy2)
    {
      // Nummer = "";
      SitzNr = "";
      AdressNr = "";
    }
    SetMandatoryHiddenReadonly(nameof(Nummer), false, mode == New, true, false);
    SetMandatoryHiddenReadonly(nameof(SitzNr), false, mode == New, true, false);
    SetMandatoryHiddenReadonly(nameof(AdressNr), false, mode == New, true, false);
    SetMandatoryHiddenReadonly(nameof(Titel), false, false, mode == Delete, mode == New);
    SetMandatoryHiddenReadonly(nameof(Vorname), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Praedikat), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Name1), true, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Name2), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Geschlecht), true, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Geburt), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(PersonStatus), true, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Name), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Strasse), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Hausnr), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Postfach), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Staat), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Plz), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Ort), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Telefon), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Fax), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Mobil), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Homepage), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Email), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Notiz), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(SitzStatus), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(AdresseAnzahl), false, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Angelegt), false, mode == New, true);
    SetMandatoryHiddenReadonly(nameof(Geaendert), false, mode == New, true);
    SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, mode == Delete);
    SetMandatoryHiddenReadonly(nameof(AdresseDupl), false, mode == Delete, false, false);
    SetMandatoryHiddenReadonly(nameof(AdresseWechseln), false, mode == Delete, false, false);
    SetMandatoryHiddenReadonly(nameof(Abbrechen), false, false, false, false);
  }
}
