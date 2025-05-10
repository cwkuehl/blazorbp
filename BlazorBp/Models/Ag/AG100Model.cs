// <copyright file="AG100Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Ag;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;

/// <summary>
/// Model-Klasse für das Formular AG100 Mandanten.
/// </summary>
[Serializable]
public class AG100Model : PageModelBase
{
  /// <summary>Holt oder setzt den Schließen-Button.</summary>
  [Display(Name = "S_chließen", Description = "Formular schließen ohne Speichern.")]
  public string? Schliessen { get; set; } = default!;
}
