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
/// Model-Klasse für eine Zeile in der Tabelle von Formular WP250 Anlagen.
/// </summary>
[Serializable]
public class WP250TableRowModel : TableRowModelBase
{
  /// <summary>Holt oder setzt Nr..</summary>
  [Display(Name = "Nr.", Description = "Anlagen-Nr.")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt Bezeichnung.</summary>
  [Display(Name = "_Bezeichnung", Description = "Bezeichnung")]
  public string? Bezeichnung { get; set; }

  /// <summary>Holt oder setzt Status.</summary>
  [Display(Name = "_Status", Description = "Status für Berechnung")]
  public string? Status { get; set; }

  /// <summary>Holt oder setzt Provider.</summary>
  [Display(Name = "_Provider", Description = "Provider für Kursabfrage")]
  public string? Provider { get; set; }

  /// <summary>Holt oder setzt Kürzel.</summary>
  [Display(Name = "_Kürzel", Description = "Kürzel für Kursabfrage beim Provider")]
  public string? Kuerzel { get; set; }

  /// <summary>Holt oder setzt die Zahlungssumme.</summary>
  [Display(Name = "_Zahlung", Description = "Gesamtzahlung für die Anlage, z.B. Kaufpreis oder Summe der Einzahlungen")]
  public string? Zahlung { get; set; }

  /// <summary>Holt oder setzt die Anteile.</summary>
  [Display(Name = "_Anteile", Description = "Summe aller Anteile der Anlage, z.B. Stückzahl oder Nominalwert")]
  public string? Anteile { get; set; }

  /// <summary>Holt oder setzt den Wert.</summary>
  [Display(Name = "_Wert", Description = "Wert aller Anteile der Anlage an Valuta")]
  public string? Wert { get; set; }

  /// <summary>Holt oder setzt den Gewinn.</summary>
  [Display(Name = "_Gewinn", Description = "Gewinn der Anlage an Valuta, z.B. Wert minus Zahlung")]
  public string? Gewinn { get; set; }

  /// <summary>Holt oder setzt die Wert-Differenz.</summary>
  [Display(Name = "+/-", Description = "Wert-Differenz zum vorigen Stand")]
  public string? WertDiff { get; set; }

  /// <summary>Holt oder setzt Valuta.</summary>
  [Display(Name = "Valuta", Description = "Valuta-Datum für das Setzen des Stands")]
  public string? Valuta { get; set; }

  /// <summary>Holt oder setzt die Währung.</summary>
  [Display(Name = "_Währung", Description = "Währung für den Wert")]
  public string? Waehrung { get; set; }

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
  public WpAnlage To(ServiceDaten daten)
  {
    return new WpAnlage
    {
      Mandant_Nr = daten.MandantNr,
      Uid = Nummer,
      // Bezeichnung = Bezeichnung,
      // State = Status,
      // StockProvider = Provider,
      // StockShortcut = Kuerzel,
      // Payment = Functions.ToDecimal(Zahlung) ?? 0,
      // Shares = Functions.ToDecimal(Anteile) ?? 0,
      // Value = Functions.ToDecimal(Wert) ?? 0,
      // Profit = Functions.ToDecimal(Gewinn) ?? 0,
      // PriceDate = Functions.ToDateTime(Valuta),
      // Currency = Waehrung,
      // Angelegt_Am = AngelegtAm,
      // Angelegt_Von = AngelegtVon,
      // Geaendert_Am = GeaendertAm,
      // Geaendert_Von = GeaendertVon,
    };
  }

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public static WP250TableRowModel From(WpAnlage m)
  {
    return new WP250TableRowModel
    {
      Nummer = m.Uid,
      Bezeichnung = m.Bezeichnung,
      Status = CsbpBase.GetStockState(m.State.ToString(), m.StockShortcut),
      Provider = m.StockProvider,
      Kuerzel = m.StockShortcut,
      Zahlung = Functions.ToString(m.Payment, 2),
      Anteile = Functions.ToString(m.Shares, 5),
      Wert = Functions.ToString(m.Value, 2),
      Gewinn = Functions.ToString(m.Profit, 2),
      WertDiff = Functions.ToString(m.ValueDiff, 2),
      Valuta = Functions.ToString(m.PriceDate),
      Waehrung = m.Currency,
      AngelegtAm = m.Angelegt_Am,
      AngelegtVon = m.Angelegt_Von,
      GeaendertAm = m.Geaendert_Am,
      GeaendertVon = m.Geaendert_Von,
    };
  }
}
