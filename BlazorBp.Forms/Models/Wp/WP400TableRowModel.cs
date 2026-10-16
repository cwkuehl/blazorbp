// <copyright file="WP400TableRowModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Forms.Models.Wp;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Core.Base;
using BlazorSpa.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;

/// <summary>
/// Model-Klasse für eine Zeile in der Tabelle von Formular WP400 WP-Buchungen.
/// </summary>
[Serializable]
public class WP400TableRowModel : TableRowModelBase
{
  /// <summary>Holt oder setzt Nr.</summary>
  [Display(Name = "Nr.", Description = "Nummer")]
  public string? Nummer { get { return Id; } set { Id = value; } }

  /// <summary>Holt oder setzt Anlage.</summary>
  [Display(Name = "_Wertpapier", Description = "Bezeichnung des Wertpapiers")]
  public string? Wertpapier { get; set; }

  /// <summary>Holt oder setzt Anlage.</summary>
  [Display(Name = "_Anlage", Description = "Bezeichnung der Anlage")]
  public string? Anlage { get; set; }

  /// <summary>Holt oder setzt Datum.</summary>
  [Display(Name = "_Datum", Description = "Datum der Buchung")]
  public string? Valuta { get; set; }

  /// <summary>Holt oder setzt Buchungstext.</summary>
  [Display(Name = "Buchungste_xt", Description = "Buchungstext")]
  public string? BText { get; set; }

  /// <summary>Holt oder setzt Betrag.</summary>
  [Display(Name = "_Betrag", Description = "Betrag der Buchung")]
  public string? Betrag { get; set; }

  /// <summary>Holt oder setzt Rabatt.</summary>
  [Display(Name = "_Rabatt", Description = "Rabatt der Buchung positiv oder Gebühren negativ")]
  public string? Rabatt { get; set; }

  /// <summary>Holt oder setzt Anteile.</summary>
  [Display(Name = "_Anteile", Description = "")]
  public string? Anteile { get; set; }

  /// <summary>Holt oder setzt Zinsen.</summary>
  [Display(Name = "_Zinsen", Description = "")]
  public string? Zinsen { get; set; }

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
  public static WP400TableRowModel From(WpBuchung m)
  {
    // No.;Stock;Description;Date;Posting text;Payment_r;Discount_r;Shares_r;Interest_r;Changed at;Changed by;Created at;Created by
    return new WP400TableRowModel
    {
      Nummer = m.Uid,
      Wertpapier = Functions.Left2(m.StockDescription),
      Anlage = Functions.Left2(m.InvestmentDescription),
      Valuta = Funktionen.ToString(m.Datum),
      BText = Functions.Left2(m.BText),
      Betrag = Funktionen.ToString(m.Zahlungsbetrag, 2),
      Rabatt = Funktionen.ToString(m.Rabattbetrag, 2),
      Anteile = Funktionen.ToString(m.Anteile, 5),
      Zinsen = Funktionen.ToString(m.Zinsen, 2),
      AngelegtAm = m.Angelegt_Am,
      AngelegtVon = m.Angelegt_Von,
      GeaendertAm = m.Geaendert_Am,
      GeaendertVon = m.Geaendert_Von,
    };
  }
}
