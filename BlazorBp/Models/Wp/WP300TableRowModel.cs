// <copyright file="WP300TableRowModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Wp;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// TodoModel-Klasse für Formular WP300 Konfigurationen.
/// TODO Durch passendes Model ersetzen und löschen.
/// </summary>
[Serializable]
public class WP300TodoModel
{
  /// <summary>Holt oder setzt die Spalte Nr..</summary>
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt die Spalte Bezeichnung.</summary>
  public string? Bezeichnung { get; set; }

  /// <summary>Holt oder setzt die Spalte Boxgröße.</summary>
  public string? Box { get; set; }

  /// <summary>Holt oder setzt die Spalte Skala.</summary>
  public string? Skala { get; set; }

  /// <summary>Holt oder setzt die Spalte Umkehr.</summary>
  public string? Umkehr { get; set; }

  /// <summary>Holt oder setzt die Spalte Methode.</summary>
  public string? Methode { get; set; }

  /// <summary>Holt oder setzt die Spalte Dauer.</summary>
  public string? Dauer { get; set; }

  /// <summary>Holt oder setzt die Spalte Relativ.</summary>
  public string? Relativ { get; set; }

  /// <summary>Holt oder setzt die Spalte Status.</summary>
  public string? Status { get; set; }

  /// <summary>Holt oder setzt die Spalte Notiz.</summary>
  public string? Notiz { get; set; }

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
/// Model-Klasse für eine Zeile in der Tabelle von Formular WP300 Konfigurationen.
/// </summary>
[Serializable]
public class WP300TableRowModel : TableRowModelBase
{
  /// <summary>Holt oder setzt Nr..</summary>
  [Display(Name = "Nr.", Description = "Konfiguration-Nr.")]
  //// [Required(ErrorMessage = "Nr. muss angegeben werden.")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt Bezeichnung.</summary>
  [Display(Name = "_Bezeichnung", Description = "Bezeichnung")]
  //// [Required(ErrorMessage = "Bezeichnung muss angegeben werden.")]
  public string? Bezeichnung { get; set; }

  /// <summary>Holt oder setzt Boxgröße.</summary>
  [Display(Name = "Bo_xgröße", Description = "Boxgröße absolut oder prozentual")]
  //// [Required(ErrorMessage = "Boxgröße muss angegeben werden.")]
  public string? Box { get; set; }

  /// <summary>Holt oder setzt Umkehr.</summary>
  [Display(Name = "_Umkehr", Description = "Anzahl der Boxen für Umkehr")]
  //// [Required(ErrorMessage = "Umkehr muss angegeben werden.")]
  public string? Umkehr { get; set; }

  /// <summary>Holt oder setzt Methode.</summary>
  [Display(Name = "_Methode", Description = "Methode für Kursberechnung")]
  //// [Required(ErrorMessage = "Methode muss angegeben werden.")]
  public string? Methode { get; set; }

  /// <summary>Holt oder setzt Dauer.</summary>
  [Display(Name = "_Dauer", Description = "Anzahl der Tage, die ausgewertet werden sollen.")]
  //// [Required(ErrorMessage = "Dauer muss angegeben werden.")]
  public string? Dauer { get; set; }

  /// <summary>Holt oder setzt Relativ.</summary>
  [Display(Name = "_Relativ", Description = "Soll die Auswertung relativ zu anderem Wertpapier oder Index erfolgen?")]
  //// [Required(ErrorMessage = "Relativ muss angegeben werden.")]
  public string? Relativ { get; set; }

  /// <summary>Holt oder setzt Status.</summary>
  [Display(Name = "_Status", Description = "Status")]
  //// [Required(ErrorMessage = "Status muss angegeben werden.")]
  public string? Status { get; set; }

  /// <summary>Holt oder setzt Notiz.</summary>
  [Display(Name = "Notiz", Description = "")]
  //// [Required(ErrorMessage = "Notiz muss angegeben werden.")]
  public string? Notiz { get; set; }

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
  public WP300TodoModel To(ServiceDaten daten)
  {
    return new WP300TodoModel
    {
      // TODO Mandant_Nr = daten.MandantNr,
      Nummer = Nummer,
      Bezeichnung = Bezeichnung,
      Box = Box,
      Umkehr = Umkehr,
      Methode = Methode,
      Dauer = Dauer,
      Relativ = Relativ,
      Status = Status,
      Notiz = Notiz,
      Angelegt_Am = AngelegtAm,
      Angelegt_Von = AngelegtVon,
      Geaendert_Am = GeaendertAm,
      Geaendert_Von = GeaendertVon,
    };
  }

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public static WP300TableRowModel From(WP300TodoModel m)
  {
    return new WP300TableRowModel
    {
      Nummer = m.Nummer,
      Bezeichnung = m.Bezeichnung,
      Box = m.Box,
      Umkehr = m.Umkehr,
      Methode = m.Methode,
      Dauer = m.Dauer,
      Relativ = m.Relativ,
      Status = m.Status,
      Notiz = m.Notiz,
      AngelegtAm = m.Angelegt_Am,
      AngelegtVon = m.Angelegt_Von,
      GeaendertAm = m.Geaendert_Am,
      GeaendertVon = m.Geaendert_Von,
    };
  }
}
