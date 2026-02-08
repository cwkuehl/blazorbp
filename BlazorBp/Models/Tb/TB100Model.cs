// <copyright file="TB100Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Tb;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das Formular TB100 Tagebuch.
/// </summary>
[Serializable]
public class TB100Model : PageModelBase
{
  /// <summary>Holt oder setzt Einfügen.</summary>
  [Display(Name = "Einfügen", Description = "Einfügen")]
  public string? Paste { get; set; }

  /// <summary>Holt oder setzt Wetter.</summary>
  [Display(Name = "Wetter", Description = "Wetter")]
  public string? Weather { get; set; }

  /// <summary>Holt oder setzt Download.</summary>
  [Display(Name = "Download", Description = "Download")]
  public string? Download { get; set; }

  /// <summary>Holt oder setzt 1 Tag vorher.</summary>
  [Display(Name = "1 Tag vorher", Description = "")]
  //// [Required(ErrorMessage = "1 Tag vorher muss angegeben werden.")]
  public string? Before1 { get; set; }

  /// <summary>Holt oder setzt 1 Monat vorher.</summary>
  [Display(Name = "1 Monat vorher", Description = "")]
  //// [Required(ErrorMessage = "1 Monat vorher muss angegeben werden.")]
  public string? Before2 { get; set; }

  /// <summary>Holt oder setzt 1 Jahr vorher.</summary>
  [Display(Name = "1 Jahr vorher", Description = "")]
  //// [Required(ErrorMessage = "1 Jahr vorher muss angegeben werden.")]
  public string? Before3 { get; set; }

  /// <summary>Holt oder setzt Datum.</summary>
  [Display(Name = "_Datum", Description = "")]
  //// [Required(ErrorMessage = "Datum muss angegeben werden.")]
  public string? Date { get; set; }

  /// <summary>Holt oder setzt Positionen.</summary>
  [Display(Name = "Positionen", Description = "")]
  //// [Required(ErrorMessage = "Positionen muss angegeben werden.")]
  public string? Positions { get; set; }

  /// <summary>Holt oder setzt TB100.new.</summary>
  [Display(Name = "TB100.new", Description = "")]
  //// [Required(ErrorMessage = "TB100.new muss angegeben werden.")]
  public string? New { get; set; }

  /// <summary>Holt oder setzt TB100.remove.</summary>
  [Display(Name = "TB100.remove", Description = "")]
  //// [Required(ErrorMessage = "TB100.remove muss angegeben werden.")]
  public string? Remove { get; set; }

  /// <summary>Holt oder setzt Position.</summary>
  [Display(Name = "Position", Description = "")]
  //// [Required(ErrorMessage = "Position muss angegeben werden.")]
  public string? Position { get; set; }

  /// <summary>Holt oder setzt TB100.add.</summary>
  [Display(Name = "TB100.add", Description = "")]
  //// [Required(ErrorMessage = "TB100.add muss angegeben werden.")]
  public string? Add { get; set; }

  /// <summary>Holt oder setzt Angelegt.</summary>
  [Display(Name = "Angelegt", Description = "")]
  //// [Required(ErrorMessage = "Angelegt muss angegeben werden.")]
  public string? Angelegt { get; set; }

  /// <summary>Holt oder setzt Geändert.</summary>
  [Display(Name = "Geändert", Description = "")]
  //// [Required(ErrorMessage = "Geändert muss angegeben werden.")]
  public string? Geaendert { get; set; }

  /// <summary>Holt oder setzt P. Vortag.</summary>
  [Display(Name = "P. Vortag", Description = "")]
  //// [Required(ErrorMessage = "P. Vortag muss angegeben werden.")]
  public string? Posbefore { get; set; }

  /// <summary>Holt oder setzt TB100.search.</summary>
  [Display(Name = "TB100.search", Description = "")]
  //// [Required(ErrorMessage = "TB100.search muss angegeben werden.")]
  public string? Search { get; set; }

  /// <summary>Holt oder setzt Eintrag.</summary>
  [Display(Name = "Ein_trag", Description = "")]
  //// [Required(ErrorMessage = "Eintrag muss angegeben werden.")]
  public string? Entry { get; set; }

  /// <summary>Holt oder setzt Suche (Platzhalter % und ; Reihenfolge-Prüfung ####).</summary>
  [Display(Name = "_Suche (Platzhalter % und __; Reihenfolge-Prüfung ####)", Description = "")]
  //// [Required(ErrorMessage = "Suche (Platzhalter % und ; Reihenfolge-Prüfung ####) muss angegeben werden.")]
  public string? Search00 { get; set; }

  /// <summary>Holt oder setzt (.</summary>
  [Display(Name = "(", Description = "")]
  //// [Required(ErrorMessage = "( muss angegeben werden.")]
  public string? Search1 { get; set; }

  /// <summary>Holt oder setzt  oder .</summary>
  [Display(Name = " oder ", Description = "")]
  //// [Required(ErrorMessage = " oder  muss angegeben werden.")]
  public string? Search2 { get; set; }

  /// <summary>Holt oder setzt  oder .</summary>
  [Display(Name = " oder ", Description = "")]
  //// [Required(ErrorMessage = " oder  muss angegeben werden.")]
  public string? Search3 { get; set; }

