// <copyright file="TB200ModalModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Tb;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
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
  public decimal Breite { get; set; }

  /// <summary>Holt oder setzt Länge.</summary>
  [Display(Name = "_Länge", Description = "")]
  //// [Required(ErrorMessage = "Länge muss angegeben werden.")]
  public decimal Laenge { get; set; }

  /// <summary>Holt oder setzt Höhe.</summary>
  [Display(Name = "_Höhe", Description = "")]
  //// [Required(ErrorMessage = "Höhe muss angegeben werden.")]
  public decimal Hoehe { get; set; }

  /// <summary>Holt oder setzt Zeitzone.</summary>
  [Display(Name = "_Zeitzone", Description = "Zeitzone")]
  //// [Required(ErrorMessage = "Zeitzone muss angegeben werden.")]
  public string? Zeitzone { get; set; }

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

  /// <summary>Kopiert die Werte in ein Model.</summary>
  /// <param name="daten">Service-Daten für den Datenbankzugriff.</param>
  /// <returns>Das kopierte Model.</returns>
  public TbOrt To(ServiceDaten daten) => new()
  {
    Mandant_Nr = daten.MandantNr,
    Uid = Nummer,
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
    Laenge,
    Hoehe,
    Zeitzone,
    Notiz,
    Angelegt,
    Geaendert
  ) = (
    m.Nummer,
    m.Bezeichnung,
    Functions.ToDecimal(m.Breite) ?? 0m,
    Functions.ToDecimal(m.Laenge) ?? 0m,
    Functions.ToDecimal(m.Hoehe) ?? 0m,
    m.Zeitzone,
    m.Notiz,
    ModelBase.FormatDateOf(m.AngelegtAm, m.AngelegtVon),
    ModelBase.FormatDateOf(m.GeaendertAm, m.GeaendertVon)
  );

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  public void SetMhrf(DialogTypeEnum mode)
  {
    if (mode == New || mode == Copy)
    {
      Nummer = "";
    }
    if (mode == New)
    {
      Bezeichnung = null;
    }
    SetMandatoryHiddenReadonly(nameof(Nummer), true, false, true, false);
    SetMandatoryHiddenReadonly(nameof(Bezeichnung), true, false, mode == Delete, mode == New);
    SetMandatoryHiddenReadonly(nameof(Breite), true, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Laenge), true, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Hoehe), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Zeitzone), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Notiz), false, false, mode == Delete, false);
    SetMandatoryHiddenReadonly(nameof(Angelegt), false, mode == New, true);
    SetMandatoryHiddenReadonly(nameof(Geaendert), false, mode == New, true);
    SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, mode == Delete);
  }
}
