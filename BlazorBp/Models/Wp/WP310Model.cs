// <copyright file="WP310Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Wp;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das modale Formular WP310 Konfigurationen.
/// </summary>
[Serializable]
public class WP310Model : PageModelBase
{
  /// <summary>Holt oder setzt Nr..</summary>
  [Display(Name = "Nr.", Description = "Konfiguration-Nr.")]
  //// [Required(ErrorMessage = "Nr. muss angegeben werden.")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt Bezeichnung.</summary>
  [Display(Name = "_Bezeichnung", Description = "Bezeichnung")]
  //// [Required(ErrorMessage = "Bezeichnung muss angegeben werden.")]
  public string? Bezeichnung { get; set; }

  /// <summary>Holt oder setzt Boxgröße.</summary>
  [Display(Name = "Bo_xgröße", Description = "Boxgröße absolut oder prozentual")]
  //// [Required(ErrorMessage = "Boxgröße muss angegeben werden.")]
  public string? Box { get; set; }

  /// <summary>Holt oder setzt Skala.</summary>
  [Display(Name = "_Skala", Description = "Skala für Kursberechnung")]
  //// [Required(ErrorMessage = "Skala muss angegeben werden.")]
  public string? Skala { get; set; }

  /// <summary>Holt oder setzt Umkehr.</summary>
  [Display(Name = "_Umkehr", Description = "Anzahl der Boxen für Umkehr")]
  //// [Required(ErrorMessage = "Umkehr muss angegeben werden.")]
  public string? Umkehr { get; set; }

  /// <summary>Holt oder setzt Methode.</summary>
  [Display(Name = "_Methode", Description = "Methode für Kursberechnung")]
  //// [Required(ErrorMessage = "Methode muss angegeben werden.")]
  public string? Methode { get; set; }

  /// <summary>Holt oder setzt Dauer.</summary>
  [Display(Name = "_Dauer", Description = "Anzahl der Tage, die ausgewertet werden sollen.")]
  //// [Required(ErrorMessage = "Dauer muss angegeben werden.")]
  public string? Dauer { get; set; }

  /// <summary>Holt oder setzt Relativ.</summary>
  [Display(Name = "_Relativ", Description = "Soll die Auswertung relativ zu anderem Wertpapier oder Index erfolgen?")]
  //// [Required(ErrorMessage = "Relativ muss angegeben werden.")]
  public string? Relativ { get; set; }

  /// <summary>Holt oder setzt Status.</summary>
  [Display(Name = "_Status", Description = "Status")]
  //// [Required(ErrorMessage = "Status muss angegeben werden.")]
  public string? Status { get; set; }

  /// <summary>Holt oder setzt Notiz.</summary>
  [Display(Name = "Notiz", Description = "")]
  //// [Required(ErrorMessage = "Notiz muss angegeben werden.")]
  public string? Notiz { get; set; }

  /// <summary>Holt oder setzt Angelegt.</summary>
  [Display(Name = "Angelegt", Description = "Datum, Uhrzeit und Benutzer, der die Daten angelegt hat")]
  //// [Required(ErrorMessage = "Angelegt muss angegeben werden.")]
  public string? Angelegt { get; set; }

  /// <summary>Holt oder setzt Geändert.</summary>
  [Display(Name = "Geändert", Description = "Datum, Uhrzeit und Benutzer, der die Daten geändert hat")]
  //// [Required(ErrorMessage = "Geändert muss angegeben werden.")]
  public string? Geaendert { get; set; }

  /// <summary>Holt oder setzt OK.</summary>
  [Display(Name = "_OK", Description = "Dialog mit Speichern schließen")]
  //// [Required(ErrorMessage = "OK muss angegeben werden.")]
  public string? Ok { get; set; }

  /// <summary>Holt oder setzt Abbrechen.</summary>
  [Display(Name = "Abbre_chen", Description = "Dialog ohne Speichern schließen")]
  //// [Required(ErrorMessage = "Abbrechen muss angegeben werden.")]
  public string? Abbrechen { get; set; }

  /// <summary>Kopiert die Werte in ein Model.</summary>
  /// <param name="daten">Service-Daten für den Datenbankzugriff.</param>
  /// <returns>Das kopierte Model.</returns>
  public WP300TodoModel To(ServiceDaten daten) => new()
  {
    // TODO Mandant_Nr = daten.MandantNr,
    Nummer = Nummer,
    Bezeichnung = Bezeichnung,
    Box = Box,
    Umkehr = Umkehr,
    Methode = Methode,
    Dauer = Dauer,
    Relativ = Relativ,
    Status = Status,
    Notiz = Notiz,
  };

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public void From(WP300TableRowModel m) =>
  (
    Nummer,
    Bezeichnung,
    Box,
    Umkehr,
    Methode,
    Dauer,
    Relativ,
    Status,
    Notiz
    // TODO , Angelegt, Geaendert
  ) = (
    m.Nummer,
    m.Bezeichnung,
    m.Box,
    m.Umkehr,
    m.Methode,
    m.Dauer,
    m.Relativ,
    m.Status,
    m.Notiz
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
