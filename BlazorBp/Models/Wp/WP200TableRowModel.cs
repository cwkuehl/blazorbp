// <copyright file="WP200TableRowModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Wp;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// TodoModel-Klasse für Formular WP200 Wertpapiere.
/// TODO Durch passendes Model ersetzen und löschen.
/// </summary>
[Serializable]
public class WP200TodoModel
{
  /// <summary>Holt oder setzt die Spalte Nr..</summary>
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt die Spalte Bezeichnung.</summary>
  public string? Bezeichnung { get; set; }

  /// <summary>Holt oder setzt die Spalte Provider.</summary>
  public string? Provider { get; set; }

  /// <summary>Holt oder setzt die Spalte Kürzel.</summary>
  public string? Kuerzel { get; set; }

  /// <summary>Holt oder setzt die Spalte Status.</summary>
  public string? Status { get; set; }

  /// <summary>Holt oder setzt die Spalte Aktueller Kurs.</summary>
  public string? AktKurs { get; set; }

  /// <summary>Holt oder setzt die Spalte Stop-Kurs.</summary>
  public string? StopKurs { get; set; }

  /// <summary>Holt oder setzt die Spalte Kursziel.</summary>
  public string? SignalKurs1 { get; set; }

  /// <summary>Holt oder setzt die Spalte Letztes Muster.</summary>
  public string? Muster { get; set; }

  /// <summary>Holt oder setzt die Spalte Typ.</summary>
  public string? Typ { get; set; }

  /// <summary>Holt oder setzt die Spalte Währung.</summary>
  public string? Waehrung { get; set; }

  /// <summary>Holt oder setzt die Spalte Sortierung.</summary>
  public string? Sortierung { get; set; }

  /// <summary>Holt oder setzt die Spalte Relation.</summary>
  public string? Relation { get; set; }

  /// <summary>Holt oder setzt die Spalte Notiz.</summary>
  public string? Notiz { get; set; }

  /// <summary>Holt oder setzt die Spalte Anlage erstellen.</summary>
  public string? Anlage { get; set; }

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
/// Model-Klasse für eine Zeile in der Tabelle von Formular WP200 Wertpapiere.
/// </summary>
[Serializable]
public class WP200TableRowModel : TableRowModelBase
{
  /// <summary>Holt oder setzt Nr..</summary>
  [Display(Name = "Nr.", Description = "Wertpapier-Nr.")]
  //// [Required(ErrorMessage = "Nr. muss angegeben werden.")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt Bezeichnung.</summary>
  [Display(Name = "_Bezeichnung", Description = "Bezeichnung")]
  //// [Required(ErrorMessage = "Bezeichnung muss angegeben werden.")]
  public string? Bezeichnung { get; set; }

  /// <summary>Holt oder setzt Provider.</summary>
  [Display(Name = "_Provider", Description = "Provider für Kursabfrage")]
  //// [Required(ErrorMessage = "Provider muss angegeben werden.")]
  public string? Provider { get; set; }

  /// <summary>Holt oder setzt Kürzel.</summary>
  [Display(Name = "_Kürzel", Description = "Kürzel für Kursabfrage beim Provider")]
  //// [Required(ErrorMessage = "Kürzel muss angegeben werden.")]
  public string? Kuerzel { get; set; }

  /// <summary>Holt oder setzt Status.</summary>
  [Display(Name = "_Status", Description = "Status für Berechnung")]
  //// [Required(ErrorMessage = "Status muss angegeben werden.")]
  public string? Status { get; set; }

  /// <summary>Holt oder setzt Aktueller Kurs.</summary>
  [Display(Name = "Aktueller Kurs", Description = "Aktueller Kurs aus letzter Bewertung")]
  //// [Required(ErrorMessage = "Aktueller Kurs muss angegeben werden.")]
  public string? AktKurs { get; set; }

  /// <summary>Holt oder setzt Stop-Kurs.</summary>
  [Display(Name = "Stop-Kurs", Description = "Stop-Kurs aus letzter Bewertung")]
  //// [Required(ErrorMessage = "Stop-Kurs muss angegeben werden.")]
  public string? StopKurs { get; set; }

