// <copyright file="FZ250TableRowModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Fz;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// TodoModel-Klasse für Formular FZ250 Fahrradstände.
/// TODO Durch passendes Model ersetzen und löschen.
/// </summary>
[Serializable]
public class FZ250TodoModel
{
  /// <summary>Holt oder setzt die Spalte Nr..</summary>
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt die Spalte Fahrrad.</summary>
  public string? Fahrrad { get; set; }

  /// <summary>Holt oder setzt die Spalte Datum.</summary>
  public string? Datum { get; set; }

  /// <summary>Holt oder setzt die Spalte Zähler.</summary>
  public string? Zaehler { get; set; }

  /// <summary>Holt oder setzt die Spalte Km.</summary>
  public string? Km { get; set; }

  /// <summary>Holt oder setzt die Spalte Schnitt.</summary>
  public string? Schnitt { get; set; }

  /// <summary>Holt oder setzt die Spalte Beschreibung.</summary>
  public string? Beschreibung { get; set; }

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
/// Model-Klasse für eine Zeile in der Tabelle von Formular FZ250 Fahrradstände.
/// </summary>
[Serializable]
public class FZ250TableRowModel : TableRowModelBase
{
  /// <summary>Holt oder setzt Nr..</summary>
  [Display(Name = "Nr.", Description = "Fahrradstand-Nr.")]
  //// [Required(ErrorMessage = "Nr. muss angegeben werden.")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt Fahrrad.</summary>
  [Display(Name = "_Fahrrad", Description = "Fahrrad")]
  //// [Required(ErrorMessage = "Fahrrad muss angegeben werden.")]
  public string? Fahrrad { get; set; }

  /// <summary>Holt oder setzt Datum.</summary>
  [Display(Name = "_Datum", Description = "")]
  //// [Required(ErrorMessage = "Datum muss angegeben werden.")]
  public string? Datum { get; set; }

  /// <summary>Holt oder setzt Zähler.</summary>
  [Display(Name = "_Zähler", Description = "Zählerstand")]
  //// [Required(ErrorMessage = "Zähler muss angegeben werden.")]
  public string? Zaehler { get; set; }

  /// <summary>Holt oder setzt Km.</summary>
  [Display(Name = "_Km", Description = "Tages- oder Wochen-km")]
  //// [Required(ErrorMessage = "Km muss angegeben werden.")]
  public string? Km { get; set; }

  /// <summary>Holt oder setzt Schnitt.</summary>
  [Display(Name = "_Schnitt", Description = "Durchschnittsgeschwindigkeit")]
  //// [Required(ErrorMessage = "Schnitt muss angegeben werden.")]
  public string? Schnitt { get; set; }

  /// <summary>Holt oder setzt Beschreibung.</summary>
  [Display(Name = "_Beschreibung", Description = "Beschreibung")]
  //// [Required(ErrorMessage = "Beschreibung muss angegeben werden.")]
  public string? Beschreibung { get; set; }

  /// <summary>Holt oder setzt Angelegt am.</summary>
  [Display(Name = "Angelegt am", Description = "Der Zeitpunkt der Anlage")]
  //// [Required(ErrorMessage = "Angelegt am muss angegeben werden.")]
  public DateTime? AngelegtAm { get; set; }

  /// <summary>Holt oder setzt Angelegt von.</summary>
  [Display(Name = "Angelegt von", Description = "Die Benutzer-ID der Anlage")]
  //// [Required(ErrorMessage = "Angelegt von muss angegeben werden.")]
  public string? AngelegtVon { get; set; }

  /// <summary>Holt oder setzt Geändert am.</summary>
  [Display(Name = "Geändert am", Description = "Der Zeitpunkt der letzten Änderung")]
  //// [Required(ErrorMessage = "Geändert am muss angegeben werden.")]
  public DateTime? GeaendertAm { get; set; }

  /// <summary>Holt oder setzt Geändert von.</summary>
  [Display(Name = "Geändert von", Description = "Die Benutzer-ID der letzten Änderung")]
  //// [Required(ErrorMessage = "Geändert von muss angegeben werden.")]
  public string? GeaendertVon { get; set; }

  /// <summary>Kopiert die Werte in ein Model.</summary>
  /// <param name="daten">Service-Daten für den Datenbankzugriff.</param>
  public FZ250TodoModel To(ServiceDaten daten)
  {
    return new FZ250TodoModel
    {
      // TODO Mandant_Nr = daten.MandantNr,
      Nummer = Nummer,
      Fahrrad = Fahrrad,
      Datum = Datum,
      Zaehler = Zaehler,
      Km = Km,
      Schnitt = Schnitt,
      Beschreibung = Beschreibung,
      Angelegt_Am = AngelegtAm,
      Angelegt_Von = AngelegtVon,
      Geaendert_Am = GeaendertAm,
      Geaendert_Von = GeaendertVon,
    };
  }

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public static FZ250TableRowModel From(FZ250TodoModel m)
  {
    return new FZ250TableRowModel
    {
      Nummer = m.Nummer,
      Fahrrad = m.Fahrrad,
      Datum = m.Datum,
      Zaehler = m.Zaehler,
      Km = m.Km,
      Schnitt = m.Schnitt,
      Beschreibung = m.Beschreibung,
      AngelegtAm = m.Angelegt_Am,
      AngelegtVon = m.Angelegt_Von,
      GeaendertAm = m.Geaendert_Am,
      GeaendertVon = m.Geaendert_Von,
    };
  }
}
