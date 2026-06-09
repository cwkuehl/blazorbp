// <copyright file="WP250TableRowModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Wp;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für eine Zeile in der Tabelle von Formular WP250 Anlagen.
/// </summary>
[Serializable]
public class WP250TableRowModel : TableRowModelBase
{
  /// <summary>Holt oder setzt Nr..</summary>
  [Display(Name = "Nr.", Description = "Anlagen-Nr.")]
  //// [Required(ErrorMessage = "Nr. muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Nr. darf maximal {1} Zeichen lang sein.")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt Bezeichnung.</summary>
  [Display(Name = "_Bezeichnung", Description = "Bezeichnung")]
  //// [Required(ErrorMessage = "Bezeichnung muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Bezeichnung darf maximal {1} Zeichen lang sein.")]
  public string? Bezeichnung { get; set; }

  /// <summary>Holt oder setzt Status.</summary>
  [Display(Name = "_Status", Description = "Status für Berechnung")]
  //// [Required(ErrorMessage = "Status muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Status darf maximal {1} Zeichen lang sein.")]
  public string? Status { get; set; }

  /// <summary>Holt oder setzt Provider.</summary>
  [Display(Name = "_Provider", Description = "Provider für Kursabfrage")]
  //// [Required(ErrorMessage = "Provider muss angegeben werden.")]
  public string? Provider { get; set; }

  /// <summary>Holt oder setzt Kürzel.</summary>
  [Display(Name = "_Kürzel", Description = "Kürzel für Kursabfrage beim Provider")]
  //// [Required(ErrorMessage = "Kürzel muss angegeben werden.")]
  public string? Kuerzel { get; set; }

  /// <summary>Holt oder setzt Valuta.</summary>
  [Display(Name = "Valuta", Description = "Valuta-Datum für das Setzen des Stands")]
  //// [Required(ErrorMessage = "Valuta muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Valuta darf maximal {1} Zeichen lang sein.")]
  public string? Valuta { get; set; }

  /// <summary>Holt oder setzt Stand.</summary>
  [Display(Name = "_Stand", Description = "Wert aller Anteile der Anlage am Datum")]
  //// [Required(ErrorMessage = "Stand muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Stand darf maximal {1} Zeichen lang sein.")]
  public string? Stand { get; set; }

  /// <summary>Holt oder setzt Angelegt am.</summary>
  [Display(Name = "Angelegt am", Description = "Der Zeitpunkt der Anlage")]
  //// [Required(ErrorMessage = "Angelegt am muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Angelegt am darf maximal {1} Zeichen lang sein.")]
  public DateTime? AngelegtAm { get; set; }

  /// <summary>Holt oder setzt Angelegt von.</summary>
  [Display(Name = "Angelegt von", Description = "Die Benutzer-ID der Anlage")]
  //// [Required(ErrorMessage = "Angelegt von muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Angelegt von darf maximal {1} Zeichen lang sein.")]
  public string? AngelegtVon { get; set; }

  /// <summary>Holt oder setzt Geändert am.</summary>
  [Display(Name = "Geändert am", Description = "Der Zeitpunkt der letzten Änderung")]
  //// [Required(ErrorMessage = "Geändert am muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Geändert am darf maximal {1} Zeichen lang sein.")]
  public DateTime? GeaendertAm { get; set; }

  /// <summary>Holt oder setzt Geändert von.</summary>
  [Display(Name = "Geändert von", Description = "Die Benutzer-ID der letzten Änderung")]
  //// [Required(ErrorMessage = "Geändert von muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Geändert von darf maximal {1} Zeichen lang sein.")]
  public string? GeaendertVon { get; set; }

  /// <summary>Kopiert die Werte in ein Model.</summary>
  /// <param name="daten">Service-Daten für den Datenbankzugriff.</param>
  public WpAnlage To(ServiceDaten daten)
  {
    return new WpAnlage
    {
      Mandant_Nr = daten.MandantNr,
      Uid = Nummer,
      Bezeichnung = Bezeichnung,
      // State = Status,
      StockProvider = Provider,
      StockShortcut = Kuerzel,
      PriceDate = Functions.ToDateTime(Valuta),
      Angelegt_Am = AngelegtAm,
      Angelegt_Von = AngelegtVon,
      Geaendert_Am = GeaendertAm,
      Geaendert_Von = GeaendertVon,
    };
  }

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public static WP250TableRowModel From(WpAnlage m)
  {
    return new WP250TableRowModel
    {
      Nummer = m.Uid,
      Bezeichnung = m.Bezeichnung,
      Status = CsbpBase.GetStockState(m.State.ToString(), m.StockShortcut),
      Provider = m.StockProvider,
      Kuerzel = m.StockShortcut,
      Valuta = Functions.ToString(m.PriceDate),
      AngelegtAm = m.Angelegt_Am,
      AngelegtVon = m.Angelegt_Von,
      GeaendertAm = m.Geaendert_Am,
      GeaendertVon = m.Geaendert_Von,
    };
  }
}
