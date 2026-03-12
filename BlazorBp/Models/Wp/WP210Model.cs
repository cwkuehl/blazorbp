// <copyright file="WP210Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Wp;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das modale Formular WP210 Wertpapiere.
/// </summary>
[Serializable]
public class WP210Model : PageModelBase
{
  /// <summary>Holt oder setzt Nr..</summary>
  [Display(Name = "Nr.", Description = "Wertpapier-Nr.")]
  //// [Required(ErrorMessage = "Nr. muss angegeben werden.")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt Bezeichnung.</summary>
  [Display(Name = "_Bezeichnung", Description = "Bezeichnung")]
  //// [Required(ErrorMessage = "Bezeichnung muss angegeben werden.")]
  public string? Bezeichnung { get; set; }

  /// <summary>Holt oder setzt Provider.</summary>
  [Display(Name = "_Provider", Description = "Provider für Kursabfrage")]
  //// [Required(ErrorMessage = "Provider muss angegeben werden.")]
  public string? Provider { get; set; }

  /// <summary>Holt oder setzt Kürzel.</summary>
  [Display(Name = "_Kürzel", Description = "Kürzel für Kursabfrage beim Provider")]
  //// [Required(ErrorMessage = "Kürzel muss angegeben werden.")]
  public string? Kuerzel { get; set; }

  /// <summary>Holt oder setzt Status.</summary>
  [Display(Name = "_Status", Description = "Status für Berechnung")]
  //// [Required(ErrorMessage = "Status muss angegeben werden.")]
  public string? Status { get; set; }

  /// <summary>Holt oder setzt Aktueller Kurs.</summary>
  [Display(Name = "Aktueller Kurs", Description = "Aktueller Kurs aus letzter Bewertung")]
  //// [Required(ErrorMessage = "Aktueller Kurs muss angegeben werden.")]
  public string? AktKurs { get; set; }

  /// <summary>Holt oder setzt Stop-Kurs.</summary>
  [Display(Name = "Stop-Kurs", Description = "Stop-Kurs aus letzter Bewertung")]
  //// [Required(ErrorMessage = "Stop-Kurs muss angegeben werden.")]
  public string? StopKurs { get; set; }

  /// <summary>Holt oder setzt Kursziel.</summary>
  [Display(Name = "Kurs_ziel", Description = "Manuelles Kursziel")]
  //// [Required(ErrorMessage = "Kursziel muss angegeben werden.")]
  public string? SignalKurs1 { get; set; }

  /// <summary>Holt oder setzt Letztes Muster.</summary>
  [Display(Name = "Letztes Muster", Description = "Letztes Signalmuster aus letzter Bewertung")]
  //// [Required(ErrorMessage = "Letztes Muster muss angegeben werden.")]
  public string? Muster { get; set; }

  /// <summary>Holt oder setzt Typ.</summary>
  [Display(Name = "_Typ", Description = "Aktie (wenn leer) oder Anleihe")]
  //// [Required(ErrorMessage = "Typ muss angegeben werden.")]
  public string? Typ { get; set; }

  /// <summary>Holt oder setzt Währung.</summary>
  [Display(Name = "_Währung", Description = "Währungskürzel für Kursabfrage; EUR, GBP, USD, ...")]
  //// [Required(ErrorMessage = "Währung muss angegeben werden.")]
  public string? Waehrung { get; set; }

  /// <summary>Holt oder setzt Sortierung.</summary>
  [Display(Name = "Sortierun_g", Description = "Zeichenkette für Sortierung")]
  //// [Required(ErrorMessage = "Sortierung muss angegeben werden.")]
  public string? Sortierung { get; set; }

  /// <summary>Holt oder setzt Relation.</summary>
  [Display(Name = "_Relation", Description = "Relation zu anderem Wertpapier, z.B. Index")]
  //// [Required(ErrorMessage = "Relation muss angegeben werden.")]
  public string? Relation { get; set; }

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

  /// <summary>Holt oder setzt Anlage erstellen.</summary>
  [Display(Name = "Anlage erstellen", Description = "Soll für das Wertpapier auch eine Anlage erstellt werden?")]
  //// [Required(ErrorMessage = "Anlage erstellen muss angegeben werden.")]
  public string? Anlage { get; set; }

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
  public WP200TodoModel To(ServiceDaten daten) => new()
  {
    // TODO Mandant_Nr = daten.MandantNr,
    Nummer = Nummer,
    Bezeichnung = Bezeichnung,
    Provider = Provider,
    Kuerzel = Kuerzel,
    Status = Status,
    AktKurs = AktKurs,
    StopKurs = StopKurs,
    SignalKurs1 = SignalKurs1,
    Muster = Muster,
    Typ = Typ,
    Waehrung = Waehrung,
    Sortierung = Sortierung,
    Relation = Relation,
    Notiz = Notiz,
    Anlage = Anlage,
  };

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public void From(WP200TableRowModel m) =>
  (
    Nummer,
    Bezeichnung,
    Provider,
    Kuerzel,
    Status,
    AktKurs,
    StopKurs,
    SignalKurs1,
    Muster,
    Typ,
    Waehrung,
    Sortierung,
    Relation,
    Notiz,
    Anlage
    // TODO , Angelegt, Geaendert
  ) = (
    m.Nummer,
    m.Bezeichnung,
    m.Provider,
    m.Kuerzel,
    m.Status,
    m.AktKurs,
    m.StopKurs,
    m.SignalKurs1,
    m.Muster,
    m.Typ,
    m.Waehrung,
    m.Sortierung,
    m.Relation,
    m.Notiz,
    m.Anlage
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
