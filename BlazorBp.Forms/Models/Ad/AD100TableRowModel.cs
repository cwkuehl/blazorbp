// <copyright file="AD100TableRowModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Forms.Models.Ad;

using System.ComponentModel.DataAnnotations;
using BlazorSpa.Core.Base;
using CSBP.Services.Apis.Models;

/// <summary>
/// Model-Klasse für eine Zeile in der Tabelle von Formular AD100 Personen.
/// </summary>
[Serializable]
public class AD100TableRowModel : TableRowModelBase
{
  /// <summary>Holt oder setzt Nr.</summary>
  [Display(Name = "Nrn. (PSA)", Description = "Person-Nr.")]
  public string? Nummer
  {
    get { return Id; }
    set { Id = value; }
  }

  /// <summary>Holt oder setzt Beschreibung.</summary>
  [Display(Name = "_Name", Description = "Name, Vorname")]
  public string? Name { get; set; }

  /// <summary>Holt oder setzt Sitz.</summary>
  [Display(Name = "_Sitz", Description = "Sitz mit Ort")]
  public string? Sitz { get; set; }

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
  /// <returns>Neues Model.</returns>
  public static AD100TableRowModel From(AdSitz m)
  {
    return new AD100TableRowModel
    {
      Nummer = m.Uid,
      Name = m.PersonName,
      Sitz = m.SiteName,
      AngelegtAm = m.Angelegt_Am,
      AngelegtVon = m.Angelegt_Von,
      GeaendertAm = m.Geaendert_Am,
      GeaendertVon = m.Geaendert_Von,
    };
  }
}
