// <copyright file="WP250Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Wp;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das Formular WP250 Anlagen.
/// </summary>
[Serializable]
public class WP250Model : PageModelBase
{
  /// <summary>Holt oder setzt Aktualisieren.</summary>
  [Display(Name = "Aktualisieren", Description = "Aktualisieren")]
  //// [Required(ErrorMessage = "Aktualisieren muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Aktualisieren darf maximal {1} Zeichen lang sein.")]
  public string? Refresh { get; set; }

  /// <summary>Holt oder setzt Chart oder Karte.</summary>
  [Display(Name = "Chart oder Karte", Description = "Chart oder Karte")]
  //// [Required(ErrorMessage = "Chart oder Karte muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Chart oder Karte darf maximal {1} Zeichen lang sein.")]
  public string? Chart { get; set; }

  /// <summary>Holt oder setzt Details.</summary>
  [Display(Name = "Details", Description = "Details")]
  //// [Required(ErrorMessage = "Details muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Details darf maximal {1} Zeichen lang sein.")]
  public string? Details { get; set; }

  /// <summary>Holt oder setzt Anlagen.</summary>
  [Display(Name = "_Anlagen", Description = "Wertpapier-Anlagen")]
  //// [Required(ErrorMessage = "Anlagen muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Anlagen darf maximal {1} Zeichen lang sein.")]
  public string? Anlagen { get; set; }

  /// <summary>Holt oder setzt Status.</summary>
  [Display(Name = "Status", Description = "")]
  //// [Required(ErrorMessage = "Status muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Status darf maximal {1} Zeichen lang sein.")]
  public string? AnlagenStatus { get; set; }

  /// <summary>Holt oder setzt Alle.</summary>
  [Display(Name = "A_lle", Description = "Selektionskriterien zurücksetzen")]
  //// [Required(ErrorMessage = "Alle muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Alle darf maximal {1} Zeichen lang sein.")]
  public string? Alle { get; set; }

  /// <summary>Holt oder setzt Suche.</summary>
  [Display(Name = "_Suche", Description = "Suche in allen Textfeldern")]
  //// [Required(ErrorMessage = "Suche muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Suche darf maximal {1} Zeichen lang sein.")]
  public string? Bezeichnung { get; set; }

  /// <summary>Holt oder setzt Wertpapier.</summary>
  [Display(Name = "_Wertpapier", Description = "Zu suchendes Wertpapier")]
  //// [Required(ErrorMessage = "Wertpapier muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Wertpapier darf maximal {1} Zeichen lang sein.")]
  public string? Wertpapier { get; set; }

  /// <summary>Holt oder setzt auch inaktive.</summary>
  [Display(Name = "auch inaktive", Description = "Sollen auch inaktive Anlagen angezeigt werden?")]
  //// [Required(ErrorMessage = "auch inaktive muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "auch inaktive darf maximal {1} Zeichen lang sein.")]
  public bool Auchinaktiv { get; set; }

  /// <summary>Holt oder setzt Bewertungen berechnen.</summary>
  [Display(Name = "Bewertungen berechnen", Description = "Soll die Bewertung für jedes aktive Wertpapier berechnet werden?")]
  //// [Required(ErrorMessage = "Bewertungen berechnen muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Bewertungen berechnen darf maximal {1} Zeichen lang sein.")]
  public string? Berechnen { get; set; }

  /// <summary>Holt oder setzt Bis.</summary>
  [Display(Name = "B_is", Description = "")]
  //// [Required(ErrorMessage = "Bis muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Bis darf maximal {1} Zeichen lang sein.")]
  public string? Bis { get; set; }

  /// <summary>Holt oder setzt Abbrechen.</summary>
  [Display(Name = "Abbre_chen", Description = "Berechnung abbrechen")]
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
    // SetMandatoryHiddenReadonly(nameof(Angelegt), false, mode == New, true);
    // SetMandatoryHiddenReadonly(nameof(Geaendert), false, mode == New, true);
    // SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, mode == Delete);
  }
}
