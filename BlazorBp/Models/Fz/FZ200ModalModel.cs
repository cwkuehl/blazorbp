// <copyright file="FZ200ModalModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Fz;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das modale Formular FZ200 Fahrräder.
/// </summary>
[Serializable]
public class FZ200ModalModel : PageModelBase
{
  /// <summary>Holt oder setzt Nr..</summary>
  [Display(Name = "Nr.", Description = "Fahrrad-Nr.")]
  //// [Required(ErrorMessage = "Nr. muss angegeben werden.")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt Bezeichnung.</summary>
  [Display(Name = "Bezeichnung", Description = "Bezeichnung")]
  [Required(ErrorMessage = "Bezeichnung muss angegeben werden.")]
  public string? Bezeichnung { get; set; }

  /// <summary>Holt oder setzt die Liste von Typ.</summary>
  public List<ListItem>? AuswahlTyp { get; set; }

  /// <summary>Holt oder setzt Typ.</summary>
  [Display(Name = "Typ", Description = "")]
  [Required(ErrorMessage = "Typ muss angegeben werden.")]
  public string? Typ { get; set; }

  /// <summary>Holt oder setzt Angelegt.</summary>
  [Display(Name = "Angelegt", Description = "Datum, Uhrzeit und Benutzer, der die Daten angelegt hat")]
  public string? Angelegt { get; set; }

  /// <summary>Holt oder setzt Geändert.</summary>
  [Display(Name = "Geändert", Description = "Datum, Uhrzeit und Benutzer, der die Daten geändert hat")]
  public string? Geaendert { get; set; }

  /// <summary>Holt oder setzt OK.</summary>
  [Display(Name = "_OK", Description = "Dialog mit Speichern schließen")]
  public string? Ok { get; set; }

  /// <summary>Holt oder setzt Abbrechen.</summary>
  [Display(Name = "Abbre_chen", Description = "Dialog ohne Speichern schließen")]
  public string? Abbrechen { get; set; }

  /// <summary>Kopiert die Werte in ein Model.</summary>
  /// <param name="daten">Service-Daten für den Datenbankzugriff.</param>
  /// <returns>Das kopierte Model.</returns>
  public FzFahrrad To(ServiceDaten daten) => new()
  {
    Mandant_Nr = daten.MandantNr,
    Uid = Nummer,
    Bezeichnung = Bezeichnung,
    Typ = Functions.ToInt32(Typ),
  };

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public void From(FZ200TableRowModel m) =>
  (
    Nummer,
    Bezeichnung,
    Typ,
    Angelegt,
    Geaendert
  ) = (
    m.Nummer,
    m.Bezeichnung,
    Functions.ToString(FzFahrrad.GetTyp(m.Typ)),
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
      Typ = Functions.ToString((int)CSBP.Services.Apis.Enums.BikeTypeEnum.Tour);
    }
    SetMandatoryHiddenReadonly(nameof(Nummer), false, false, true, false);
    SetMandatoryHiddenReadonly(nameof(Bezeichnung), true, false, mode == Delete, mode == New);
    SetMandatoryHiddenReadonly(nameof(Typ), true, false, mode == Delete, mode == Edit);
    SetMandatoryHiddenReadonly(nameof(Angelegt), false, mode == New, true);
    SetMandatoryHiddenReadonly(nameof(Geaendert), false, mode == New, true);
    SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, mode == Delete);
  }
}
