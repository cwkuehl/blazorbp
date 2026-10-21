// <copyright file="Column.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorSpa.Core.Base;

using System.Reflection;

/// <summary>
/// Record für Spalten-Eigenschaften.
/// </summary>
//// public record Column(string Name, string SortName, string Label, string Title, string SortTitle, PropertyInfo Pi, bool Visible);
public record Column
{
  /// <summary>
  /// Initializes a new instance of the <see cref="Column"/> class.
  /// Record für Spalten-Eigenschaften.
  /// </summary>
  /// <param name="name">Name der Model-Spalte.</param>
  /// <param name="sortName">Name der Datenbank-Spalte zur Sortierung.</param>
  /// <param name="label">Angezeigte Bezeichnung der Spalte.</param>
  /// <param name="title">Tooltip des Wertes wird nicht verwendet.</param>
  /// <param name="sortTitle">Tooltip auf Sortier-Schaltfläche.</param>
  /// <param name="pi">Betroffene PropertyInfo im Model.</param>
  /// <param name="visible">Sichbarkeit der Spalte.</param>
  /// <param name="right">Rechte Ausrichtung der Spalte.</param>
  public Column(string name, string sortName, string label, string title, string sortTitle, PropertyInfo pi, bool visible, bool right)
  {
    Name = name;
    SortName = sortName;
    Label = label;
    Title = title;
    SortTitle = sortTitle;
    Pi = pi;
    Visible = visible;
    Right = right;
  }

  /// <summary>Holt oder setzt den Namen der Model-Spalte.</summary>
  public string Name { get; init; }

  /// <summary>Holt oder setzt den Namen der Datenbank-Spalte zur Sortierung.</summary>
  public string SortName { get; init; }

  /// <summary>Holt oder setzt die angezeigte Bezeichnung der Spalte.</summary>
  public string Label { get; init; }

  /// <summary>Holt oder setzt den Tooltip des Wertes (wird nicht verwendet).</summary>
  public string Title { get; init; }

  /// <summary>Holt oder setzt den Namen der Model-Spalte.</summary>
  public string SortTitle { get; init; }

  /// <summary>Holt oder setzt die PropertyInfo im Model.</summary>
  public PropertyInfo Pi { get; init; }

  /// <summary>Holt oder setzt die Sichtbarkeit der Spalte.</summary>
  public bool Visible { get; set; }

  /// <summary>Holt oder setzt die rechte Ausrichtung der Spalte.</summary>
  public bool Right { get; set; }
}
