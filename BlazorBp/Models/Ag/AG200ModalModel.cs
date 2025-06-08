// <copyright file="AG200ModalModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Ag;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using static BlazorBp.Base.DialogTypeEnum;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;

/// <summary>
/// Model-Klasse für das modale Formular AG200 Benutzer.
/// </summary>
[Serializable]
public class AG200ModalModel : PageModelBase
{
  /// <summary>Holt oder setzt die Nummer.</summary>
  [Display(Name = "_Nr.", Description = "Die Nummer des Mandanten kann nicht geändert werden.")]
  [Required(ErrorMessage = "Die Nummer muss angegeben werden.")]
  public string? Nummer { get; set; } = default!;

  /// <summary>Holt oder setzt die Benutzer-ID.</summary>
  [Display(Name = "_Benutzer-ID", Description = "Die Benutzer-ID muss angegeben werden.")]
  [Required(ErrorMessage = "Die Benutzer-ID muss angegeben werden.")]
  public string? BenutzerId { get; set; } = default!;

  /// <summary>Holt oder setzt das Kennwort.</summary>
  [Display(Name = "_Kennwort", Description = "Das Kennwort kann angegeben werden, wenn es geändert werden soll.")]
  public string? Kennwort { get; set; } = default!;

  /// <summary>Holt oder setzt die Liste von Berechtigung.</summary>
  public List<ListItem>? AuswahlBerechtigung { get; set; }

  /// <summary>Holt oder setzt die Berechtigung.</summary>
  [Display(Name = "_Rolle", Description = "Die Rolle muss angegeben werden.")]
  [Required(ErrorMessage = "Die Rolle muss angegeben werden.")]
  public string? Berechtigung { get; set; } = default!;

  /// <summary>Holt oder setzt das Geburtsdatum.</summary>
  [Display(Name = "_Geburtsdatum", Description = "Das Geburtsdatum kann angegeben werden.")]
  //// [Required(ErrorMessage = "Das Geburtsdatum kann angegeben werden.")]
  public DateTime? Geburt { get; set; } = default!;

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
  public void From(AG200TableRowModel m) =>
   (Nummer, BenutzerId, Kennwort, Berechtigung, Geburt, Angelegt, Geaendert)
   = (Functions.ToString(m.Nummer), m.BenutzerId, "", m.Berechtigung, m.Geburt, ModelBase.FormatDateOf(m.AngelegtAm, m.AngelegtVon), ModelBase.FormatDateOf(m.GeaendertAm, m.GeaendertVon));

  /// <summary>Kopiert die Werte in ein Model.</summary>
  /// <returns>Das kopierte Model.</returns>
  /// <param name="mnr">Betroffene Mandantennummer.</param>
  public Benutzer To(int mnr) => new()
  {
    Mandant_Nr = mnr,
    Person_Nr = Functions.ToInt32(Nummer),
    Benutzer_ID = BenutzerId,
    Passwort = Kennwort,
    Berechtigung = Functions.ToInt32(Berechtigung),
    Geburt = Geburt,
  };

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  public void SetMhrf(DialogTypeEnum mode)
  {
    if (mode == New)
    {
      Nummer = "";
      BenutzerId = null;
      Kennwort = "";
      Berechtigung = "0";
      Geburt = null;
    }
    SetMandatoryHiddenReadonly(nameof(Nummer), mode == New, false, mode != New, mode == New);
    SetMandatoryHiddenReadonly(nameof(BenutzerId), true, false, mode == Delete, mode == Edit);
    SetMandatoryHiddenReadonly(nameof(Kennwort), mode == New, false, mode == Delete);
    SetMandatoryHiddenReadonly(nameof(Berechtigung), true, false, mode == Delete);
    SetMandatoryHiddenReadonly(nameof(Geburt), true, false, mode == Delete);
    SetMandatoryHiddenReadonly(nameof(Angelegt), false, mode == New, true);
    SetMandatoryHiddenReadonly(nameof(Geaendert), false, mode == New, true);
    SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, mode == Delete);
  }
}
