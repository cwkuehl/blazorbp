// <copyright file="TB100ModalModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Tb;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Apis.Models.Views;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das modale Formular TB100 Datum der Position.
/// </summary>
[Serializable]
public class TB100ModalModel : PageModelBase
{
  /// <summary>Holt oder setzt Nr..</summary>
  [Display(Name = "Positions-Nr.", Description = "Positions-Nr.")]
  //// [Required(ErrorMessage = "Nr. muss angegeben werden.")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt die Bezeichnung.</summary>
  [Display(Name = "Bezeichnung", Description = "Bezeichnung der Position")]
  //// [Required(ErrorMessage = "Bezeichnung muss angegeben werden.")]
  public string? Bezeichnung { get; set; }

  /// <summary>Holt oder setzt Datum.</summary>
  [Display(Name = "_Bis-Datum", Description = "Bis-Datum der Position")]
  [Required(ErrorMessage = "Datum muss angegeben werden.")]
  public DateTime? Datum { get; set; }

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
  public TbEintragOrt To(ServiceDaten daten) => new()
  {
    Mandant_Nr = daten.MandantNr,
    Ort_Uid = Nummer,
    Description = Bezeichnung,
    Datum_Bis = Datum ?? daten.Heute,
  };

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public void From(TbEintragOrt m) =>
  (
    Nummer,
    Bezeichnung,
    Datum
  ) = (
    m.Ort_Uid,
    m.Description,
    m.Datum_Bis
  );

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  public void SetMhrf(DialogTypeEnum mode)
  {
    if (mode == New)
    {
      Datum = DateTime.Today;
    }
    SetMandatoryHiddenReadonly(nameof(Nummer), true, false, true, false);
    SetMandatoryHiddenReadonly(nameof(Bezeichnung), true, false, true, false);
    SetMandatoryHiddenReadonly(nameof(Datum), true, false, true, true);
    SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, false);
  }
}
