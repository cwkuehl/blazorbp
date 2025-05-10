// <copyright file="Book.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Services.Models;

/// <summary>Model-Klasse für Bücher.</summary>
public class Book
{
  public int Id { get; set; }
  public string? Author { get; set; }
  public string? Title { get; set; }
  public int Pages { get; set; }
}
