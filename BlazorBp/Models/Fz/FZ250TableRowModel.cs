// <copyright file="FZ250TableRowModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Fz;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models.Views;
using CSBP.Services.Base;

/// <summary>
/// Model-Klasse für eine Zeile in der Tabelle von Formular FZ250 Fahrradstände.
/// </summary>
[Serializable]
public class FZ250TableRowModel : TableRowModelBase
{
  /// <summary>Holt oder setzt Nr..</summary>
  [Display(Name = "Nr.", Description = "Fahrradstand-Nr.")]
  //// [Required(ErrorMessage = "Nr. muss angegeben werden.")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt Fahrrad.</summary>
  [Display(Name = "_Fahrrad", Description = "Fahrrad")]
  //// [Required(ErrorMessage = "Fahrrad muss angegeben werden.")]
  public string? Fahrrad { get; set; }

  /// <summary>Holt oder setzt Datum.</summary>
  [Display(Name = "_Datum", Description = "Datum")]
  //// [Required(ErrorMessage = "Datum muss angegeben werden.")]
  public DateTime? Datum { get; set; }

  /// <summary>Holt oder setzt die Fahrradstand-Nr.</summary>
  [Display(Name = "_Nr.", Description = "Nr. bei mehreren Touren pro Tag.")]
  //// [Required(ErrorMessage = "Datum muss angegeben werden.")]
  public int UnterNr { get; set; }

  /// <summary>Holt oder setzt Zähler.</summary>
  [Display(Name = "_Zähler", Description = "Zählerstand")]
  //// [Required(ErrorMessage = "Zähler muss angegeben werden.")]
  public decimal? Zaehler { get; set; }

  /// <summary>Holt oder setzt Km.</summary>
  [Display(Name = "_Km", Description = "Tages- oder Wochen-km")]
  //// [Required(ErrorMessage = "Km muss angegeben werden.")]
  public decimal? Km { get; set; }

  /// <summary>Holt oder setzt Schnitt.</summary>
  [Display(Name = "_Schnitt", Description = "Durchschnittsgeschwindigkeit")]
  //// [Required(ErrorMessage = "Schnitt muss angegeben werden.")]
  public decimal? Schnitt { get; set; }

  /// <summary>Holt oder setzt Beschreibung.</summary>
  [Display(Name = "_Beschreibung", Description = "Beschreibung")]
  //// [Required(ErrorMessage = "Beschreibung muss angegeben werden.")]
  public string? Beschreibung { get; set; }

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
  public VFzFahrradstand To(ServiceDaten daten)
  {
    return new VFzFahrradstand
    {
      Mandant_Nr = daten.MandantNr,
      Fahrrad_Uid = Nummer,
      Bezeichnung = Fahrrad,
      Datum = Datum ?? daten.Heute,
      Nr = UnterNr,
      Zaehler_km = Zaehler ?? 0,
      Periode_km = Km ?? 0,
      Periode_Schnitt = Functions.Round(Schnitt) ?? 0,
      Beschreibung = Beschreibung,
      Angelegt_Am = AngelegtAm,
      Angelegt_Von = AngelegtVon,
      Geaendert_Am = GeaendertAm,
      Geaendert_Von = GeaendertVon,
    };
  }

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public static FZ250TableRowModel From(VFzFahrradstand m)
  {
    return new FZ250TableRowModel
    {
      Nummer = m.Fahrrad_Uid,
      Fahrrad = m.Bezeichnung,
      Datum = m.Datum,
      UnterNr = m.Nr,
      Zaehler = m.Zaehler_km,
      Km = m.Periode_km,
      Schnitt = Functions.Round(m.Periode_Schnitt),
      Beschreibung = m.Beschreibung,
      AngelegtAm = m.Angelegt_Am,
      AngelegtVon = m.Angelegt_Von,
      GeaendertAm = m.Geaendert_Am,
      GeaendertVon = m.Geaendert_Von,
    };
  }
}
