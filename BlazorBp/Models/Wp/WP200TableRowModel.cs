// <copyright file="WP200TableRowModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Wp;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für eine Zeile in der Tabelle von Formular WP200 Wertpapiere.
/// </summary>
[Serializable]
public class WP200TableRowModel : TableRowModelBase
{
  /// <summary>Holt oder setzt Nr.</summary>
  [Display(Name = "Nr.", Description = "Wertpapier-Nr.")]
  public string? Nummer { get { return Id; } set { Id = value; } }

  /// <summary>Holt oder setzt Bezeichnung.</summary>
  [Display(Name = "_Bezeichnung", Description = "Bezeichnung")]
  public string? Bezeichnung { get; set; }

  /// <summary>Holt oder setzt Provider.</summary>
  [Display(Name = "_Provider", Description = "Provider für Kursabfrage")]
  public string? Provider { get; set; }

  /// <summary>Holt oder setzt Kürzel.</summary>
  [Display(Name = "_Kürzel", Description = "Kürzel für Kursabfrage beim Provider")]
  public string? Kuerzel { get; set; }

  /// <summary>Holt oder setzt Status.</summary>
  [Display(Name = "_Status", Description = "Status für Berechnung")]
  public string? Status { get; set; }

  /// <summary>Holt oder setzt Aktueller Kurs.</summary>
  [Display(Name = "Aktueller Kurs", Description = "Aktueller Kurs aus letzter Bewertung")]
  public string? AktKurs { get; set; }

  /// <summary>Holt oder setzt Stop-Kurs.</summary>
  [Display(Name = "Stop-Kurs", Description = "Stop-Kurs aus letzter Bewertung")]
  public string? StopKurs { get; set; }

  /// <summary>Holt oder setzt Kursziel.</summary>
  [Display(Name = "Kurs_ziel", Description = "Manuelles Kursziel")]
  public string? SignalKurs1 { get; set; }

  /// <summary>Holt oder setzt Letztes Muster.</summary>
  [Display(Name = "Letztes Muster", Description = "Letztes Signalmuster aus letzter Bewertung")]
  public string? Muster { get; set; }

  /// <summary>Holt oder setzt Typ.</summary>
  [Display(Name = "_Typ", Description = "Aktie (wenn leer) oder Anleihe")]
  public string? Typ { get; set; }

  /// <summary>Holt oder setzt Währung.</summary>
  [Display(Name = "_Währung", Description = "Währungskürzel für Kursabfrage; EUR, GBP, USD, ...")]
  public string? Waehrung { get; set; }

  /// <summary>Holt oder setzt Sortierung.</summary>
  [Display(Name = "Sortierun_g", Description = "Zeichenkette für Sortierung")]
  public string? Sortierung { get; set; }

  /// <summary>Holt oder setzt Relation.</summary>
  [Display(Name = "_Relation", Description = "Relation zu anderem Wertpapier, z.B. Index")]
  public string? Relation { get; set; }

  /// <summary>Holt oder setzt Notiz.</summary>
  [Display(Name = "Notiz", Description = "")]
  public string? Notiz { get; set; }

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

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public static WP200TableRowModel From(WpWertpapier m)
  {
    return new WP200TableRowModel
    {
      Nummer = m.Uid,
      Bezeichnung = Functions.Left2(m.Bezeichnung),
      Provider = m.Datenquelle,
      Kuerzel = m.Kuerzel,
      Status = CsbpBase.GetStockState(m.Status, m.Kuerzel),
      AktKurs = Functions.ToString(m.CurrentPrice),
      StopKurs = Functions.ToString(m.StopPrice),
      SignalKurs1 = Functions.ToString(m.SignalPrice1),
      Muster = Functions.Left2(m.Pattern),
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
