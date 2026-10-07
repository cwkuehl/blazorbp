// <copyright file="AuthService.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorSpa.Base.Auth;

using BlazorSpa.Base.Models;

/// <summary>
/// Klasse für die Basis-Anmeldung und das Abmeldung von Benutzern.
/// </summary>
public class AuthService : IAuthService
{
  /// <summary>
  /// Anmelden eines Benutzers.
  /// </summary>
  /// <param name="daten">Betroffene Benutzerdaten.</param>
  /// <param name="password">Betroffenes Kennwort.</param>
  /// <returns>Ergebnis der Anmeldung.</returns>
  public UserDaten LoginUser(UserDaten daten, string password)
  {
    var d = new UserDaten(daten.SessionId, daten.MandantNr, daten.BenutzerId, [ UserDaten.RoleUser]);
    return d;
  }

  /// <summary>
  /// Abmelden eines Benutzers.
  /// </summary>
  /// <param name="daten">Betroffene Benutzerdaten.</param>
  /// <param name="formdata">Betroffene Formulardaten.</param>
  public void LogoutUser(UserDaten daten, string? formdata = null)
  {
    // Implementation for logging out a user.
  }

  /// <summary>
  /// Liefert die Formulardaten für den angemeldeten Benutzer.
  /// </summary>
  /// <param name="daten">Betroffene Benutzerdaten.</param>
  /// <returns>Formulardaten für den angemeldeten Benutzer.</returns>
  public string GetFormData(UserDaten daten)
  {
    // Implementation for getting form data for a logged-in user.
    return string.Empty;
  }
}
