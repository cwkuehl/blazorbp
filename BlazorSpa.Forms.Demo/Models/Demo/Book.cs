// <copyright file="Book.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorSpa.Forms.Demo.Models.Demo;

/// <summary>Model-Klasse für Bücher.</summary>
public class Book
{
  /// <summary>Holt oder setzt die ID des Buches.</summary>
  public int Id { get; set; }

  /// <summary>Holt oder setzt den Autor des Buches.</summary>
  public string? Author { get; set; }

  /// <summary>Holt oder setzt den Titel des Buches.</summary>
  public string? Title { get; set; }

  /// <summary>Holt oder setzt die Anzahl der Seiten des Buches.</summary>
  public int Pages { get; set; }
}
