// <copyright file="FZ200ModalModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Fz;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
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
  //// [Required(ErrorMessage = "Bezeichnung muss angegeben werden.")]
  public string? Bezeichnung { get; set; }

  /// <summary>Holt oder setzt Typ.</summary>
  [Display(Name = "Typ", Description = "")]
  //// [Required(ErrorMessage = "Typ muss angegeben werden.")]
  public string? Typ0 { get; set; }

  /// <summary>Holt oder setzt Tour.</summary>
  [Display(Name = "Tour", Description = "Tageswerte")]
  //// [Required(ErrorMessage = "Tour muss angegeben werden.")]
  public string? Typ1 { get; set; }

  /// <summary>Holt oder setzt Wöchentlich.</summary>
  [Display(Name = "Wöchentlich", Description = "Wochenwerte")]
  //// [Required(ErrorMessage = "Wöchentlich muss angegeben werden.")]
  public string? Typ2 { get; set; }

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
  /// <returns>Das kopierte Model.</returns>
  public FZ200TodoModel To() => new()
  {
    Nummer = Nummer,
    Bezeichnung = Bezeichnung,
    Typ0 = Typ0,
    Typ1 = Typ1,
    Typ2 = Typ2,
  };

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public void From(FZ200TableRowModel m) =>
  (
    Nummer,
    Bezeichnung,
    Typ0,
    Typ1,
    Typ2
    // TODO , Angelegt, Geaendert
  ) = (
    m.Nummer,
    m.Bezeichnung,
    m.Typ0,
    m.Typ1,
    m.Typ2
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
