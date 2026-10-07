// <copyright file="BlazorBpAuthService.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Forms.Auth;

using BlazorSpa.Base.Auth;
using BlazorSpa.Base.Models;

/// <summary>
/// Klasse für die Anmeldung und das Abmeldung von Benutzern.
/// </summary>
public class BlazorBpAuthService : IAuthService
{
  /// <summary>
  /// Anmelden eines Benutzers.
  /// </summary>
  /// <param name="ud">Betroffene Benutzerdaten.</param>
  /// <param name="password">Betroffenes Kennwort.</param>
  /// <returns>Ergebnis der Anmeldung.</returns>
  public UserDaten LoginUser(UserDaten ud, string password)
  {
    var daten = new CSBP.Services.Base.ServiceDaten(ud.SessionId, ud.MandantNr, ud.BenutzerId, null);
    var r = CSBP.Services.Factory.FactoryService.LoginService.Login(daten, password, false);
    if (r.Ok && r.Ergebnis != null)
      return r.Ergebnis;
    return ud;
  }

  /// <summary>
  /// Abmelden eines Benutzers.
  /// </summary>
  /// <param name="ud">Betroffene Benutzerdaten.</param>
  /// <param name="formdata">Betroffene Formulardaten.</param>
  public void LogoutUser(UserDaten ud, string? formdata = null)
  {
    if (ud != null)
    {
      var daten = new CSBP.Services.Base.ServiceDaten(ud);
      CSBP.Services.Factory.FactoryService.LoginService.Logout(daten, formdata);
    }
  }

  /// <summary>
  /// Liefert die Formulardaten für den angemeldeten Benutzer.
  /// </summary>
  /// <param name="ud">Betroffene Benutzerdaten.</param>
  /// <returns>Formulardaten für den angemeldeten Benutzer.</returns>
  public string GetFormData(UserDaten ud)
  {
    var daten = new CSBP.Services.Base.ServiceDaten(ud);
    var r = CSBP.Services.Factory.FactoryService.LoginService.GetFormData(daten);
    if (r.Ok && r.Ergebnis != null)
      return r.Ergebnis;
    return "";
  }
}
