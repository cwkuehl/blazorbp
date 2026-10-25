// <copyright file="FZ700Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Forms.Models.Fz;

using System.ComponentModel.DataAnnotations;
using BlazorSpa.Core.Base;
using static BlazorSpa.Core.Base.DialogTypeEnum;

/// <summary>
/// Model-Klasse für das Formular FZ700 Notizen.
/// </summary>
[Serializable]
public class FZ700Model : PageModelBase
{
  /// <summary>Holt oder setzt Aktualisieren.</summary>
  [Display(Name = "Aktualisieren", Description = "Aktualisieren")]
  public string? Refresh { get; set; }

  /// <summary>Holt oder setzt Schließen.</summary>
  [Display(Name = "Schließen", Description = "Schließen")]
  public string? Schliessen { get; set; }

  /// <summary>Setzt die Werte und Modi für das Model.</summary>
  /// <param name="mode">Betroffener Modus.</param>
  public void SetMhrf(DialogTypeEnum mode)
  {
    if (mode == New)
    {
      // Nummer = null;
    }
    SetMandatoryHiddenReadonly(nameof(Refresh), false, false, false, false);
    SetMandatoryHiddenReadonly(nameof(Schliessen), false, false, false, false);
  }
}
