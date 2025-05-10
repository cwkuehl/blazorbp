// <copyright file="AG200TableRowModel.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Ag;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;

/// <summary>
/// Model-Klasse für eine Zeile in der Tabelle von Formular AG200 Benutzer.
/// </summary>
[Serializable]
public class AG200TableRowModel : TableRowModelBase
{
  /// <summary>Holt oder setzt die Nummer.</summary>
  [Display(Name = "_Nr.", Description = "Die Nummer des Mandanten kann nicht geändert werden.")]
  public int Nummer { get; set; } = default!;

  /// <summary>Holt oder setzt die Benutzer-ID.</summary>
  [Display(Name = "_Benutzer-ID", Description = "Die Benutzer-ID muss angegeben werden.")]
  [Required(ErrorMessage = "Die Benutzer-ID muss angegeben werden.")]
  public string? BenutzerId { get; set; } = default!;

  /// <summary>Holt oder setzt das Kennwort.</summary>
  [Display(Name = "_Kennwort", Description = "Das Kennwort kann angegeben werden, wenn es geändert werden soll.")]
  public string? Kennwort { get; set; } = default!;

  /// <summary>Holt oder setzt die Berechtigung.</summary>
  [Display(Name = "_Rolle", Description = "Die Rolle muss angegeben werden.")]
  [Required(ErrorMessage = "Die Rolle muss angegeben werden.")]
  public string? Berechtigung { get; set; } = default!;

  /// <summary>Holt oder setzt das Geburtsdatum.</summary>
  [Display(Name = "_Geburtsdatum", Description = "Das Geburtsdatum kann angegeben werden.")]
  //// [Required(ErrorMessage = "Das Geburtsdatum kann angegeben werden.")]
  public DateTime? Geburt { get; set; } = default!;

  /// <summary>Holt oder setzt den Zeitpunkt der Anlage.</summary>
  [Display(Name = "Angelegt am", Description = "Der Zeitpunkt der Anlage.")]
  public DateTime? AngelegtAm { get; set; }

  /// <summary>Holt oder setzt die Benutzer-ID der Anlage.</summary>
  [Display(Name = "Angelegt von", Description = "Die Benutzer-ID der Anlage.")]
  public string? AngelegtVon { get; set; } = default!;

  /// <summary>Holt oder setzt den Zeitpunkt der letzten Änderung.</summary>
  [Display(Name = "Geändert am", Description = "Der Zeitpunkt der letzten Änderung.")]
  public DateTime? GeaendertAm { get; set; }

  /// <summary>Holt oder setzt die Benutzer-ID der letzten Änderung.</summary>
  [Display(Name = "Geändert von", Description = "Die Benutzer-ID der letzten Änderung.")]
  public string? GeaendertVon { get; set; }

  /// <summary>Kopiert die Werte in ein Model.</summary>
  /// <param name="mnr">Betroffene Mandantennummer.</param>
  public Benutzer To(int mnr)
  {
    return new Benutzer
    {
      Mandant_Nr = mnr,
      Person_Nr = Nummer,
      Benutzer_ID = BenutzerId,
      Passwort = "",
      Berechtigung = Functions.ToInt32(Berechtigung),
      Geburt = Geburt,
      Angelegt_Am = AngelegtAm,
      Angelegt_Von = AngelegtVon,
      Geaendert_Am = GeaendertAm,
      Geaendert_Von = GeaendertVon,
    };
  }

  /// <summary>Kopiert die Werte aus einem Model.</summary>
  /// <param name="m">Zu kopierendes Model.</param>
  public static AG200TableRowModel From(Benutzer m)
  {
    return new AG200TableRowModel
    {
      Nummer = m.Person_Nr,
      BenutzerId = m.Benutzer_ID,
      Kennwort = "••••••",
      Berechtigung = Functions.ToString(m.Berechtigung),
      Geburt = m.Geburt,
      AngelegtAm = m.Angelegt_Am,
      AngelegtVon = m.Angelegt_Von,
      GeaendertAm = m.Geaendert_Am,
      GeaendertVon = m.Geaendert_Von,
    };
  }
}
