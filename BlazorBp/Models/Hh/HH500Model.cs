// <copyright file="HH500Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Hh;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das Formular HH500 Bilanzen.
/// </summary>
[Serializable]
public class HH500Model : PageModelBase
{
  /// <summary>Holt oder setzt Überschrift der Soll-Spalte.</summary>
  [Display(Name = "Aktiva", Description = "")]
  public string? Soll0 { get; set; }

  /// <summary>Holt oder setzt Überschrift der Haben-Spalte.</summary>
  [Display(Name = "Passiva", Description = "")]
  public string? Haben0 { get; set; }

  /// <summary>Holt oder setzt Von.</summary>
  [Display(Name = "_Von", Description = "")]
  //// [Required(ErrorMessage = "Von muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Von darf maximal {1} Zeichen lang sein.")]
  public string? Von { get; set; }

  /// <summary>Holt oder setzt Bis.</summary>
  [Display(Name = "_Bis", Description = "")]
  //// [Required(ErrorMessage = "Bis muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Bis darf maximal {1} Zeichen lang sein.")]
  public string? Bis { get; set; }

  /// <summary>Holt oder setzt Konto.</summary>
  [Display(Name = "Konto", Description = "")]
  //// [Required(ErrorMessage = "Konto muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Konto darf maximal {1} Zeichen lang sein.")]
  public string? Konto0 { get; set; }

  /// <summary>Holt oder setzt   ^  .</summary>
  [Display(Name = "  ^  ", Description = "Ausgewähltes Konto mit oberem tauschen")]
  //// [Required(ErrorMessage = "  ^   muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "  ^   darf maximal {1} Zeichen lang sein.")]
  public string? Oben { get; set; }

  /// <summary>Holt oder setzt   v  .</summary>
  [Display(Name = "  v  ", Description = "Ausgewähltes Konto mit unterem tauschen")]
  //// [Required(ErrorMessage = "  v   muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "  v   darf maximal {1} Zeichen lang sein.")]
  public string? Unten { get; set; }

  /// <summary>Holt oder setzt die Auswahlliste von Soll.</summary>
  public List<ListItem>? AuswahlSoll { get; set; } = default!;

  /// <summary>Holt oder setzt Soll.</summary>
  [Display(Name = "_Soll", Description = "Linke T-Konto-Seite")]
  public string? Soll { get; set; }

  /// <summary>Holt oder setzt die Auswahlliste von Haben.</summary>
  public List<ListItem>? AuswahlHaben { get; set; } = default!;

  /// <summary>Holt oder setzt Haben.</summary>
  [Display(Name = "_Haben", Description = "Rechte T-Konto-Seite")]
  public string? Haben { get; set; }

  /// <summary>Holt oder setzt Summe.</summary>
  [Display(Name = "Summe", Description = "")]
  public string? SollSumme0 { get; set; }

  /// <summary>Holt oder setzt </summary>
  [Display(Name = "", Description = "")]
  public string? SollBetrag0 { get; set; }

  /// <summary>Holt oder setzt Summe.</summary>
  [Display(Name = "Summe", Description = "")]
  public string? HabenSumme0 { get; set; }

  /// <summary>Holt oder setzt .</summary>
  [Display(Name = "", Description = "")]
  public string? HabenBetrag0 { get; set; }

  /// <summary>Holt oder setzt Drucken.</summary>
  [Display(Name = "Drucken", Description = "Drucken von Bilanzen")]
  public string? Print { get; set; }

  /// <summary>Holt oder setzt Bilanzen neu berechnen.</summary>
  [Display(Name = "Bilanzen neu berechnen", Description = "Bilanzen neu berechnen")]
  public string? Refresh { get; set; }

  /// <summary>Holt oder setzt Schließen.</summary>
  [Display(Name = "Schließen", Description = "Schließen")]
  public string? Schliessen { get; set; }

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  public void SetMhrf(DialogTypeEnum mode)
  {
    if (mode == New || mode == Copy)
    {
      // Nummer = "";
    }
    // TODO SetMandatoryHiddenReadonly(nameof(Nummer), true, false, true, false);
    // SetMandatoryHiddenReadonly(nameof(Thema), true, false, mode == Delete, mode == New);
    // SetMandatoryHiddenReadonly(nameof(Refresh), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Print), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Von), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Bis), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Konto0), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Oben), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Unten), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Soll), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Haben), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(SollSumme0), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(SollBetrag0), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(HabenSumme0), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(HabenBetrag0), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Schliessen), false, false, mode == Delete, false);

    // SetMandatoryHiddenReadonly(nameof(Angelegt), false, mode == New, true);
    // SetMandatoryHiddenReadonly(nameof(Geaendert), false, mode == New, true);
    // SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, mode == Delete);
  }
}
