// <copyright file="WP400TableRowModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Forms.Models.Wp;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Core.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Core.Base.DialogTypeEnum;

/// <summary>
/// TodoModel-Klasse für Formular WP400 WP-Buchungen.
/// TODO Durch passendes Model ersetzen und löschen.
/// </summary>
[Serializable]
public class WP400TodoModel
{
  /// <summary>Holt oder setzt Nr.</summary>
  [Display(Name = "Nr.", Description = "Nummer")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt die Spalte Anlage.</summary>
  public string? Anlage { get; set; }

  /// <summary>Holt oder setzt die Spalte Datum.</summary>
  public string? Valuta { get; set; }

  /// <summary>Holt oder setzt die Spalte Preis.</summary>
  public string? Preis { get; set; }

  /// <summary>Holt oder setzt die Spalte Betrag.</summary>
  public string? Betrag { get; set; }

  /// <summary>Holt oder setzt die Spalte Anteile.</summary>
  public string? Anteile { get; set; }

  /// <summary>Holt oder setzt die Spalte Preis.</summary>
  public string? Preis2 { get; set; }

  /// <summary>Holt oder setzt die Spalte Zinsen.</summary>
  public string? Zinsen { get; set; }

  /// <summary>Holt oder setzt die Spalte Buchungstext.</summary>
  public string? BText { get; set; }

  /// <summary>Holt oder setzt die Spalte Letzte Buchung.</summary>
  public string? Buchung { get; set; }

  /// <summary>Holt oder setzt die Spalte Rabatt.</summary>
  public string? Rabatt { get; set; }

  /// <summary>Holt oder setzt die Spalte HH-Buchung.</summary>
  public string? Hhbuchung { get; set; }

  /// <summary>Holt oder setzt die Spalte Ändern.</summary>
  public string? Hhaendern { get; set; }

  /// <summary>Holt oder setzt die Spalte Storno.</summary>
  public string? Hhstorno { get; set; }

  /// <summary>Holt oder setzt die Spalte Valuta.</summary>
  public string? Hhvaluta { get; set; }

  /// <summary>Holt oder setzt die Spalte Betrag.</summary>
  public string? Hhbetrag { get; set; }

  /// <summary>Holt oder setzt die Spalte Ereignis.</summary>
  public string? Hhereignis { get; set; }

  /// <summary>Holt oder setzt die Spalte fixieren.</summary>
  public string? Fixtext { get; set; }

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
/// Model-Klasse für eine Zeile in der Tabelle von Formular WP400 WP-Buchungen.
/// </summary>
[Serializable]
public class WP400TableRowModel : TableRowModelBase
{

  /// <summary>Holt oder setzt Nr.</summary>
  [Display(Name = "Nr.", Description = "Nummer")]
  public string? Nummer { get { return Id; } set { Id = value; } }

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

  /// <summary>Holt oder setzt Letzte Buchung.</summary>
  [Display(Name = "Letzte Buchung", Description = "")]
  //// [Required(ErrorMessage = "Letzte Buchung muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Letzte Buchung darf maximal {1} Zeichen lang sein.")]
  public string? Buchung { get; set; }

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

  /// <summary>Kopiert die Werte in ein Model.</summary>
  /// <param name="daten">Service-Daten für den Datenbankzugriff.</param>
  public WP400TodoModel To(ServiceDaten daten)
  {
    return new WP400TodoModel
    {
      // TODO Mandant_Nr = daten.MandantNr,
      Nummer = Nummer,
      Anlage = Anlage,
      Valuta = Valuta,
      Preis = Preis,
      Betrag = Betrag,
      Anteile = Anteile,
      Preis2 = Preis2,
      Zinsen = Zinsen,
      BText = BText,
      Buchung = Buchung,
      Rabatt = Rabatt,
      Hhbuchung = Hhbuchung,
      Hhaendern = Hhaendern,
      Hhstorno = Hhstorno,
      Hhvaluta = Hhvaluta,
      Hhbetrag = Hhbetrag,
      Hhereignis = Hhereignis,
      Fixtext = Fixtext,
      Angelegt_Am = AngelegtAm,
      Angelegt_Von = AngelegtVon,
      Geaendert_Am = GeaendertAm,
      Geaendert_Von = GeaendertVon,
    };
  }

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public static WP400TableRowModel From(WP400TodoModel m)
  {
    return new WP400TableRowModel
    {
      Nummer = m.Nummer,
      Anlage = m.Anlage,
      Valuta = m.Valuta,
      Preis = m.Preis,
      Betrag = m.Betrag,
      Anteile = m.Anteile,
      Preis2 = m.Preis2,
      Zinsen = m.Zinsen,
      BText = m.BText,
      Buchung = m.Buchung,
      Rabatt = m.Rabatt,
      Hhbuchung = m.Hhbuchung,
      Hhaendern = m.Hhaendern,
      Hhstorno = m.Hhstorno,
      Hhvaluta = m.Hhvaluta,
      Hhbetrag = m.Hhbetrag,
      Hhereignis = m.Hhereignis,
      Fixtext = m.Fixtext,
      AngelegtAm = m.Angelegt_Am,
      AngelegtVon = m.Angelegt_Von,
      GeaendertAm = m.Geaendert_Am,
      GeaendertVon = m.Geaendert_Von,
    };
  }
}
