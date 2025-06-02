// <copyright file="FZ200TableRowModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Fz;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// TodoModel-Klasse für Formular FZ200 Fahrräder.
/// TODO Durch passendes Model ersetzen und löschen.
/// </summary>
[Serializable]
public class FZ200TodoModel
{
  /// <summary>Holt oder setzt die Spalte Nr..</summary>
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt die Spalte Bezeichnung.</summary>
  public string? Bezeichnung { get; set; }

  /// <summary>Holt oder setzt die Spalte Typ.</summary>
  public string? Typ0 { get; set; }

  /// <summary>Holt oder setzt die Spalte Tour.</summary>
  public string? Typ1 { get; set; }

  /// <summary>Holt oder setzt die Spalte Wöchentlich.</summary>
  public string? Typ2 { get; set; }

  /// <summary>Holt oder setzt die Spalte Angelegt_Am. TODO DateTime?</summary>
  public string? Angelegt_Am { get; set; }

  /// <summary>Holt oder setzt die Spalte Angelegt_Von.</summary>
  public string? Angelegt_Von { get; set; }

  /// <summary>Holt oder setzt die Spalte Geaendert_Am. TODO DateTime?</summary>
  public string? Geaendert_Am { get; set; }

  /// <summary>Holt oder setzt die Spalte Geaendert_Von.</summary>
  public string? Geaendert_Von { get; set; }
}

/// <summary>
/// Model-Klasse für eine Zeile in der Tabelle von Formular FZ200 Fahrräder.
/// </summary>
[Serializable]
public class FZ200TableRowModel : TableRowModelBase
{
  /// <summary>Holt oder setzt Nr..</summary>
  [Display(Name = "Nr.", Description = "Fahrrad-Nr.")]
  //// [Required(ErrorMessage = "Nr. muss angegeben werden.")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt Bezeichnung.</summary>
  [Display(Name = "Bezeichnung", Description = "Bezeichnung")]
  //// [Required(ErrorMessage = "Bezeichnung muss angegeben werden.")]
  public string? Bezeichnung { get; set; }

  /// <summary>Holt oder setzt Typ.</summary>
  [Display(Name = "Typ", Description = "")]
  //// [Required(ErrorMessage = "Typ muss angegeben werden.")]
  public string? Typ0 { get; set; }

  /// <summary>Holt oder setzt Tour.</summary>
  [Display(Name = "Tour", Description = "Tageswerte")]
  //// [Required(ErrorMessage = "Tour muss angegeben werden.")]
  public string? Typ1 { get; set; }

  /// <summary>Holt oder setzt Wöchentlich.</summary>
  [Display(Name = "Wöchentlich", Description = "Wochenwerte")]
  //// [Required(ErrorMessage = "Wöchentlich muss angegeben werden.")]
  public string? Typ2 { get; set; }

  /// <summary>Holt oder setzt Angelegt am.</summary>
  [Display(Name = "Angelegt am", Description = "Der Zeitpunkt der Anlage")]
  //// [Required(ErrorMessage = "Angelegt am muss angegeben werden.")]
  public string? AngelegtAm { get; set; }

  /// <summary>Holt oder setzt Angelegt von.</summary>
  [Display(Name = "Angelegt von", Description = "Die Benutzer-ID der Anlage")]
  //// [Required(ErrorMessage = "Angelegt von muss angegeben werden.")]
  public string? AngelegtVon { get; set; }

  /// <summary>Holt oder setzt Geändert am.</summary>
  [Display(Name = "Geändert am", Description = "Der Zeitpunkt der letzten Änderung")]
  //// [Required(ErrorMessage = "Geändert am muss angegeben werden.")]
  public string? GeaendertAm { get; set; }

  /// <summary>Holt oder setzt Geändert von.</summary>
  [Display(Name = "Geändert von", Description = "Die Benutzer-ID der letzten Änderung")]
  //// [Required(ErrorMessage = "Geändert von muss angegeben werden.")]
  public string? GeaendertVon { get; set; }

  /// <summary>Kopiert die Werte in ein Model.</summary>
  /// <param name="daten">Service-Daten für den Datenbankzugriff.</param>
  public FZ200TodoModel To(ServiceDaten daten)
  {
    return new FZ200TodoModel
    {
      // TODO Mandant_Nr = daten.MandantNr,
      Nummer = Nummer,
      Bezeichnung = Bezeichnung,
      Typ0 = Typ0,
      Typ1 = Typ1,
      Typ2 = Typ2,
      Angelegt_Am = AngelegtAm,
      Angelegt_Von = AngelegtVon,
      Geaendert_Am = GeaendertAm,
      Geaendert_Von = GeaendertVon,
    };
  }

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public static FZ200TableRowModel From(FZ200TodoModel m)
  {
    return new FZ200TableRowModel
    {
      Nummer = m.Nummer,
      Bezeichnung = m.Bezeichnung,
      Typ0 = m.Typ0,
      Typ1 = m.Typ1,
      Typ2 = m.Typ2,
      AngelegtAm = m.Angelegt_Am,
      AngelegtVon = m.Angelegt_Von,
      GeaendertAm = m.Geaendert_Am,
      GeaendertVon = m.Geaendert_Von,
    };
  }
}
