// <copyright file="AM500TableRowModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Am;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;

/// <summary>
/// Model-Klasse für eine Zeile in der Tabelle von Formular AM500 Einstellungen.
/// </summary>
[Serializable]
public class AM500TableRowModel : TableRowModelBase
{
  /// <summary>Holt oder setzt den Schlüssel.</summary>
  [Display(Name = "_Schlüssel", Description = "Der Schlüssel kann nicht geändert werden.")]
  [Required(ErrorMessage = "Der Schlüssel muss angegeben werden.")]
  public string Schluessel { get; set; } = default!;

  /// <summary>Holt oder setzt den Wert.</summary>
  [Display(Name = "_Wert", Description = "Der Wert kann angegeben werden.")]
  public string? Wert { get; set; } = default!;

  /// <summary>Holt oder setzt den Beschreibung.</summary>
  [Display(Name = "_Beschreibung", Description = "Die Beschreibung zur Einstellung.")]
  public string? Beschreibung { get; set; } = default!;

  /// <summary>Holt oder setzt den Standardwert.</summary>
  [Display(Name = "_Standard", Description = "Der Standardwert der Einstellung.")]
  public string? Standard { get; set; } = default!;

  /// <summary>Holt oder setzt den Zeitpunkt der Anlage.</summary>
  [Display(Name = "Angelegt am", Description = "Der Zeitpunkt der Anlage.")]
  public DateTime? AngelegtAm { get; set; }

  /// <summary>Holt oder setzt die Benutzer-ID der Anlage.</summary>
  [Display(Name = "Angelegt von", Description = "Die Benutzer-ID der Anlage.")]
  public string? AngelegtVon { get; set; } = default!;

  /// <summary>Holt oder setzt den Zeitpunkt der letzten Änderung.</summary>
  [Display(Name = "Geändert am", Description = "Der Zeitpunkt der letzten Änderung.")]
  public DateTime? GeaendertAm { get; set; }

  /// <summary>Holt oder setzt die Benutzer-ID der letzten Änderung.</summary>
  [Display(Name = "Geändert von", Description = "Die Benutzer-ID der letzten Änderung.")]
  public string? GeaendertVon { get; set; }

  /// <summary>Kopiert die Werte in ein Model.</summary>
  /// <param name="mnr">Betroffene Mandantennummer.</param>
  public MaParameter To(int mnr)
  {
    return new MaParameter
    {
      Mandant_Nr = mnr,
      Schluessel = Schluessel ?? "",
      Wert = Wert ?? "",
      Comment = Beschreibung ?? "",
      Default = Standard ?? "",
      Angelegt_Am = AngelegtAm,
      Angelegt_Von = AngelegtVon,
      Geaendert_Am = GeaendertAm,
      Geaendert_Von = GeaendertVon,
    };
  }

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public static AM500TableRowModel From(MaParameter m)
  {
    return new AM500TableRowModel
    {
      Schluessel = m.Schluessel,
      Wert = m.Wert,
      Beschreibung = m.Comment,
      Standard = m.Default,
      AngelegtAm = m.Angelegt_Am,
      AngelegtVon = m.Angelegt_Von,
      GeaendertAm = m.Geaendert_Am,
      GeaendertVon = m.Geaendert_Von,
    };
  }
}
