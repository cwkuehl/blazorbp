// <copyright file="AD100TableRowModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Forms.Models.Ad;

using System.ComponentModel.DataAnnotations;
using BlazorSpa.Core.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorSpa.Core.Base.DialogTypeEnum;

/// <summary>
/// TodoModel-Klasse für Formular AD100 Personen.
/// TODO Durch passendes Model ersetzen und löschen.
/// </summary>
[Serializable]
public class AD100TodoModel
{
  /// <summary>Holt oder setzt Nr.</summary>
  [Display(Name = "Nr.", Description = "Nummer")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt SitzNr.</summary>
  [Display(Name = "Nr.", Description = "Nummer")]
  public string? SitzNr { get; set; }

  /// <summary>Holt oder setzt AdressNr.</summary>
  public string? AdressNr { get; set; }

  /// <summary>Holt oder setzt die Spalte Titel.</summary>
  public string? Titel { get; set; }

  /// <summary>Holt oder setzt die Spalte Vorname.</summary>
  public string? Vorname { get; set; }

  /// <summary>Holt oder setzt die Spalte Prädikat.</summary>
  public string? Praedikat { get; set; }

  /// <summary>Holt oder setzt die Spalte (Nach-)Name.</summary>
  public string? Name1 { get; set; }

  /// <summary>Holt oder setzt die Spalte Name 2.</summary>
  public string? Name2 { get; set; }

  /// <summary>Holt oder setzt die Spalte Geschlecht.</summary>
  public string? Geschlecht0 { get; set; }

  /// <summary>Holt oder setzt die Spalte Neutrum.</summary>
  public string? Geschlecht1 { get; set; }

  /// <summary>Holt oder setzt die Spalte Männlich.</summary>
  public string? Geschlecht2 { get; set; }

  /// <summary>Holt oder setzt die Spalte Weiblich.</summary>
  public string? Geschlecht3 { get; set; }

  /// <summary>Holt oder setzt die Spalte Geburt.</summary>
  public string? Geburt { get; set; }

  /// <summary>Holt oder setzt die Spalte Person-Status.</summary>
  public string? PersonStatus0 { get; set; }

  /// <summary>Holt oder setzt die Spalte Aktuell.</summary>
  public string? PersonStatus1 { get; set; }

  /// <summary>Holt oder setzt die Spalte Alt.</summary>
  public string? PersonStatus2 { get; set; }

  /// <summary>Holt oder setzt die Spalte Sitz.</summary>
  public string? Name { get; set; }

  /// <summary>Holt oder setzt die Spalte Straße.</summary>
  public string? Strasse { get; set; }

  /// <summary>Holt oder setzt die Spalte Hausnr..</summary>
  public string? Hausnr { get; set; }

  /// <summary>Holt oder setzt die Spalte Postfach.</summary>
  public string? Postfach { get; set; }

  /// <summary>Holt oder setzt die Spalte Staat.</summary>
  public string? Staat { get; set; }

  /// <summary>Holt oder setzt die Spalte Plz.</summary>
  public string? Plz { get; set; }

  /// <summary>Holt oder setzt die Spalte Ort.</summary>
  public string? Ort { get; set; }

  /// <summary>Holt oder setzt die Spalte Telefon.</summary>
  public string? Telefon { get; set; }

  /// <summary>Holt oder setzt die Spalte Fax.</summary>
  public string? Fax { get; set; }

  /// <summary>Holt oder setzt die Spalte Mobil.</summary>
  public string? Mobil { get; set; }

  /// <summary>Holt oder setzt die Spalte Homepage.</summary>
  public string? Homepage { get; set; }

  /// <summary>Holt oder setzt die Spalte Email.</summary>
  public string? Email { get; set; }

  /// <summary>Holt oder setzt die Spalte Bemerkung.</summary>
  public string? Notiz { get; set; }

  /// <summary>Holt oder setzt die Spalte Sitz-Status.</summary>
  public string? SitzStatus0 { get; set; }

  /// <summary>Holt oder setzt die Spalte Aktuell.</summary>
  public string? SitzStatus1 { get; set; }

  /// <summary>Holt oder setzt die Spalte Alt.</summary>
  public string? SitzStatus2 { get; set; }

  /// <summary>Holt oder setzt die Spalte Angelegt_Am.</summary>
  public DateTime? Angelegt_Am { get; set; }

  /// <summary>Holt oder setzt die Spalte Angelegt_Von.</summary>
  public string? Angelegt_Von { get; set; }

  /// <summary>Holt oder setzt die Spalte Geaendert_Am.</summary>
  public DateTime? Geaendert_Am { get; set; }

  /// <summary>Holt oder setzt die Spalte Geaendert_Von.</summary>
  public string? Geaendert_Von { get; set; }
}

/// <summary>
/// Model-Klasse für eine Zeile in der Tabelle von Formular AD100 Personen.
/// </summary>
[Serializable]
public class AD100TableRowModel : TableRowModelBase
{
  /// <summary>Holt oder setzt Nr.</summary>
  [Display(Name = "Nrn. (PSA)", Description = "Person-Nr.")]
  public string? Nummer
  {
    get { return Id; }
    set { Id = value; }
  }

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

