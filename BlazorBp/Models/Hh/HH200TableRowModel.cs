// <copyright file="HH200TableRowModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Hh;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;

/// <summary>
/// Model-Klasse für eine Zeile in der Tabelle von Formular HH200 Konten.
/// </summary>
[Serializable]
public class HH200TableRowModel : TableRowModelBase
{
  /// <summary>Holt oder setzt Nr.</summary>
  [Display(Name = "Nr.", Description = "Konto-Nr.")]
  public string? Nummer { get { return Id; } set { Id = value; } }

  /// <summary>Holt oder setzt Bezeichnung.</summary>
  [Display(Name = "_Bezeichnung", Description = "Bezeichnung")]
  public string? Bezeichnung { get; set; }

  /// <summary>Holt oder setzt Kennzeichen.</summary>
  [Display(Name = "_Kennzeichen", Description = "Kennzeichen des Kontos")]
  public string? Kennzeichen { get; set; }

  /// <summary>Holt oder setzt Kontoart.</summary>
  [Display(Name = "Kontoa_rt", Description = "Art des Kontos")]
  public string? Kontoart { get; set; }

  /// <summary>Holt oder setzt Gültigkeit von.</summary>
  [Display(Name = "Gültigkeit _von", Description = "")]
  public DateTime? Von { get; set; }

  /// <summary>Holt oder setzt Bis.</summary>
  [Display(Name = "B_is", Description = "")]
  public DateTime? Bis { get; set; }

  /// <summary>Holt oder setzt Betrag.</summary>
  [Display(Name = "B_etrag", Description = "Betrag am 1. Gültigkeitstag für Aktiv- und Passivkonten, negativ für Aktivkonten.")]
  public decimal? Betrag { get; set; }

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
  public static HH200TableRowModel From(HhKonto m)
  {
    return new HH200TableRowModel
    {
      Nummer = m.Uid,
      Bezeichnung = m.Name,
      Kennzeichen = m.Kz,
      Kontoart = m.Art,
      Von = m.Gueltig_Von,
      Bis = m.Gueltig_Bis,
      Betrag = m.EBetrag,
      AngelegtAm = m.Angelegt_Am,
      AngelegtVon = m.Angelegt_Von,
      GeaendertAm = m.Geaendert_Am,
      GeaendertVon = m.Geaendert_Von,
    };
  }
}
