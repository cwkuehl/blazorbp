// <copyright file="IAuthService.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorSpa.Base.Auth;

using BlazorSpa.Base.Models;

/// <summary>
/// Interface für die Anmeldung und das Abmeldung von Benutzern.
/// </summary>
public interface IAuthService
{
  /// <summary>
  /// Anmelden eines Benutzers.
  /// </summary>
  /// <param name="daten">Betroffene Benutzerdaten.</param>
  /// <param name="password">Betroffenes Kennwort.</param>
  /// <returns>Ergebnis der Anmeldung.</returns>
  UserDaten LoginUser(UserDaten daten, string password);

  /// <summary>
  /// Abmelden eines Benutzers.
  /// </summary>
  /// <param name="daten">Betroffene Benutzerdaten.</param>
  /// <param name="formdata">Betroffene Formulardaten.</param>
  void LogoutUser(UserDaten ud, string? formdata = null);

  /// <summary>
  /// Liefert die Formulardaten für den angemeldeten Benutzer.
  /// </summary>
  /// <param name="daten">Betroffene Benutzerdaten.</param>
  /// <returns>Formulardaten für den angemeldeten Benutzer.</returns>
  string GetFormData(UserDaten daten);
}
