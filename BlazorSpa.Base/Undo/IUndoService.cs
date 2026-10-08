// <copyright file="IUndoService.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorSpa.Base.Undo;

using BlazorSpa.Base.Models;

/// <summary>
/// Interface für Undo/Redo-Funktionen.
/// </summary>
public interface IUndoService
{
  /// <summary>
  /// Letztes Kommando rückgängig machen.
  /// </summary>
  /// <param name="ud">Betroffene Benutzerdaten.</param>
  /// <returns>True, wenn es ein letztes Kommando gab, das erfolgreich rückgängig gemacht werden konnte, sonst false.</returns>
  bool Undo(UserDaten ud);

  /// <summary>
  /// Letztes rückgängig gemachtes Kommando wiederherstellen.
  /// </summary>
  /// <param name="ud">Betroffene Benutzerdaten.</param>
  /// <returns>True, wenn es ein letztes Kommando gab, das erfolgreich wiederhergestellt werden konnte, sonst false.</returns>
  bool Redo(UserDaten ud);
}
