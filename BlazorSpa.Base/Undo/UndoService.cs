// <copyright file="UndoService.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorSpa.Base.Undo;

using BlazorSpa.Base.Models;

/// <summary>
/// Klasse für die Basis-Undo/Redo-Funktionen.
/// </summary>
public class UndoService : IUndoService
{
  /// <summary>
  /// Letztes Kommando rückgängig machen.
  /// </summary>
  /// <param name="ud">Betroffene Benutzerdaten.</param>
  /// <returns>True, wenn es ein letztes Kommando gab, das erfolgreich rückgängig gemacht werden konnte, sonst false.</returns>
  public bool Undo(UserDaten ud)
  {
    // Implementation for undoing the last command.
    return false;
  }

  /// <summary>
  /// Letztes rückgängig gemachtes Kommando wiederherstellen.
  /// </summary>
  /// <param name="ud">Betroffene Benutzerdaten.</param>
  /// <returns>True, wenn es ein letztes Kommando gab, das erfolgreich wiederhergestellt werden konnte, sonst false.</returns>
  public bool Redo(UserDaten ud)
  {
    // Implementation for redoing the last undone command.
    return false;
  }
}
