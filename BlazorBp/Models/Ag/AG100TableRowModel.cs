// <copyright file="AG100TableRowModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Ag;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;

/// <summary>
/// Model-Klasse für eine Zeile in der Tabelle von Formular AG100 Mandanten.
/// </summary>
[Serializable]
public class AG100TableRowModel : TableRowModelBase
{
  /// <summary>Holt oder setzt die Nummer.</summary>
  [Display(Name = "_Nr.", Description = "Die Nummer des Mandanten kann nicht geändert werden.")]
  public int Nummer { get; set; } = default!;

  /// <summary>Holt oder setzt die Beschreibung.</summary>
  [Display(Name = "Be_schreibung", Description = "Die Beschreibung des Mandanten muss angegeben werden.")]
  [Required(ErrorMessage = "Die Beschreibung muss angegeben werden.")]
  public string? Beschreibung { get; set; } = default!;

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
  public MaMandant To()
  {
    return new MaMandant
    {
      Nr = Nummer,
      Beschreibung = Beschreibung,
      Angelegt_Am = AngelegtAm,
      Angelegt_Von = AngelegtVon,
      Geaendert_Am = GeaendertAm,
      Geaendert_Von = GeaendertVon,
    };
  }

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public static AG100TableRowModel From(MaMandant m)
  {
    return new AG100TableRowModel
    {
      Nummer = m.Nr,
      Beschreibung = m.Beschreibung,
      AngelegtAm = m.Angelegt_Am,
      AngelegtVon = m.Angelegt_Von,
      GeaendertAm = m.Geaendert_Am,
      GeaendertVon = m.Geaendert_Von,
    };
  }
}