  /// <summary>Holt oder setzt ).</summary>
  [Display(Name = ")", Description = "")]
  //// [Required(ErrorMessage = ") muss angegeben werden.")]
  public string? Search4 { get; set; }

  /// <summary>Holt oder setzt  und (.</summary>
  [Display(Name = " und (", Description = "")]
  //// [Required(ErrorMessage = " und ( muss angegeben werden.")]
  public string? Search5 { get; set; }

  /// <summary>Holt oder setzt  oder .</summary>
  [Display(Name = " oder ", Description = "")]
  //// [Required(ErrorMessage = " oder  muss angegeben werden.")]
  public string? Search6 { get; set; }

  /// <summary>Holt oder setzt  oder .</summary>
  [Display(Name = " oder ", Description = "")]
  //// [Required(ErrorMessage = " oder  muss angegeben werden.")]
  public string? Search7 { get; set; }

  /// <summary>Holt oder setzt  oder .</summary>
  [Display(Name = " oder ", Description = "")]
  //// [Required(ErrorMessage = " oder  muss angegeben werden.")]
  public string? Search100 { get; set; }

  /// <summary>Holt oder setzt ).</summary>
  [Display(Name = ")", Description = "")]
  //// [Required(ErrorMessage = ") muss angegeben werden.")]
  public string? Search8 { get; set; }

  /// <summary>Holt oder setzt  oder .</summary>
  [Display(Name = " oder ", Description = "")]
  //// [Required(ErrorMessage = " oder  muss angegeben werden.")]
  public string? Search110 { get; set; }

  /// <summary>Holt oder setzt  und nicht (.</summary>
  [Display(Name = " und nicht (", Description = "")]
  //// [Required(ErrorMessage = " und nicht ( muss angegeben werden.")]
  public string? Search9 { get; set; }

  /// <summary>Holt oder setzt ).</summary>
  [Display(Name = ")", Description = "")]
  //// [Required(ErrorMessage = ") muss angegeben werden.")]
  public string? Search120 { get; set; }

  /// <summary>Holt oder setzt TB100.clear.</summary>
  [Display(Name = "TB100.clear", Description = "")]
  //// [Required(ErrorMessage = "TB100.clear muss angegeben werden.")]
  public string? Clear { get; set; }

  /// <summary>Holt oder setzt Position.</summary>
  [Display(Name = "Position", Description = "")]
  //// [Required(ErrorMessage = "Position muss angegeben werden.")]
  public string? Position2 { get; set; }

  /// <summary>Holt oder setzt Von.</summary>
  [Display(Name = "Von", Description = "")]
  //// [Required(ErrorMessage = "Von muss angegeben werden.")]
  public string? From { get; set; }

  /// <summary>Holt oder setzt Bis.</summary>
  [Display(Name = "Bis", Description = "")]
  //// [Required(ErrorMessage = "Bis muss angegeben werden.")]
  public string? To { get; set; }

  /// <summary>Holt oder setzt TB100.first.</summary>
  [Display(Name = "TB100.first", Description = "")]
  //// [Required(ErrorMessage = "TB100.first muss angegeben werden.")]
  public string? First { get; set; }

  /// <summary>Holt oder setzt TB100.back.</summary>
  [Display(Name = "TB100.back", Description = "")]
  //// [Required(ErrorMessage = "TB100.back muss angegeben werden.")]
  public string? Back { get; set; }

  /// <summary>Holt oder setzt TB100.forward.</summary>
  [Display(Name = "TB100.forward", Description = "")]
  //// [Required(ErrorMessage = "TB100.forward muss angegeben werden.")]
  public string? Forward { get; set; }

  /// <summary>Holt oder setzt TB100.last.</summary>
  [Display(Name = "TB100.last", Description = "")]
  //// [Required(ErrorMessage = "TB100.last muss angegeben werden.")]
  public string? Last { get; set; }

  /// <summary>Holt oder setzt TB100.save.</summary>
  [Display(Name = "TB100.save", Description = "")]
  //// [Required(ErrorMessage = "TB100.save muss angegeben werden.")]
  public string? Save { get; set; }

  /// <summary>Holt oder setzt 1 Tag danach.</summary>
  [Display(Name = "1 Tag danach", Description = "")]
  //// [Required(ErrorMessage = "1 Tag danach muss angegeben werden.")]
  public string? After1 { get; set; }

  /// <summary>Holt oder setzt 1 Monat danach.</summary>
  [Display(Name = "1 Monat danach", Description = "")]
  //// [Required(ErrorMessage = "1 Monat danach muss angegeben werden.")]
  public string? After2 { get; set; }

  /// <summary>Holt oder setzt 1 Jahr danach.</summary>
  [Display(Name = "1 Jahr danach", Description = "")]
  //// [Required(ErrorMessage = "1 Jahr danach muss angegeben werden.")]
  public string? After3 { get; set; }

  /// <summary>Holt oder setzt Schließen.</summary>
  [Display(Name = "Schließen", Description = "Schließen")]
  //// [Required(ErrorMessage = "Schließen muss angegeben werden.")]
  public string? Schliessen { get; set; }

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  public void SetMhrf(DialogTypeEnum mode)
  {
    if (mode == DialogTypeEnum.New || mode == Copy)
    {
      // TODO Nummer = "";
    }
    if (mode == DialogTypeEnum.New)
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
