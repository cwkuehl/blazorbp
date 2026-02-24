// <copyright file="TB200TableRowModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Tb;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für eine Zeile in der Tabelle von Formular TB200 Positionen.
/// </summary>
[Serializable]
public class TB200TableRowModel : TableRowModelBase
{
  /// <summary>Holt oder setzt Nr..</summary>
  [Display(Name = "Nr.", Description = "")]
  //// [Required(ErrorMessage = "Nr. muss angegeben werden.")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt Bezeichnung.</summary>
  [Display(Name = "_Bezeichnung", Description = "")]
  //// [Required(ErrorMessage = "Bezeichnung muss angegeben werden.")]
  public string? Bezeichnung { get; set; }

  /// <summary>Holt oder setzt Breite.</summary>
  [Display(Name = "_Breite", Description = "")]
  //// [Required(ErrorMessage = "Breite muss angegeben werden.")]
  public string? Breite { get; set; }

  /// <summary>Holt oder setzt Notiz.</summary>
  [Display(Name = "_Notiz", Description = "")]
  //// [Required(ErrorMessage = "Notiz muss angegeben werden.")]
  public string? Notiz { get; set; }

  /// <summary>Holt oder setzt Länge.</summary>
  [Display(Name = "_Länge", Description = "")]
  //// [Required(ErrorMessage = "Länge muss angegeben werden.")]
  public string? Laenge { get; set; }

  /// <summary>Holt oder setzt Höhe.</summary>
  [Display(Name = "_Höhe", Description = "")]
  //// [Required(ErrorMessage = "Höhe muss angegeben werden.")]
  public string? Hoehe { get; set; }

  /// <summary>Holt oder setzt Zeitzone.</summary>
  [Display(Name = "_Zeitzone", Description = "Zeitzone")]
  //// [Required(ErrorMessage = "Zeitzone muss angegeben werden.")]
  public string? Zeitzone { get; set; }

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
  public TbOrt To(ServiceDaten daten)
  {
    return new TbOrt
    {
      // TODO Mandant_Nr = daten.MandantNr,
      Uid = Nummer,
      Bezeichnung = Bezeichnung,
      Breite = Functions.ToDecimal(Breite) ?? 0m,
      Notiz = Notiz,
      Laenge = Functions.ToDecimal(Laenge) ?? 0m,
      Hoehe = Functions.ToDecimal(Hoehe) ?? 0m,
      Zeitzone = Zeitzone,
      Angelegt_Am = AngelegtAm,
      Angelegt_Von = AngelegtVon,
      Geaendert_Am = GeaendertAm,
      Geaendert_Von = GeaendertVon,
    };
  }

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public static TB200TableRowModel From(TbOrt m)
  {
    return new TB200TableRowModel
    {
      Nummer = m.Uid,
      Bezeichnung = m.Bezeichnung,
      Breite = Functions.ToString(m.Breite),
      Notiz = m.Notiz,
      Laenge = Functions.ToString(m.Laenge),
      Hoehe = Functions.ToString(m.Hoehe),
      Zeitzone = m.Zeitzone,
      AngelegtAm = m.Angelegt_Am,
      AngelegtVon = m.Angelegt_Von, 
      GeaendertAm = m.Geaendert_Am,
      GeaendertVon = m.Geaendert_Von,
    };
  }
}
