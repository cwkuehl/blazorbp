// <copyright file="AM500Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Am;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;

/// <summary>
/// Model-Klasse für das Formular AM500 Einstellungen.
/// </summary>
[Serializable]
public class AM500Model : PageModelBase
{
  /// <summary>Holt oder setzt den Schließen-Button.</summary>
  [Display(Name = "S_chließen", Description = "Formular schließen ohne Speichern.")]
  public string? Schliessen { get; set; } = default!;
}
