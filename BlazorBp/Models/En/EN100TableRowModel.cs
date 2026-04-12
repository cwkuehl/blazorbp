// <copyright file="ENN100TableRowModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.En;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für eine Zeile in der Tabelle von Formular EN100 Abfrage-Parameter.
/// </summary>
[Serializable]
public class EN100TableRowModel : TableRowModelBase
{
  /// <summary>Holt oder setzt Nr..</summary>
  [Display(Name = "Nr.", Description = "Wertpapier-Nr.")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt Sortierung.</summary>
  [Display(Name = "Sortierun_g", Description = "Zeichenkette für Sortierung")]
  public string? Sortierung { get; set; }

  /// <summary>Holt oder setzt Bezeichnung.</summary>
  [Display(Name = "_Bezeichnung", Description = "Bezeichnung")]
  public string? Bezeichnung { get; set; }

  /// <summary>Holt oder setzt Status.</summary>
  [Display(Name = "_Status", Description = "Status für Berechnung")]
  public string? Status { get; set; }

  /// <summary>Holt oder setzt Host-URL.</summary>
  [Display(Name = "Host-URL", Description = "Host und Port oder URL")]
  public string? HostUrl { get; set; }

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
  public EnAbfrage To(ServiceDaten daten)
  {
    return new EnAbfrage
    {
      Mandant_Nr = daten.MandantNr,
      Uid = Nummer,
      Sortierung = Sortierung,
      Bezeichnung = Bezeichnung,
      Status = Status,
      Host_Url = HostUrl,
      Angelegt_Am = AngelegtAm,
      Angelegt_Von = AngelegtVon,
      Geaendert_Am = GeaendertAm,
      Geaendert_Von = GeaendertVon,
    };
  }

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public static EN100TableRowModel From(EnAbfrage m)
  {
    return new EN100TableRowModel
    {
      Nummer = m.Uid,
      Sortierung = m.Sortierung,
      Bezeichnung = m.Bezeichnung,
      Status = CsbpBase.GetStockState(m.Status, "1"),
      HostUrl = m.Host_Url,
      AngelegtAm = m.Angelegt_Am,
      AngelegtVon = m.Angelegt_Von,
      GeaendertAm = m.Geaendert_Am,
      GeaendertVon = m.Geaendert_Von,
    };
  }
}
