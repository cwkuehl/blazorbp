// <copyright file="EN110Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.En;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das modale Formular EN110 Abfrage-Parameter.
/// </summary>
[Serializable]
public class EN110Model : PageModelBase
{
  /// <summary>Holt oder setzt Nr..</summary>
  [Display(Name = "Nr.", Description = "Abfrage-Nr.")]
  //// [Required(ErrorMessage = "Nr. muss angegeben werden.")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt Bezeichnung.</summary>
  [Display(Name = "_Bezeichnung", Description = "Bezeichnung")]
  [Required(ErrorMessage = "Bezeichnung muss angegeben werden.")]
  public string? Bezeichnung { get; set; }

  /// <summary>Holt oder setzt die Sortierung.</summary>
  [Display(Name = "_Sortierung", Description = "Sortierung")]
  [Required(ErrorMessage = "Sortierung muss angegeben werden.")]
  public string? Sortierung { get; set; }

  /// <summary>Holt oder setzt die Auswahlliste von Art.</summary>
  public List<ListItem>? AuswahlArt { get; set; } = default!;

  /// <summary>Holt oder setzt die Art.</summary>
  [Display(Name = "_Art", Description = "Art der Abfrage, z.B. Modbus-Tcp oder JSON.")]
  [Required(ErrorMessage = "Art muss angegeben werden.")]
  public string? Art { get; set; }

  // /// <summary>Holt oder setzt Aktueller Kurs.</summary>
  // [Display(Name = "Aktueller Kurs", Description = "Aktueller Kurs aus letzter Bewertung")]
  // //// [Required(ErrorMessage = "Aktueller Kurs muss angegeben werden.")]
  // public string? AktKurs { get; set; }

  // /// <summary>Holt oder setzt Stop-Kurs.</summary>
  // [Display(Name = "Stop-Kurs", Description = "Stop-Kurs aus letzter Bewertung")]
  // //// [Required(ErrorMessage = "Stop-Kurs muss angegeben werden.")]
  // public string? StopKurs { get; set; }

  // /// <summary>Holt oder setzt Kursziel.</summary>
  // [Display(Name = "Kurs_ziel", Description = "Manuelles Kursziel")]
  // //// [Required(ErrorMessage = "Kursziel muss angegeben werden.")]
  // public string? SignalKurs1 { get; set; }

  // /// <summary>Holt oder setzt Letztes Muster.</summary>
  // [Display(Name = "Letztes Muster", Description = "Letztes Signalmuster aus letzter Bewertung")]
  // //// [Required(ErrorMessage = "Letztes Muster muss angegeben werden.")]
  // public string? Muster { get; set; }

  // /// <summary>Holt oder setzt Typ.</summary>
  // [Display(Name = "_Typ", Description = "Aktie (wenn leer) oder Anleihe")]
  // //// [Required(ErrorMessage = "Typ muss angegeben werden.")]
  // public string? Typ { get; set; }

  // /// <summary>Holt oder setzt Währung.</summary>
  // [Display(Name = "_Währung", Description = "Währungskürzel für Kursabfrage; EUR, GBP, USD, ...")]
  // //// [Required(ErrorMessage = "Währung muss angegeben werden.")]
  // public string? Waehrung { get; set; }

  // /// <summary>Holt oder setzt Sortierung.</summary>
  // [Display(Name = "Sortierun_g", Description = "Zeichenkette für Sortierung")]
  // //// [Required(ErrorMessage = "Sortierung muss angegeben werden.")]
  // public string? Sortierung { get; set; }

  // /// <summary>Holt oder setzt die Auswahlliste von Relation.</summary>
  // public List<ListItem>? AuswahlRelation { get; set; } = default!;

  // /// <summary>Holt oder setzt Relation.</summary>
  // [Display(Name = "_Relation", Description = "Relation zu anderem Wertpapier, z.B. Index")]
  // //// [Required(ErrorMessage = "Relation muss angegeben werden.")]
  // public string? Relation { get; set; }

  /// <summary>Holt oder setzt die Auswahlliste von Status.</summary>
  public List<ListItem>? AuswahlStatus { get; set; } = default!;

  /// <summary>Holt oder setzt Status.</summary>
  [Display(Name = "_Status", Description = "Status für Berechnung")]
  [Required(ErrorMessage = "Status muss angegeben werden.")]
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

  // /// <summary>Holt oder setzt Anlage erstellen.</summary>
  // [Display(Name = "Anlage erstellen", Description = "Soll für das Wertpapier auch eine Anlage erstellt werden?")]
  // //// [Required(ErrorMessage = "Anlage erstellen muss angegeben werden.")]
  // public bool Anlage { get; set; }

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
  public EnAbfrage To(ServiceDaten daten) => new()
  {
    Mandant_Nr = daten.MandantNr,
    Uid = Nummer,
    Bezeichnung = Bezeichnung,
    Notiz = Notiz,
  };

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public void From(EnAbfrage m) =>
  (
    Nummer,
    Bezeichnung,
    Sortierung,
    Art,
    Status,
    Notiz,
    Angelegt,
    Geaendert
  ) = (
    m.Uid,
    m.Bezeichnung,
    m.Sortierung,
    m.Art,
    m.Status,
    m.Notiz,
    ModelBase.FormatDateOf(m.Angelegt_Am, m.Angelegt_Von),
    ModelBase.FormatDateOf(m.Geaendert_Am, m.Geaendert_Von)
  );

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  public void SetMhrf(DialogTypeEnum mode)
  {
    if (mode == New || mode == Copy)
    {
      // Anlage = true;
    }
    SetMandatoryHiddenReadonly(nameof(Nummer), false, false, true, false);
    SetMandatoryHiddenReadonly(nameof(Bezeichnung), true, false, mode == Delete, mode != New);
    SetMandatoryHiddenReadonly(nameof(Sortierung), true, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Art), true, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Status), true, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Notiz), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Angelegt), false, mode == New, true);
    SetMandatoryHiddenReadonly(nameof(Geaendert), false, mode == New, true);
    SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, mode == Delete);
  }
}
