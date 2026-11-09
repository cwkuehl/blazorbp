// <copyright file="TB200TableRowModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Forms.Models.Tb;

using System.ComponentModel.DataAnnotations;
using BlazorSpa.Base;
using BlazorSpa.Core.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorSpa.Core.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für eine Zeile in der Tabelle von Formular TB200 Positionen.
/// </summary>
[Serializable]
public class TB200TableRowModel : TableRowModelBase
{
  /// <summary>Holt oder setzt Nr.</summary>
  [Display(Name = "Nr.", Description = "Positions-Nr.")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt Bezeichnung.</summary>
  [Display(Name = "_Bezeichnung", Description = "Bezeichnung")]
  public string? Bezeichnung { get; set; }

  /// <summary>Holt oder setzt Breite.</summary>
  [Display(Name = "_Breite", Description = "Breite")]
  public string? Breite { get; set; }

  /// <summary>Holt oder setzt Länge.</summary>
  [Display(Name = "_Länge", Description = "Länge")]
  public string? Laenge { get; set; }

  /// <summary>Holt oder setzt Höhe.</summary>
  [Display(Name = "_Höhe", Description = "Höhe")]
  public string? Hoehe { get; set; }

  /// <summary>Holt oder setzt Zeitzone.</summary>
  [Display(Name = "_Zeitzone", Description = "Zeitzone")]
  public string? Zeitzone { get; set; }

  /// <summary>Holt oder setzt Notiz.</summary>
  [Display(Name = "_Notiz", Description = "Notizen")]
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
  /// <returns>Das kopierte Model.</returns>
  public static TB200TableRowModel From(TbOrt m)
  {
    return new TB200TableRowModel
    {
      Nummer = m.Uid,
      Bezeichnung = Functions.Left2(m.Bezeichnung),
      Breite = Funktionen.ToString(m.Breite, 5),
      Laenge = Funktionen.ToString(m.Laenge, 5),
      Hoehe = Funktionen.ToString(m.Hoehe, 2),
      Zeitzone = m.Zeitzone,
      Notiz = Functions.Left2(m.Notiz),
      AngelegtAm = m.Angelegt_Am,
      AngelegtVon = m.Angelegt_Von,
      GeaendertAm = m.Geaendert_Am,
      GeaendertVon = m.Geaendert_Von,
    };
  }
}
