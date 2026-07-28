// <copyright file="TableRowModelBase.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Base;

/// <summary>
/// Basis-Klasse für alle Zeilen-Details in Tabellen.
/// </summary>
[Serializable]
public class TableRowModelBase
{
  /// <summary>Holt oder setzt die ID.</summary>
  public virtual string? Id { get; set; } = default!;
}
