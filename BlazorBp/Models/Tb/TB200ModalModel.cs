// <copyright file="TB200ModalModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Tb;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das modale Formular TB200 Positionen.
/// </summary>
[Serializable]
public class TB200ModalModel : PageModelBase
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

  /// <summary>Holt oder setzt Angelegt.</summary>
  [Display(Name = "Angelegt", Description = "")]
  //// [Required(ErrorMessage = "Angelegt muss angegeben werden.")]
  public string? Angelegt { get; set; }

  /// <summary>Holt oder setzt Geändert.</summary>
  [Display(Name = "Geändert", Description = "")]
  //// [Required(ErrorMessage = "Geändert muss angegeben werden.")]
  public string? Geaendert { get; set; }

  /// <summary>Holt oder setzt OK.</summary>
  [Display(Name = "_OK", Description = "")]
  //// [Required(ErrorMessage = "OK muss angegeben werden.")]
  public string? Ok { get; set; }

  /// <summary>Holt oder setzt Abbrechen.</summary>
  [Display(Name = "Abbre_chen", Description = "")]
  //// [Required(ErrorMessage = "Abbrechen muss angegeben werden.")]
  public string? Abbrechen { get; set; }

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

  /// <summary>Kopiert die Werte in ein Model.</summary>
  /// <param name="daten">Service-Daten für den Datenbankzugriff.</param>
  /// <returns>Das kopierte Model.</returns>
  public TB200TodoModel To(ServiceDaten daten) => new()
  {
    // TODO Mandant_Nr = daten.MandantNr,
    Nummer = Nummer,
    Bezeichnung = Bezeichnung,
    Breite = Breite,
    Notiz = Notiz,
    Laenge = Laenge,
    Hoehe = Hoehe,
    Zeitzone = Zeitzone,
  };

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public void From(TB200TableRowModel m) =>
  (
    Nummer,
    Bezeichnung,
    Breite,
    Notiz,
    Laenge,
    Hoehe,
    Zeitzone
    // TODO , Angelegt, Geaendert
  ) = (
    m.Nummer,
    m.Bezeichnung,
    m.Breite,
    m.Notiz,
    m.Laenge,
    m.Hoehe,
    m.Zeitzone
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
