// <copyright file="HH400TableRowModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Hh;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für eine Zeile in der Tabelle von Formular HH400 Buchungen.
/// </summary>
[Serializable]
public class HH400TableRowModel : TableRowModelBase
{

  /// <summary>Holt oder setzt Nr.</summary>
  [Display(Name = "Nr.", Description = "Nummer")]
  public string? Nummer { get { return Id; } set { Id = value; } }

  /// <summary>Holt oder setzt Kennzeichen.</summary>
  [Display(Name = "K.", Description = "Kennzeichen")]
  public string? Kennzeichen { get; set; }

  /// <summary>Holt oder setzt Valuta.</summary>
  [Display(Name = "_Valuta", Description = "")]
  public string? Valuta { get; set; }

  /// <summary>Holt oder setzt Betrag.</summary>
  [Display(Name = "_Betrag", Description = "Betrag")]
  [Required(ErrorMessage = "Betrag muss angegeben werden.")]
  public decimal? Betrag { get; set; }

  /// <summary>Holt oder setzt Buchungstext.</summary>
  [Display(Name = "Buchungste_xt", Description = "Buchungstext")]
  public string? BText { get; set; }

  /// <summary>Holt oder setzt Sollkonto.</summary>
  [Display(Name = "_Sollkonto", Description = "Sollkonto")]
  public string? Sollkonto { get; set; }

  /// <summary>Holt oder setzt Habenkonto.</summary>
  [Display(Name = "Habe_nkonto", Description = "Habenkonto")]
  public string? Habenkonto { get; set; }

  /// <summary>Holt oder setzt Beleg.</summary>
  [Display(Name = "Bele_g", Description = "Belegnummer")]
  public string? BelegNr { get; set; }

  /// <summary>Holt oder setzt Vom.</summary>
  [Display(Name = "Vom", Description = "")]
  public string? BelegDatum { get; set; }

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
  public static HH400TableRowModel From(HhBuchung m)
  {
    return new HH400TableRowModel
    {
      Nummer = m.Uid,
      Valuta = Functions.ToString(m.Soll_Valuta),
      Betrag = m.EBetrag,
      Kennzeichen = m.Kz,
      BText = Functions.Left2(m.BText),
      Sollkonto = m.DebitName,
      Habenkonto = m.CreditName,
      BelegNr = m.Beleg_Nr,
      BelegDatum = Functions.ToString(m.Beleg_Datum),
      AngelegtAm = m.Angelegt_Am,
      AngelegtVon = m.Angelegt_Von,
      GeaendertAm = m.Geaendert_Am,
      GeaendertVon = m.Geaendert_Von,
    };
  }
}
