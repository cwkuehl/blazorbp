// <copyright file="HH300TableRowModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Hh;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// TodoModel-Klasse für Formular HH300 Ereignisse.
/// TODO Durch passendes Model ersetzen und löschen.
/// </summary>
[Serializable]
public class HH300TodoModel
{
  /// <summary>Holt oder setzt Nr.</summary>
  [Display(Name = "Nr.", Description = "Nummer")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt die Spalte Bezeichnung.</summary>
  public string? Bezeichnung { get; set; }

  /// <summary>Holt oder setzt die Spalte Kennzeichen.</summary>
  public string? Kennzeichen { get; set; }

  /// <summary>Holt oder setzt die Spalte Buchungstext.</summary>
  public string? EText { get; set; }

  /// <summary>Holt oder setzt die Spalte Sollkonto.</summary>
  public string? Sollkonto { get; set; }

  /// <summary>Holt oder setzt die Spalte Habenkonto.</summary>
  public string? Habenkonto { get; set; }

  /// <summary>Holt oder setzt die Spalte Kontentausch.</summary>
  public string? Kontentausch { get; set; }

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
/// Model-Klasse für eine Zeile in der Tabelle von Formular HH300 Ereignisse.
/// </summary>
[Serializable]
public class HH300TableRowModel : TableRowModelBase
{

  /// <summary>Holt oder setzt Nr.</summary>
  [Display(Name = "Nr.", Description = "Ereignis-Nr.")]
  public string? Nummer { get { return Id; } set { Id = value; } }

  /// <summary>Holt oder setzt Bezeichnung.</summary>
  [Display(Name = "_Bezeichnung", Description = "Bezeichnung")]
  //// [Required(ErrorMessage = "Bezeichnung muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Bezeichnung darf maximal {1} Zeichen lang sein.")]
  public string? Bezeichnung { get; set; }

  /// <summary>Holt oder setzt Kennzeichen.</summary>
  [Display(Name = "_Kennzeichen", Description = "Kennzeichen")]
  //// [Required(ErrorMessage = "Kennzeichen muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Kennzeichen darf maximal {1} Zeichen lang sein.")]
  public string? Kennzeichen { get; set; }

  /// <summary>Holt oder setzt Buchungstext.</summary>
  [Display(Name = "Buchungste_xt", Description = "Buchungstext")]
  //// [Required(ErrorMessage = "Buchungstext muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Buchungstext darf maximal {1} Zeichen lang sein.")]
  public string? EText { get; set; }

  /// <summary>Holt oder setzt Sollkonto.</summary>
  [Display(Name = "_Sollkonto", Description = "Sollkonto")]
  //// [Required(ErrorMessage = "Sollkonto muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Sollkonto darf maximal {1} Zeichen lang sein.")]
  public string? Sollkonto { get; set; }

  /// <summary>Holt oder setzt Habenkonto.</summary>
  [Display(Name = "_Habenkonto", Description = "Habenkonto")]
  //// [Required(ErrorMessage = "Habenkonto muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Habenkonto darf maximal {1} Zeichen lang sein.")]
  public string? Habenkonto { get; set; }

  /// <summary>Holt oder setzt Kontentausch.</summary>
  [Display(Name = "Kon_tentausch", Description = "Kontentausch")]
  //// [Required(ErrorMessage = "Kontentausch muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Kontentausch darf maximal {1} Zeichen lang sein.")]
  public string? Kontentausch { get; set; }

  /// <summary>Holt oder setzt Angelegt am.</summary>
  [Display(Name = "Angelegt am", Description = "Der Zeitpunkt der Anlage")]
  public DateTime? AngelegtAm { get; set; }

  /// <summary>Holt oder setzt Angelegt von.</summary>
  [Display(Name = "Angelegt von", Description = "Die Benutzer-ID der Anlage")]
  public string? AngelegtVon { get; set; }

  /// <summary>Holt oder setzt Geändert am.</summary>
  [Display(Name = "Geändert am", Description = "Der Zeitpunkt der letzten Änderung")]
  public DateTime? GeaendertAm { get; set; }

  /// <summary>Holt oder setzt Geändert von.</summary>
  [Display(Name = "Geändert von", Description = "Die Benutzer-ID der letzten Änderung")]
  public string? GeaendertVon { get; set; }

  /// <summary>Kopiert die Werte in ein Model.</summary>
  /// <param name="daten">Service-Daten für den Datenbankzugriff.</param>
  public HH300TodoModel To(ServiceDaten daten)
  {
    return new HH300TodoModel
    {
      Nummer = Nummer,
      Bezeichnung = Bezeichnung,
      Kennzeichen = Kennzeichen,
      EText = EText,
      Sollkonto = Sollkonto,
      Habenkonto = Habenkonto,
      Kontentausch = Kontentausch,
      Angelegt_Am = AngelegtAm,
      Angelegt_Von = AngelegtVon,
      Geaendert_Am = GeaendertAm,
      Geaendert_Von = GeaendertVon,
    };
  }

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public static HH300TableRowModel From(HH300TodoModel m)
  {
    return new HH300TableRowModel
    {
      Nummer = m.Nummer,
      Bezeichnung = m.Bezeichnung,
      Kennzeichen = m.Kennzeichen,
      EText = m.EText,
      Sollkonto = m.Sollkonto,
      Habenkonto = m.Habenkonto,
      Kontentausch = m.Kontentausch,
      AngelegtAm = m.Angelegt_Am,
      AngelegtVon = m.Angelegt_Von,
      GeaendertAm = m.Geaendert_Am,
      GeaendertVon = m.Geaendert_Von,
    };
  }
}
