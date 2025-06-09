// <copyright file="FZ250ModalModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Fz;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das modale Formular FZ250 Fahrradstände.
/// </summary>
[Serializable]
public class FZ250ModalModel : PageModelBase
{
  /// <summary>Holt oder setzt Nr..</summary>
  [Display(Name = "Nr.", Description = "Fahrradstand-Nr.")]
  //// [Required(ErrorMessage = "Nr. muss angegeben werden.")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt Fahrrad.</summary>
  [Display(Name = "_Fahrrad", Description = "Fahrrad")]
  //// [Required(ErrorMessage = "Fahrrad muss angegeben werden.")]
  public string? Fahrrad { get; set; }

  /// <summary>Holt oder setzt Datum.</summary>
  [Display(Name = "_Datum", Description = "")]
  //// [Required(ErrorMessage = "Datum muss angegeben werden.")]
  public string? Datum { get; set; }

  /// <summary>Holt oder setzt Zähler.</summary>
  [Display(Name = "_Zähler", Description = "Zählerstand")]
  //// [Required(ErrorMessage = "Zähler muss angegeben werden.")]
  public string? Zaehler { get; set; }

  /// <summary>Holt oder setzt Km.</summary>
  [Display(Name = "_Km", Description = "Tages- oder Wochen-km")]
  //// [Required(ErrorMessage = "Km muss angegeben werden.")]
  public string? Km { get; set; }

  /// <summary>Holt oder setzt Schnitt.</summary>
  [Display(Name = "_Schnitt", Description = "Durchschnittsgeschwindigkeit")]
  //// [Required(ErrorMessage = "Schnitt muss angegeben werden.")]
  public string? Schnitt { get; set; }

  /// <summary>Holt oder setzt Beschreibung.</summary>
  [Display(Name = "_Beschreibung", Description = "Beschreibung")]
  //// [Required(ErrorMessage = "Beschreibung muss angegeben werden.")]
  public string? Beschreibung { get; set; }

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
  public FZ250TodoModel To(ServiceDaten daten) => new()
  {
    // TODO Mandant_Nr = daten.MandantNr,
    Nummer = Nummer,
    Fahrrad = Fahrrad,
    Datum = Datum,
    Zaehler = Zaehler,
    Km = Km,
    Schnitt = Schnitt,
    Beschreibung = Beschreibung,
  };

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public void From(FZ250TableRowModel m) =>
  (
    Nummer,
    Fahrrad,
    Datum,
    Zaehler,
    Km,
    Schnitt,
    Beschreibung
    // TODO , Angelegt, Geaendert
  ) = (
    m.Nummer,
    m.Fahrrad,
    m.Datum,
    m.Zaehler,
    m.Km,
    m.Schnitt,
    m.Beschreibung
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
