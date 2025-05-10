// <copyright file="DM200Model.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models.Demo;

using System.ComponentModel.DataAnnotations;
using BlazorBp.Base;

/// <summary>
/// Model-Klasse für das Formular DM200 Tabelle.
/// </summary>
[Serializable]
public class DM200Model : PageModelBase
{
  /// <summary>Holt oder setzt die Test-TextBox.</summary>
  [Display(Name = "_TextBox", Description = "Test-TextBox")]
  [Required]
  public string? TextBox { get; set; } = default!;

  /// <summary>Holt oder setzt den Import-Button.</summary>
  [Display(Name = "_Import", Description = "CSV-Datei importieren.")]
  public string? Import { get; set; } = default!;

  /// <summary>Holt oder setzt den Schließen-Button.</summary>
  [Display(Name = "S_chließen", Description = "Formular schließen ohne Speichern.")]
  public string? Schliessen { get; set; } = default!;
}
