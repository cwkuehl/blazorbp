// <copyright file="BlazorBpUndoService.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Forms.Undo;

using BlazorSpa.Base.Models;
using BlazorSpa.Base.Undo;

/// <summary>
/// Klasse für die Undo/Redo-Funktionen.
/// </summary>
public class BlazorBpUndoService : IUndoService
{
  /// <summary>
  /// Letztes Kommando rückgängig machen.
  /// </summary>
  /// <param name="ud">Betroffene Benutzerdaten.</param>
  /// <returns>True, wenn es ein letztes Kommando gab, das erfolgreich rückgängig gemacht werden konnte, sonst false.</returns>
  public bool Undo(UserDaten ud)
  {
    // TODO Session-spezifisches Undo.
    var daten = new CSBP.Services.Base.ServiceDaten(ud);
    var r = CSBP.Services.Factory.FactoryService.LoginService.Undo(daten);
    return r.Ok && r.Ergebnis;
  }

  /// <summary>
  /// Letztes rückgängig gemachtes Kommando wiederherstellen.
  /// </summary>
  /// <param name="ud">Betroffene Benutzerdaten.</param>
  /// <returns>True, wenn es ein letztes Kommando gab, das erfolgreich wiederhergestellt werden konnte, sonst false.</returns>
  public bool Redo(UserDaten ud)
  {
    // Implementation for redoing the last undone command.
    var daten = new CSBP.Services.Base.ServiceDaten(ud);
    var r = CSBP.Services.Factory.FactoryService.LoginService.Redo(daten);
    return r.Ok && r.Ergebnis;
  }
}
