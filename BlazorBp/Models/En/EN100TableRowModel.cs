// <copyright file="ENN100TableRowModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.En;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für eine Zeile in der Tabelle von Formular EN100 Abfrage-Parameter.
/// </summary>
[Serializable]
public class EN100TableRowModel : TableRowModelBase
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
  public WpWertpapier To(ServiceDaten daten)
  {
    return new WpWertpapier
    {
      // Mandant_Nr = daten.MandantNr,
      Uid = Nummer,
      Bezeichnung = Bezeichnung,
      Datenquelle = Provider,
      Kuerzel = Kuerzel,
      Status = Status,
      CurrentPrice = Functions.ToDecimal(AktKurs),
      StopPrice = Functions.ToDecimal(StopKurs),
      SignalPrice1 = Functions.ToDecimal(SignalKurs1),
      Pattern = Muster,
      Type = Typ,
      Currency = Waehrung,
      Sorting = Sortierung,
      Relation_Uid = Relation,
      Notiz = Notiz,
      Angelegt_Am = AngelegtAm,
      Angelegt_Von = AngelegtVon,
      Geaendert_Am = GeaendertAm,
      Geaendert_Von = GeaendertVon,
    };
  }

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public static EN100TableRowModel From(WpWertpapier m)
  {
    return new EN100TableRowModel
    {
      Nummer = m.Uid,
      Bezeichnung = m.Bezeichnung,
      Provider = m.Datenquelle,
      Kuerzel = m.Kuerzel,
      Status = CsbpBase.GetStockState(m.Status, m.Kuerzel),
      AktKurs = Functions.ToString(m.CurrentPrice),
      StopKurs = Functions.ToString(m.StopPrice),
      SignalKurs1 = Functions.ToString(m.SignalPrice1),
      Muster = m.Pattern,
      Typ = m.Type,
      Waehrung = m.Currency,
      Sortierung = m.Sorting,
      Relation = m.Relation_Uid,
      Notiz = m.Notiz,
      AngelegtAm = m.Angelegt_Am,
      AngelegtVon = m.Angelegt_Von,
      GeaendertAm = m.Geaendert_Am,
      GeaendertVon = m.Geaendert_Von,
    };
  }
}
