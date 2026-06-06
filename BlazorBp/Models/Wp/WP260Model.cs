// <copyright file="WP260Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Wp;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das modale Formular WP260 Anlagen.
/// </summary>
[Serializable]
public class WP260Model : PageModelBase
{
  /// <summary>Holt oder setzt Nr..</summary>
  [Display(Name = "Nr.", Description = "Anlagen-Nr.")]
  //// [Required(ErrorMessage = "Nr. muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Nr. darf maximal {1} Zeichen lang sein.")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt Wertpapier.</summary>
  [Display(Name = "_Wertpapier", Description = "Bezug zum Wertpapier")]
  //// [Required(ErrorMessage = "Wertpapier muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Wertpapier darf maximal {1} Zeichen lang sein.")]
  public string? Wertpapier { get; set; }

  /// <summary>Holt oder setzt ....</summary>
  [Display(Name = "...", Description = "Wertpapier-Details anzeigen")]
  //// [Required(ErrorMessage = "... muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "... darf maximal {1} Zeichen lang sein.")]
  public string? Wpdetails { get; set; }

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

  /// <summary>Holt oder setzt Depot-Konto.</summary>
  [Display(Name = "Depot-Konto", Description = "Depot-Konto für gleichzeitige Haushaltsbuchung")]
  //// [Required(ErrorMessage = "Depot-Konto muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Depot-Konto darf maximal {1} Zeichen lang sein.")]
  public string? Depot { get; set; }

  /// <summary>Holt oder setzt Abrechnungs-Konto.</summary>
  [Display(Name = "Abrechnungs-Konto", Description = "Abrechnungs-Konto für gleichzeitige Haushaltsbuchung")]
  //// [Required(ErrorMessage = "Abrechnungs-Konto muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Abrechnungs-Konto darf maximal {1} Zeichen lang sein.")]
  public string? Abrechnung { get; set; }

  /// <summary>Holt oder setzt Ertrags-Konto.</summary>
  [Display(Name = "Ertrags-Konto", Description = "Ertrags-Konto für gleichzeitige Haushaltsbuchung")]
  //// [Required(ErrorMessage = "Ertrags-Konto muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Ertrags-Konto darf maximal {1} Zeichen lang sein.")]
  public string? Ertrag { get; set; }

  /// <summary>Holt oder setzt Notiz.</summary>
  [Display(Name = "_Notiz", Description = "")]
  //// [Required(ErrorMessage = "Notiz muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Notiz darf maximal {1} Zeichen lang sein.")]
  public string? Notiz { get; set; }

  /// <summary>Holt oder setzt Daten.</summary>
  [Display(Name = "_Daten", Description = "Daten für die Anlage, z.B. Anzahl Anteile und Kaufpreis")]
  //// [Required(ErrorMessage = "Daten muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Daten darf maximal {1} Zeichen lang sein.")]
  public string? Data { get; set; }

  /// <summary>Holt oder setzt Angelegt.</summary>
  [Display(Name = "Angelegt", Description = "Datum, Uhrzeit und Benutzer, der die Daten angelegt hat")]
  //// [Required(ErrorMessage = "Angelegt muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Angelegt darf maximal {1} Zeichen lang sein.")]
  public string? Angelegt { get; set; }

  /// <summary>Holt oder setzt Geändert.</summary>
  [Display(Name = "Geändert", Description = "Datum, Uhrzeit und Benutzer, der die Daten geändert hat")]
  //// [Required(ErrorMessage = "Geändert muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Geändert darf maximal {1} Zeichen lang sein.")]
  public string? Geaendert { get; set; }

  /// <summary>Holt oder setzt Valuta.</summary>
  [Display(Name = "Valuta", Description = "Valuta-Datum für das Setzen des Stands")]
  public string? Valuta { get; set; }

  /// <summary>Holt oder setzt Stand.</summary>
  [Display(Name = "_Stand", Description = "Wert aller Anteile der Anlage am Datum")]
  //// [Required(ErrorMessage = "Stand muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Stand darf maximal {1} Zeichen lang sein.")]
  public string? Stand { get; set; }

  /// <summary>Holt oder setzt OK.</summary>
  [Display(Name = "_OK", Description = "Dialog mit Speichern schließen")]
  //// [Required(ErrorMessage = "OK muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "OK darf maximal {1} Zeichen lang sein.")]
  public string? Ok { get; set; }

  /// <summary>Holt oder setzt Abbrechen.</summary>
  [Display(Name = "Abbre_chen", Description = "Dialog ohne Speichern schließen")]
  //// [Required(ErrorMessage = "Abbrechen muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Abbrechen darf maximal {1} Zeichen lang sein.")]
  public string? Abbrechen { get; set; }

  /// <summary>Kopiert die Werte in ein Model.</summary>
  /// <param name="daten">Service-Daten für den Datenbankzugriff.</param>
  /// <returns>Das kopierte Model.</returns>
  public WP250TodoModel To(ServiceDaten daten) => new()
  {
    // TODO Mandant_Nr = daten.MandantNr,
    Nummer = Nummer,
    Wertpapier = Wertpapier,
    Wpdetails = Wpdetails,
    Bezeichnung = Bezeichnung,
    Status = Status,
    Depot = Depot,
    Abrechnung = Abrechnung,
    Ertrag = Ertrag,
    Notiz = Notiz,
    Data = Data,
    Valuta = Valuta,
    Stand = Stand,
  };
  
  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public void From(WP250TableRowModel m) =>
  (
    Nummer,
    Wertpapier,
    Wpdetails,
    Bezeichnung,
    Status,
    Depot,
    Abrechnung,
    Ertrag,
    Notiz,
    Data,
    Valuta,
    Stand
    // TODO , Angelegt, Geaendert
  ) = (
    m.Nummer,
    m.Wertpapier,
    m.Wpdetails,
    m.Bezeichnung,
    m.Status,
    m.Depot,
    m.Abrechnung,
    m.Ertrag,
    m.Notiz,
    m.Data,
    m.Valuta,
    m.Stand
    // TODO , ModelBase.FormatDateOf(m.AngelegtAm, m.AngelegtVon), ModelBase.FormatDateOf(m.GeaendertAm, m.GeaendertVon)
  );

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  public void SetMhrf(DialogTypeEnum mode)
  {
    if (mode == New || mode == Copy)
    {
      // TODO Nummer = "";
    }
    if (mode == New)
    {
      // TODO Thema = null;
    }
    // TODO SetMandatoryHiddenReadonly(nameof(Nummer), true, false, true, false);
    // SetMandatoryHiddenReadonly(nameof(Thema), true, false, mode == Delete, mode == New);
    // SetMandatoryHiddenReadonly(nameof(Angelegt), false, mode == New, true);
    // SetMandatoryHiddenReadonly(nameof(Geaendert), false, mode == New, true);
    // SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, mode == Delete);
  }
}
