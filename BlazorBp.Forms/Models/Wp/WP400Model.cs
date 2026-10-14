// <copyright file="WP400Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Forms.Models.Wp;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Core.Base;
using CSBP.Services.Apis.Models;
using CSBP.Services.Base;
using static BlazorBp.Core.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das Formular WP400 WP-Buchungen.
/// </summary>
[Serializable]
public class WP400Model : PageModelBase
{
  /// <summary>Holt oder setzt Aktualisieren.</summary>
  [Display(Name = "Aktualisieren", Description = "Aktualisieren")]
  //// [Required(ErrorMessage = "Aktualisieren muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Aktualisieren darf maximal {1} Zeichen lang sein.")]
  public string? Refresh { get; set; }

  /// <summary>Holt oder setzt Buchungen.</summary>
  [Display(Name = "_Buchungen", Description = "Buchungen")]
  //// [Required(ErrorMessage = "Buchungen muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Buchungen darf maximal {1} Zeichen lang sein.")]
  public string? Buchungen { get; set; }

  /// <summary>Holt oder setzt Alle.</summary>
  [Display(Name = "A_lle", Description = "Selektionskriterien zurücksetzen")]
  //// [Required(ErrorMessage = "Alle muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Alle darf maximal {1} Zeichen lang sein.")]
  public string? Alle { get; set; }

  /// <summary>Holt oder setzt Buchungstext.</summary>
  [Display(Name = "_Buchungstext", Description = "_Buchungstext")]
  //// [Required(ErrorMessage = "Buchungstext muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Buchungstext darf maximal {1} Zeichen lang sein.")]
  public string? Bezeichnung { get; set; }

  /// <summary>Holt oder setzt Anlage.</summary>
  [Display(Name = "_Anlage", Description = "Zu suchende Anlage")]
  //// [Required(ErrorMessage = "Anlage muss angegeben werden.")]
  //// [MaxLength(255, ErrorMessage = "Anlage darf maximal {1} Zeichen lang sein.")]
  public string? Anlage { get; set; }

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
    // SetMandatoryHiddenReadonly(nameof(Refresh), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Buchungen), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Alle), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Bezeichnung), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Anlage), false, false, mode == Delete, false);
    // SetMandatoryHiddenReadonly(nameof(Schliessen), false, false, mode == Delete, false);

    // SetMandatoryHiddenReadonly(nameof(Angelegt), false, mode == New, true);
    // SetMandatoryHiddenReadonly(nameof(Geaendert), false, mode == New, true);
    // SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, mode == Delete);
  }
}