  /// <summary>Holt oder setzt Angelegt am.</summary>
  [Display(Name = "Angelegt am", Description = "Der Zeitpunkt der Anlage")]
  //// [Required(ErrorMessage = "Angelegt am muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Angelegt am darf maximal {1} Zeichen lang sein.")]
  public DateTime? AngelegtAm { get; set; }

  /// <summary>Holt oder setzt Angelegt von.</summary>
  [Display(Name = "Angelegt von", Description = "Die Benutzer-ID der Anlage")]
  //// [Required(ErrorMessage = "Angelegt von muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Angelegt von darf maximal {1} Zeichen lang sein.")]
  public string? AngelegtVon { get; set; }

  /// <summary>Holt oder setzt Geändert am.</summary>
  [Display(Name = "Geändert am", Description = "Der Zeitpunkt der letzten Änderung")]
  //// [Required(ErrorMessage = "Geändert am muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Geändert am darf maximal {1} Zeichen lang sein.")]
  public DateTime? GeaendertAm { get; set; }

  /// <summary>Holt oder setzt Geändert von.</summary>
  [Display(Name = "Geändert von", Description = "Die Benutzer-ID der letzten Änderung")]
  //// [Required(ErrorMessage = "Geändert von muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Geändert von darf maximal {1} Zeichen lang sein.")]
  public string? GeaendertVon { get; set; }

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  /// <returns>Neues Model.</returns>
  public static AD100TableRowModel From(AD100TodoModel m)
  {
    return new AD100TableRowModel
    {
      Nummer = m.Nummer,
      Titel = m.Titel,
      Vorname = m.Vorname,
      Praedikat = m.Praedikat,
      Name1 = m.Name1,
      Name2 = m.Name2,
      Geschlecht0 = m.Geschlecht0,
      Geschlecht1 = m.Geschlecht1,
      Geschlecht2 = m.Geschlecht2,
      Geschlecht3 = m.Geschlecht3,
      Geburt = m.Geburt,
      PersonStatus0 = m.PersonStatus0,
      PersonStatus1 = m.PersonStatus1,
      PersonStatus2 = m.PersonStatus2,
      Name = m.Name,
      Strasse = m.Strasse,
      Hausnr = m.Hausnr,
      Postfach = m.Postfach,
      Staat = m.Staat,
      Plz = m.Plz,
      Ort = m.Ort,
      Telefon = m.Telefon,
      Fax = m.Fax,
      Mobil = m.Mobil,
      Homepage = m.Homepage,
      Email = m.Email,
      Notiz = m.Notiz,
      SitzStatus0 = m.SitzStatus0,
      SitzStatus1 = m.SitzStatus1,
      SitzStatus2 = m.SitzStatus2,
      AngelegtAm = m.Angelegt_Am,
      AngelegtVon = m.Angelegt_Von,
      GeaendertAm = m.Geaendert_Am,
      GeaendertVon = m.Geaendert_Von,
    };
  }

  /// <summary>Kopiert die Werte in ein Model.</summary>
  /// <param name="daten">Service-Daten für den Datenbankzugriff.</param>
  /// <returns>Neues Model.</returns>
  public AD100TodoModel To(ServiceDaten daten)
  {
    return new AD100TodoModel
    {
      Nummer = Nummer,
      Titel = Titel,
      Vorname = Vorname,
      Praedikat = Praedikat,
      Name1 = Name1,
      Name2 = Name2,
      Geschlecht0 = Geschlecht0,
      Geschlecht1 = Geschlecht1,
      Geschlecht2 = Geschlecht2,
      Geschlecht3 = Geschlecht3,
      Geburt = Geburt,
      PersonStatus0 = PersonStatus0,
      PersonStatus1 = PersonStatus1,
      PersonStatus2 = PersonStatus2,
      Name = Name,
      Strasse = Strasse,
      Hausnr = Hausnr,
      Postfach = Postfach,
      Staat = Staat,
      Plz = Plz,
      Ort = Ort,
      Telefon = Telefon,
      Fax = Fax,
      Mobil = Mobil,
      Homepage = Homepage,
      Email = Email,
      Notiz = Notiz,
      SitzStatus0 = SitzStatus0,
      SitzStatus1 = SitzStatus1,
      SitzStatus2 = SitzStatus2,
      Angelegt_Am = AngelegtAm,
      Angelegt_Von = AngelegtVon,
      Geaendert_Am = GeaendertAm,
      Geaendert_Von = GeaendertVon,
    };
  }
}
