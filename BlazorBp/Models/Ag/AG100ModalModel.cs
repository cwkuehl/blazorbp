// <copyright file="AG100ModalModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Ag;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using static BlazorBp.Base.DialogTypeEnum;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;

/// <summary>
/// Model-Klasse für das modale Formular AG100 Mandanten.
/// </summary>
[Serializable]
public class AG100ModalModel : PageModelBase
{
  /// <summary>Holt oder setzt die Nummer.</summary>
  [Display(Name = "_Nr.", Description = "Die Nummer des Mandanten kann nicht geändert werden.")]
  [Required(ErrorMessage = "Die Nummer muss angegeben werden.")]
  public string? Nummer { get; set; } = default!;

  /// <summary>Holt oder setzt die Beschreibung.</summary>
  [Display(Name = "Be_schreibung", Description = "Die Beschreibung des Mandanten muss angegeben werden.")]
  [Required(ErrorMessage = "Die Beschreibung muss angegeben werden.")]
  public string? Beschreibung { get; set; } = default!;

  /// <summary>Holt oder setzt die Revisionsaten der Anlage.</summary>
  [Display(Name = "Angelegt", Description = "Die Benutzer-ID und der Zeitpunkt der Anlage.")]
  public string? Angelegt { get; set; } = default!;

  /// <summary>Holt oder setzt die Revisionsaten der letzten Änderung.</summary>
  [Display(Name = "Geändert", Description = "Die Benutzer-ID und der Zeitpunkt der letzten Änderung.")]
  public string? Geaendert { get; set; } = default!;

  /// <summary>Holt oder setzt den OK-Button.</summary>
  [Display(Name = "_OK", Description = "Formular schließen mit Speichern.")]
  public string? Ok { get; set; } = default!;

  /// <summary>Holt oder setzt den Schließen-Button.</summary>
  [Display(Name = "S_chließen", Description = "Formular schließen ohne Speichern.")]
  public string? Schliessen { get; set; } = default!;

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public void From(AG100TableRowModel m) =>
   (Nummer, Beschreibung, Angelegt, Geaendert) = (Functions.ToString(m.Nummer), m.Beschreibung, ModelBase.FormatDateOf(m.AngelegtAm, m.AngelegtVon), ModelBase.FormatDateOf(m.GeaendertAm, m.GeaendertVon));

  /// <summary>Kopiert die Werte in ein Model.</summary>
  /// <returns>Das kopierte Model.</returns>
  public MaMandant To() => new()
  {
    Nr = Functions.ToInt32(Nummer),
    Beschreibung = Beschreibung,
  };

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  public void SetMhrf(DialogTypeEnum mode)
  {
    if (mode == New)
    {
      Nummer = "";
      Beschreibung = null;
    }
    SetMandatoryHiddenReadonly(nameof(Nummer), true, false, mode != New, mode == New);
    SetMandatoryHiddenReadonly(nameof(Beschreibung), true, false, mode == Delete, mode == Edit);
    SetMandatoryHiddenReadonly(nameof(Angelegt), false, mode == New, true);
    SetMandatoryHiddenReadonly(nameof(Geaendert), false, mode == New, true);
    SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, mode == Delete);
  }
}
