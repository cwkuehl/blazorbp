// <copyright file="WP250TableRowModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Wp;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// TodoModel-Klasse für Formular WP250 Anlagen.
/// TODO Durch passendes Model ersetzen und löschen.
/// </summary>
[Serializable]
public class WP250TodoModel
{
  /// <summary>Holt oder setzt die Spalte Nr..</summary>
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt die Spalte Wertpapier.</summary>
  public string? Wertpapier { get; set; }

  /// <summary>Holt oder setzt die Spalte ....</summary>
  public string? Wpdetails { get; set; }

  /// <summary>Holt oder setzt die Spalte Bezeichnung.</summary>
  public string? Bezeichnung { get; set; }

  /// <summary>Holt oder setzt die Spalte Status.</summary>
  public string? Status { get; set; }

  /// <summary>Holt oder setzt die Spalte Depot-Konto.</summary>
  public string? Depot { get; set; }

  /// <summary>Holt oder setzt die Spalte Abrechnungs-Konto.</summary>
  public string? Abrechnung { get; set; }

  /// <summary>Holt oder setzt die Spalte Ertrags-Konto.</summary>
  public string? Ertrag { get; set; }

  /// <summary>Holt oder setzt die Spalte Notiz.</summary>
  public string? Notiz { get; set; }

  /// <summary>Holt oder setzt die Spalte Daten.</summary>
  public string? Data { get; set; }

  /// <summary>Holt oder setzt die Spalte Valuta.</summary>
  public string? Valuta { get; set; }

  /// <summary>Holt oder setzt die Spalte Stand.</summary>
  public string? Stand { get; set; }

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
/// Model-Klasse für eine Zeile in der Tabelle von Formular WP250 Anlagen.
/// </summary>
[Serializable]
public class WP250TableRowModel : TableRowModelBase
{
  /// <summary>Holt oder setzt Nr..</summary>
  [Display(Name = "Nr.", Description = "Anlagen-Nr.")]
  //// [Required(ErrorMessage = "Nr. muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Nr. darf maximal {1} Zeichen lang sein.")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt Wertpapier.</summary>
  [Display(Name = "_Wertpapier", Description = "Bezug zum Wertpapier")]
  //// [Required(ErrorMessage = "Wertpapier muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Wertpapier darf maximal {1} Zeichen lang sein.")]
  public string? Wertpapier { get; set; }

  /// <summary>Holt oder setzt ....</summary>
  [Display(Name = "...", Description = "Wertpapier-Details anzeigen")]
  //// [Required(ErrorMessage = "... muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "... darf maximal {1} Zeichen lang sein.")]
  public string? Wpdetails { get; set; }

  /// <summary>Holt oder setzt Bezeichnung.</summary>
  [Display(Name = "_Bezeichnung", Description = "Bezeichnung")]
  //// [Required(ErrorMessage = "Bezeichnung muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Bezeichnung darf maximal {1} Zeichen lang sein.")]
  public string? Bezeichnung { get; set; }

  /// <summary>Holt oder setzt Status.</summary>
  [Display(Name = "_Status", Description = "Status für Berechnung")]
  //// [Required(ErrorMessage = "Status muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Status darf maximal {1} Zeichen lang sein.")]
  public string? Status { get; set; }

  /// <summary>Holt oder setzt Depot-Konto.</summary>
  [Display(Name = "Depot-Konto", Description = "Depot-Konto für gleichzeitige Haushaltsbuchung")]
  //// [Required(ErrorMessage = "Depot-Konto muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Depot-Konto darf maximal {1} Zeichen lang sein.")]
  public string? Depot { get; set; }

  /// <summary>Holt oder setzt Abrechnungs-Konto.</summary>
  [Display(Name = "Abrechnungs-Konto", Description = "Abrechnungs-Konto für gleichzeitige Haushaltsbuchung")]
  //// [Required(ErrorMessage = "Abrechnungs-Konto muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Abrechnungs-Konto darf maximal {1} Zeichen lang sein.")]
  public string? Abrechnung { get; set; }

  /// <summary>Holt oder setzt Ertrags-Konto.</summary>
  [Display(Name = "Ertrags-Konto", Description = "Ertrags-Konto für gleichzeitige Haushaltsbuchung")]
  //// [Required(ErrorMessage = "Ertrags-Konto muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Ertrags-Konto darf maximal {1} Zeichen lang sein.")]
  public string? Ertrag { get; set; }

  /// <summary>Holt oder setzt Notiz.</summary>
  [Display(Name = "_Notiz", Description = "")]
  //// [Required(ErrorMessage = "Notiz muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Notiz darf maximal {1} Zeichen lang sein.")]
  public string? Notiz { get; set; }

  /// <summary>Holt oder setzt Daten.</summary>
  [Display(Name = "_Daten", Description = "Daten für die Anlage, z.B. Anzahl Anteile und Kaufpreis")]
  //// [Required(ErrorMessage = "Daten muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Daten darf maximal {1} Zeichen lang sein.")]
  public string? Data { get; set; }

  /// <summary>Holt oder setzt Valuta.</summary>
  [Display(Name = "Valuta", Description = "Valuta-Datum für das Setzen des Stands")]
  //// [Required(ErrorMessage = "Valuta muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Valuta darf maximal {1} Zeichen lang sein.")]
  public string? Valuta { get; set; }

  /// <summary>Holt oder setzt Stand.</summary>
  [Display(Name = "_Stand", Description = "Wert aller Anteile der Anlage am Datum")]
  //// [Required(ErrorMessage = "Stand muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Stand darf maximal {1} Zeichen lang sein.")]
  public string? Stand { get; set; }

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
  public WP250TodoModel To(ServiceDaten daten)
  {
    return new WP250TodoModel
    {
      // TODO Mandant_Nr = daten.MandantNr,
      Nummer = Nummer,
      Wertpapier = Wertpapier,
      Wpdetails = Wpdetails,
      Bezeichnung = Bezeichnung,
      Status = Status,
      Depot = Depot,
      Abrechnung = Abrechnung,
      Ertrag = Ertrag,
      Notiz = Notiz,
      Data = Data,
      Stand = Stand,
      Angelegt_Am = AngelegtAm,
      Angelegt_Von = AngelegtVon,
      Geaendert_Am = GeaendertAm,
      Geaendert_Von = GeaendertVon,
    };
  }

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public static WP250TableRowModel From(WP250TodoModel m)
  {
    return new WP250TableRowModel
    {
      Nummer = m.Nummer,
      Wertpapier = m.Wertpapier,
      Wpdetails = m.Wpdetails,
      Bezeichnung = m.Bezeichnung,
      Status = m.Status,
      Depot = m.Depot,
      Abrechnung = m.Abrechnung,
      Ertrag = m.Ertrag,
      Notiz = m.Notiz,
      Data = m.Data,
      Stand = m.Stand,
      AngelegtAm = m.Angelegt_Am,
      AngelegtVon = m.Angelegt_Von,
      GeaendertAm = m.Geaendert_Am,
      GeaendertVon = m.Geaendert_Von,
    };
  }
}
