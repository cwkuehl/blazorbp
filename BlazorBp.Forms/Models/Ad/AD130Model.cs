// <copyright file="AD130Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Forms.Models.Ad;

using System.ComponentModel.DataAnnotations;
using BlazorSpa.Core.Base;
using BlazorSpa.Core.Models;
using static BlazorSpa.Core.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das Formular AD130 Adressen.
/// </summary>
[Serializable]
public class AD130Model : PageModelBase
{
  /// <summary>Holt oder setzt die Auswahlliste von Geburtstage.</summary>
  public List<ListItem>? AuswahlAdressen { get; set; } = default!;

  /// <summary>Holt oder setzt Adressen.</summary>
  [Display(Name = "_Adressen", Description = "Liste bestehender Adressen")]
  [Required(ErrorMessage = "Eine Adresse muss ausgewählt werden.")]
  public string? Adressen { get; set; }

  /// <summary>Holt oder setzt OK.</summary>
  [Display(Name = "_OK", Description = "Dialog mit Speichern schließen")]
  public string? Ok { get; set; }

  /// <summary>Holt oder setzt Abbrechen.</summary>
  [Display(Name = "Abbre_chen", Description = "Dialog ohne Speichern schließen")]
  public string? Abbrechen { get; set; }

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  public void SetMhrf(DialogTypeEnum mode)
  {
    if (mode == New)
    {
      // Thema = null;
    }
    SetMandatoryHiddenReadonly(nameof(Adressen), false, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Ok), false, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Abbrechen), false, false, false, false);
  }
}
