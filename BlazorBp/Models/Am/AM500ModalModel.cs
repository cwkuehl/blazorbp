// <copyright file="AM500ModalModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Am;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using static BlazorBp.Base.DialogTypeEnum;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;

/// <summary>
/// Model-Klasse für das modale Formular AM500 Einstellungen.
/// </summary>
[Serializable]
public class AM500ModalModel : PageModelBase
{
  /// <summary>Holt oder setzt den Schlüssel.</summary>
  [Display(Name = "_Schlüssel", Description = "Der Schlüssel kann nicht geändert werden.")]
  [Required(ErrorMessage = "Der Schlüssel muss angegeben werden.")]
  public string Schluessel { get; set; } = default!;

  /// <summary>Holt oder setzt den Wert.</summary>
  [Display(Name = "_Wert", Description = "Der Wert kann angegeben werden.")]
  public string? Wert { get; set; } = default!;

  /// <summary>Holt oder setzt den Beschreibung.</summary>
  [Display(Name = "_Beschreibung", Description = "Die Beschreibung zur Einstellung.")]
  public string? Beschreibung { get; set; } = default!;

  /// <summary>Holt oder setzt den Standardwert.</summary>
  [Display(Name = "_Standard", Description = "Der Standardwert der Einstellung.")]
  public string? Standard { get; set; } = default!;

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
  public void From(AM500TableRowModel m) =>
   (Schluessel, Wert, Beschreibung, Standard, Angelegt, Geaendert)
   = (Functions.ToString(m.Schluessel), m.Wert, m.Beschreibung, m.Standard, ModelBase.FormatDateOf(m.AngelegtAm, m.AngelegtVon), ModelBase.FormatDateOf(m.GeaendertAm, m.GeaendertVon));

  /// <summary>Kopiert die Werte in ein Model.</summary>
  /// <returns>Das kopierte Model.</returns>
  /// <param name="mnr">Betroffene Mandantennummer.</param>
  public MaParameter To(int mnr) => new()
  {
    Mandant_Nr = mnr,
    Schluessel = Functions.ToString(Schluessel),
    Wert = Wert,
    Comment = Beschreibung,
    Default = Standard,
  };

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  public void SetMhrf(DialogTypeEnum mode)
  {
    if (mode == New)
    {
      Schluessel = "";
      Wert = null;
      Beschreibung = "";
      Standard = "";
    }
    SetMandatoryHiddenReadonly(nameof(Schluessel), true, false, mode != New, mode == New);
    SetMandatoryHiddenReadonly(nameof(Wert), false, false, mode == Delete, mode == Edit);
    SetMandatoryHiddenReadonly(nameof(Beschreibung), false, false, true);
    SetMandatoryHiddenReadonly(nameof(Standard), false, false, true);
    SetMandatoryHiddenReadonly(nameof(Angelegt), false, mode == New, true);
    SetMandatoryHiddenReadonly(nameof(Geaendert), false, mode == New, true);
    SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, mode == Delete);
  }
}
