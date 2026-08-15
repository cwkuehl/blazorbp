// <copyright file="WP100Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Wp;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das Formular WP100 Point and Figure.
/// </summary>
[Serializable]
public class WP100Model : PageModelBase
{  /// <summary>Holt oder setzt Aktualisieren.</summary>
  [Display(Name = "Aktualisieren", Description = "Aktualisieren")]
  //// [Required(ErrorMessage = "Aktualisieren muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Aktualisieren darf maximal {1} Zeichen lang sein.")]
  public string? Refresh { get; set; }

  /// <summary>Holt oder setzt Daten.</summary>
  [Display(Name = "_Daten", Description = "")]
  public string? Data { get; set; }

  /// <summary>Holt oder setzt Chart.</summary>
  [Display(Name = "Chart", Description = "")]
  //// [Required(ErrorMessage = "Chart muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Chart darf maximal {1} Zeichen lang sein.")]
  public string? Chart { get; set; }

  /// <summary>Holt oder setzt Von.</summary>
  [Display(Name = "_Von", Description = "")]
  //// [Required(ErrorMessage = "Von muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Von darf maximal {1} Zeichen lang sein.")]
  public string? Von { get; set; }

  /// <summary>Holt oder setzt Bis.</summary>
  [Display(Name = "B_is", Description = "")]
  //// [Required(ErrorMessage = "Bis muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Bis darf maximal {1} Zeichen lang sein.")]
  public string? Bis { get; set; }

  /// <summary>Holt oder setzt die Auswahlliste von Wertpapieren.</summary>
  public List<ListItem>? AuswahlWertpapier { get; set; } = default!;

  /// <summary>Holt oder setzt Wertpapier.</summary>
  [Display(Name = "_Wertpapier", Description = "Wertpapier")]
  [Required(ErrorMessage = "Wertpapier muss angegeben werden.")]
  public string? Wertpapier { get; set; }

  /// <summary>Holt oder setzt Boxgröße.</summary>
  [Display(Name = "Bo_xgröße", Description = "Boxgröße absolut oder prozentual")]
  //// [Required(ErrorMessage = "Boxgröße muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Boxgröße darf maximal {1} Zeichen lang sein.")]
  public string? Box { get; set; }

  /// <summary>Holt oder setzt Skala.</summary>
  [Display(Name = "Skala", Description = "Zugrundeliegende Skala für die Boxgröße")]
  [Required(ErrorMessage = "Skala muss angegeben werden.")]
  public string? Skala { get; set; }

  /// <summary>Holt oder setzt Umkehr.</summary>
  [Display(Name = "_Umkehr", Description = "Anzahl der Boxen für Umkehr")]
  //// [Required(ErrorMessage = "Umkehr muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Umkehr darf maximal {1} Zeichen lang sein.")]
  public string? Umkehr { get; set; }

  /// <summary>Holt oder setzt Methode.</summary>
  [Display(Name = "_Methode", Description = "Methode für Kursberechnung")]
  //// [Required(ErrorMessage = "Methode muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Methode darf maximal {1} Zeichen lang sein.")]
  public string? Methode { get; set; }

  /// <summary>Holt oder setzt Relativ.</summary>
  [Display(Name = "_Relativ", Description = "Soll die Auswertung relativ zur Relation erfolgen?")]
  //// [Required(ErrorMessage = "Relativ muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Relativ darf maximal {1} Zeichen lang sein.")]
  public string? Relativ { get; set; }

  /// <summary>Holt oder setzt Schließen.</summary>
  [Display(Name = "Schließen", Description = "Schließen")]
  //// [Required(ErrorMessage = "Schließen muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Schließen darf maximal {1} Zeichen lang sein.")]
  public string? Schliessen { get; set; }

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
