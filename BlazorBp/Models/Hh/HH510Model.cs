// <copyright file="HH510Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Hh;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das Formular HH510 Drucken.
/// </summary>
[Serializable]
public class HH510Model : PageModelBase
{
  /// <summary>Holt oder setzt Titel.</summary>
  [Display(Name = "_Titel", Description = "Berichtstitel")]
  [Required(ErrorMessage = "Titel muss angegeben werden.")]
  [MaxLength(255, ErrorMessage = "Titel darf maximal {1} Zeichen lang sein.")]
  public string? Titel { get; set; }

  /// <summary>Holt oder setzt Zeitraum von.</summary>
  [Display(Name = "Zeitraum _von", Description = "")]
  //// [Required(ErrorMessage = "Zeitraum von muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Zeitraum von darf maximal {1} Zeichen lang sein.")]
  public DateTime? Von { get; set; }

  /// <summary>Holt oder setzt Bis.</summary>
  [Display(Name = "_Bis", Description = "")]
  //// [Required(ErrorMessage = "Bis muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Bis darf maximal {1} Zeichen lang sein.")]
  public DateTime? Bis { get; set; }

  /// <summary>Holt oder setzt Berichte.</summary>
  [Display(Name = "Berichte", Description = "")]
  //// [Required(ErrorMessage = "Berichte muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Berichte darf maximal {1} Zeichen lang sein.")]
  public string? Berichte0 { get; set; }

  /// <summary>Holt oder setzt Eröffnungsbilanz.</summary>
  [Display(Name = "Eröffnungsbilanz", Description = "Eröffnungsbilanz")]
  //// [Required(ErrorMessage = "Eröffnungsbilanz muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Eröffnungsbilanz darf maximal {1} Zeichen lang sein.")]
  public string? Eb { get; set; }

  /// <summary>Holt oder setzt Gewinn+Verlust-Rechnung.</summary>
  [Display(Name = "Gewinn+Verlust-Rechnung", Description = "Gewinn+Verlust-Rechnung")]
  //// [Required(ErrorMessage = "Gewinn+Verlust-Rechnung muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Gewinn+Verlust-Rechnung darf maximal {1} Zeichen lang sein.")]
  public string? Gv { get; set; }

  /// <summary>Holt oder setzt Schlussbilanz.</summary>
  [Display(Name = "Schlussbilanz", Description = "Schlussbilanz")]
  //// [Required(ErrorMessage = "Schlussbilanz muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Schlussbilanz darf maximal {1} Zeichen lang sein.")]
  public string? Sb { get; set; }

  /// <summary>Holt oder setzt Kassenbericht.</summary>
  [Display(Name = "Kassenbericht", Description = "Kassenbericht")]
  //// [Required(ErrorMessage = "Kassenbericht muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Kassenbericht darf maximal {1} Zeichen lang sein.")]
  public string? Kassenbericht { get; set; }

  /// <summary>Holt oder setzt OK.</summary>
  [Display(Name = "_OK", Description = "Ausgewählte Berichte erstellen")]
  public string? Ok { get; set; }

  /// <summary>Holt oder setzt Abbrechen.</summary>
  [Display(Name = "Abbre_chen", Description = "Dialog ohne Speichern schließen")]
  public string? Abbrechen { get; set; }

  /// <summary>Holt oder setzt Vorhandene Daten löschen.</summary>
  [Display(Name = "Vorhandene Daten löschen", Description = "Vorhandene Daten beim Import löschen")]
  public bool Loeschen { get; set; }

  /// <summary>Holt oder setzt Import Buchungen.</summary>
  [Display(Name = "_Import Buchungen", Description = "Import von Buchungen aus einer Datei")]
  public string? Import1 { get; set; }

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  public void SetMhrf(DialogTypeEnum mode)
  {
    if (mode == New || mode == Copy)
    {
      // TODO Nummer = "";
    }
    // TODO SetMandatoryHiddenReadonly(nameof(Nummer), true, false, true, false);
    // SetMandatoryHiddenReadonly(nameof(Thema), true, false, mode == Delete, mode == New);
    // SetMandatoryHiddenReadonly(nameof(Titel), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Von), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Bis), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Berichte0), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Eb), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Gv), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Sb), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Kassenbericht), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Ok), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Abbrechen), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Datei), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(DateiAuswahl), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Loeschen), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Import1), false, false, mode == Delete, false);

    // SetMandatoryHiddenReadonly(nameof(Angelegt), false, mode == New, true);
    // SetMandatoryHiddenReadonly(nameof(Geaendert), false, mode == New, true);
    // SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, mode == Delete);
  }
}