  /// <summary>Holt oder setzt Kursziel.</summary>
  [Display(Name = "Kurs_ziel", Description = "Manuelles Kursziel")]
  //// [Required(ErrorMessage = "Kursziel muss angegeben werden.")]
  public string? SignalKurs1 { get; set; }

  /// <summary>Holt oder setzt Letztes Muster.</summary>
  [Display(Name = "Letztes Muster", Description = "Letztes Signalmuster aus letzter Bewertung")]
  //// [Required(ErrorMessage = "Letztes Muster muss angegeben werden.")]
  public string? Muster { get; set; }

  /// <summary>Holt oder setzt Typ.</summary>
  [Display(Name = "_Typ", Description = "Aktie (wenn leer) oder Anleihe")]
  //// [Required(ErrorMessage = "Typ muss angegeben werden.")]
  public string? Typ { get; set; }

  /// <summary>Holt oder setzt Währung.</summary>
  [Display(Name = "_Währung", Description = "Währungskürzel für Kursabfrage; EUR, GBP, USD, ...")]
  //// [Required(ErrorMessage = "Währung muss angegeben werden.")]
  public string? Waehrung { get; set; }

  /// <summary>Holt oder setzt Sortierung.</summary>
  [Display(Name = "Sortierun_g", Description = "Zeichenkette für Sortierung")]
  //// [Required(ErrorMessage = "Sortierung muss angegeben werden.")]
  public string? Sortierung { get; set; }

  /// <summary>Holt oder setzt Relation.</summary>
  [Display(Name = "_Relation", Description = "Relation zu anderem Wertpapier, z.B. Index")]
  //// [Required(ErrorMessage = "Relation muss angegeben werden.")]
  public string? Relation { get; set; }

  /// <summary>Holt oder setzt Notiz.</summary>
  [Display(Name = "Notiz", Description = "")]
  //// [Required(ErrorMessage = "Notiz muss angegeben werden.")]
  public string? Notiz { get; set; }

  /// <summary>Holt oder setzt Anlage erstellen.</summary>
  [Display(Name = "Anlage erstellen", Description = "Soll für das Wertpapier auch eine Anlage erstellt werden?")]
  //// [Required(ErrorMessage = "Anlage erstellen muss angegeben werden.")]
  public string? Anlage { get; set; }

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
  public WP200TodoModel To(ServiceDaten daten)
  {
    return new WP200TodoModel
    {
      // TODO Mandant_Nr = daten.MandantNr,
      Nummer = Nummer,
      Bezeichnung = Bezeichnung,
      Provider = Provider,
      Kuerzel = Kuerzel,
      Status = Status,
      AktKurs = AktKurs,
      StopKurs = StopKurs,
      SignalKurs1 = SignalKurs1,
      Muster = Muster,
      Typ = Typ,
      Waehrung = Waehrung,
      Sortierung = Sortierung,
      Relation = Relation,
      Notiz = Notiz,
      Anlage = Anlage,
      Angelegt_Am = AngelegtAm,
      Angelegt_Von = AngelegtVon,
      Geaendert_Am = GeaendertAm,
      Geaendert_Von = GeaendertVon,
    };
  }

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public static WP200TableRowModel From(WP200TodoModel m)
  {
    return new WP200TableRowModel
    {
      Nummer = m.Nummer,
      Bezeichnung = m.Bezeichnung,
      Provider = m.Provider,
      Kuerzel = m.Kuerzel,
      Status = m.Status,
      AktKurs = m.AktKurs,
      StopKurs = m.StopKurs,
      SignalKurs1 = m.SignalKurs1,
      Muster = m.Muster,
      Typ = m.Typ,
      Waehrung = m.Waehrung,
      Sortierung = m.Sortierung,
      Relation = m.Relation,
      Notiz = m.Notiz,
      Anlage = m.Anlage,
      AngelegtAm = m.Angelegt_Am,
      AngelegtVon = m.Angelegt_Von,
      GeaendertAm = m.Geaendert_Am,
      GeaendertVon = m.Geaendert_Von,
    };
  }
}
