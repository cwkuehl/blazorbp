// <copyright file="Objekt.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorSpa.Forms.Demo.Models.Demo;

/// <summary>Model-Klasse für Objekte.</summary>
public class Objekt
{
  /// <summary>Holt oder setzt die ID des Objektes.</summary>
  public int Id { get; set; }

  /// <summary>Holt oder setzt den Namen des Objektes.</summary>
  public string? Name { get; set; }

  /// <summary>Holt oder setzt die Beschreibung des Objektes.</summary>
  public string? Description { get; set; }
}
