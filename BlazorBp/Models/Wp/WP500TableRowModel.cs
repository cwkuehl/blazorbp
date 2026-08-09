// <copyright file="WP500TableRowModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Wp;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// TodoModel-Klasse für Formular WP500 Stände.
/// TODO Durch passendes Model ersetzen und löschen.
/// </summary>
[Serializable]
public class WP500TodoModel
{
  /// <summary>Holt oder setzt Nr.</summary>
  [Display(Name = "Nr.", Description = "Nummer")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt die Spalte Wertpapier.</summary>
  public string? Wertpapier { get; set; }

  /// <summary>Holt oder setzt die Spalte Datum.</summary>
  public string? Valuta { get; set; }

  /// <summary>Holt oder setzt die Spalte Betrag.</summary>
  public string? Betrag { get; set; }

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
/// Model-Klasse für eine Zeile in der Tabelle von Formular WP500 Stände.
/// </summary>
[Serializable]
public class WP500TableRowModel : TableRowModelBase
{
  /// <summary>Holt oder setzt Nr.</summary>
  [Display(Name = "Nr.", Description = "Nummer")]
  public string? Nummer { get { return Id; } set { Id = value; } }

  /// <summary>Holt oder setzt Wertpapier.</summary>
  [Display(Name = "_Wertpapier", Description = "Bezug zum Wertpapier")]
  //// [Required(ErrorMessage = "Wertpapier muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Wertpapier darf maximal {1} Zeichen lang sein.")]
  public string? Wertpapier { get; set; }

  /// <summary>Holt oder setzt Datum.</summary>
  [Display(Name = "_Datum", Description = "")]
  //// [Required(ErrorMessage = "Datum muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Datum darf maximal {1} Zeichen lang sein.")]
  public string? Valuta { get; set; }

  /// <summary>Holt oder setzt Betrag.</summary>
  [Display(Name = "_Betrag", Description = "Kurs am Datum")]
  //// [Required(ErrorMessage = "Betrag muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Betrag darf maximal {1} Zeichen lang sein.")]
  public string? Betrag { get; set; }

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
  public WP500TodoModel To(ServiceDaten daten)
  {
    return new WP500TodoModel
    {
      // TODO Mandant_Nr = daten.MandantNr,
      Wertpapier = Wertpapier,
      Valuta = Valuta,
      Betrag = Betrag,
      Angelegt_Am = AngelegtAm,
      Angelegt_Von = AngelegtVon,
      Geaendert_Am = GeaendertAm,
      Geaendert_Von = GeaendertVon,
    };
  }

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public static WP500TableRowModel From(WP500TodoModel m)
  {
    return new WP500TableRowModel
    {
      Nummer = m.Nummer,
      Wertpapier = m.Wertpapier,
      Valuta = m.Valuta,
      Betrag = m.Betrag,
      AngelegtAm = m.Angelegt_Am,
      AngelegtVon = m.Angelegt_Von,
      GeaendertAm = m.Geaendert_Am,
      GeaendertVon = m.Geaendert_Von,
    };
  }
}
