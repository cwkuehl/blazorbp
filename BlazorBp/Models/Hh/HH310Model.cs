// <copyright file="HH310Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Hh;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das nicht modale Formular HH310 Ereignisse.
/// </summary>
[Serializable]
public class HH310Model : PageModelBase
{
  /// <summary>Holt oder setzt Nr..</summary>
  [Display(Name = "Nr.", Description = "Ereignis-Nr.")]
  //// [Required(ErrorMessage = "Nr. muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Nr. darf maximal {1} Zeichen lang sein.")]
  public string? Nummer { get; set; }

  /// <summary>Holt oder setzt Bezeichnung.</summary>
  [Display(Name = "_Bezeichnung", Description = "Bezeichnung")]
  //// [Required(ErrorMessage = "Bezeichnung muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Bezeichnung darf maximal {1} Zeichen lang sein.")]
  public string? Bezeichnung { get; set; }

  /// <summary>Holt oder setzt Kennzeichen.</summary>
  [Display(Name = "_Kennzeichen", Description = "Kennzeichen")]
  //// [Required(ErrorMessage = "Kennzeichen muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Kennzeichen darf maximal {1} Zeichen lang sein.")]
  public string? Kennzeichen { get; set; }

  /// <summary>Holt oder setzt Buchungstext.</summary>
  [Display(Name = "Buchungste_xt", Description = "Buchungstext")]
  //// [Required(ErrorMessage = "Buchungstext muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Buchungstext darf maximal {1} Zeichen lang sein.")]
  public string? EText { get; set; }

  /// <summary>Holt oder setzt Sollkonto.</summary>
  [Display(Name = "_Sollkonto", Description = "Sollkonto")]
  //// [Required(ErrorMessage = "Sollkonto muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Sollkonto darf maximal {1} Zeichen lang sein.")]
  public string? Sollkonto { get; set; }

  /// <summary>Holt oder setzt Habenkonto.</summary>
  [Display(Name = "_Habenkonto", Description = "Habenkonto")]
  //// [Required(ErrorMessage = "Habenkonto muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Habenkonto darf maximal {1} Zeichen lang sein.")]
  public string? Habenkonto { get; set; }

  /// <summary>Holt oder setzt Angelegt.</summary>
  [Display(Name = "Angelegt", Description = "Datum, Uhrzeit und Benutzer, der die Daten angelegt hat")]
  //// [Required(ErrorMessage = "Angelegt muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Angelegt darf maximal {1} Zeichen lang sein.")]
  public string? Angelegt { get; set; }

  /// <summary>Holt oder setzt Geändert.</summary>
  [Display(Name = "Geändert", Description = "Datum, Uhrzeit und Benutzer, der die Daten geändert hat")]
  //// [Required(ErrorMessage = "Geändert muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Geändert darf maximal {1} Zeichen lang sein.")]
  public string? Geaendert { get; set; }

  /// <summary>Holt oder setzt OK.</summary>
  [Display(Name = "_OK", Description = "Dialog mit Speichern schließen")]
  //// [Required(ErrorMessage = "OK muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "OK darf maximal {1} Zeichen lang sein.")]
  public string? Ok { get; set; }

  /// <summary>Holt oder setzt Kontentausch.</summary>
  [Display(Name = "Kon_tentausch", Description = "Kontentausch")]
  //// [Required(ErrorMessage = "Kontentausch muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Kontentausch darf maximal {1} Zeichen lang sein.")]
  public string? Kontentausch { get; set; }

  /// <summary>Holt oder setzt Abbrechen.</summary>
  [Display(Name = "Abbre_chen", Description = "Dialog ohne Speichern schließen")]
  //// [Required(ErrorMessage = "Abbrechen muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Abbrechen darf maximal {1} Zeichen lang sein.")]
  public string? Abbrechen { get; set; }

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
    // SetMandatoryHiddenReadonly(nameof(Nummer), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Bezeichnung), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Kennzeichen), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(EText), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Sollkonto), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Habenkonto), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Angelegt), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Geaendert), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Kontentausch), false, false, false, false);
    // SetMandatoryHiddenReadonly(nameof(Abbrechen), false, false, false, false)
    // SetMandatoryHiddenReadonly(nameof(Angelegt), false, mode == New, true);
    // SetMandatoryHiddenReadonly(nameof(Geaendert), false, mode == New, true);
    // SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, mode == Delete);
  }
}
