// <copyright file="AuthController.cs" company="LDI">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Controllers;

using System.Security.Claims;
using System.Text.Json;
using BlazorBp.Core.Base;
using BlazorSpa.Base;
using BlazorSpa.Base.Auth;
using BlazorSpa.Base.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

  /// <summary>Controller für die Anmeldung und Abmeldung eines Benutzers.</summary>
public class AuthController(IAuthService singleton) : Controller
{
  /// <summary>Daten für die Anmeldung eines Benutzers.</summary>
  public class UserInfo
  {
    /// <summary>Betroffener Mandant.</summary>
    public int Client { get; set; }

    /// <summary>Betroffene Benutzer-ID.</summary>
    public string? Username { get; set; }

    /// <summary>Betroffenes Kennwort.</summary>
    public string? Password { get; set; }
  }

  private readonly IAuthService authService = singleton;

  /// <summary>Anmeldung für einen Benutzer.</summary>
  /// <param name="Model">Daten für die Anmeldung eines Benutzers.</param>
  /// <returns>Daten des angemeldeten Benutzers.</returns>
  [AllowAnonymous]
  [HttpPost("/auth/login")]
  public async Task<IActionResult> LoginUser([FromBody] UserInfo Model)
  {
    if (Model == null)
      return NoContent();
    // using StreamReader reader = new(HttpContext.Request.Body, false);
    // var str = await reader.ReadToEndAsync();
    // // {"id":"1x","client":1,"username":"admin","password":"test","nr":null,"submitControl":null,"handler":null,"modalArt":null,"modalId":null,"focus":"Password","readonlyHiddenError":null,"submit":null}
    // var Model = System.Text.Json.JsonSerializer.Deserialize<UserInfo>(str);
    var sessionId = UserDaten.GetNewSessionId();
    var ud0 = new UserDaten(sessionId, Model.Client, Model.Username ?? "Benutzer", []);
    var ud = authService.LoginUser(ud0, Model?.Password ?? "");
    if (ud != null)
    {
      // Rollen bestimmen.
      var expire = DateTimeOffset.UtcNow.AddSeconds(Konstanten.SESSION_TIMEOUT);
      var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
      identity.AddClaim(new Claim(ClaimTypes.Sid, Konstanten.CLAIM_SID));
      identity.AddClaim(new Claim(ClaimTypes.Name, ud.BenutzerId));
      foreach (var role in ud.Rollen)
        identity.AddClaim(new Claim(ClaimTypes.Role, role));
      identity.AddClaim(new Claim(ClaimTypes.Expiration, expire.ToString()));
      await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity),
        new AuthenticationProperties
        {
          IsPersistent = true,
          IssuedUtc = DateTimeOffset.UtcNow,
          ExpiresUtc = expire,
        });
      var json = JsonSerializer.Serialize(ud);
      return Json(json);
      // return Json($"{{\"Client\":{daten.MandantNr},\"Username\":\"{Username}\"}}");
    }
    return NotFound(); // Json("{\"result\":false}");
  }

  /// <summary>
  /// Logout und Weiterleitung an die Startseite.
  /// </summary>
  [Authorize] // Kein Redirect mit ReturnUrl.
  //// [ValidateAntiForgeryToken] // Fehler: No service for type 'Microsoft.AspNetCore.Mvc.ViewFeatures.Filters.ValidateAntiforgeryTokenAuthorizationFilter' has been registered.
  [HttpGet("/auth/logout")]
  public async Task<IActionResult> LogoutUser()
  {
    // TODO evtl. POST+CSRF-Schutz.
    var userdaten = HttpContext.Session?.GetUserDaten();
    if (userdaten != null)
    {
      var formdata = HttpContext.Session?.GetFormData()?.ToJsonString();
      authService.LogoutUser(userdaten, formdata);
    }
    System.Diagnostics.Debug.Print($"{DateTime.Now.ToString("HH:mm:ss.fff")} LogoutUser {userdaten?.MandantNr} {userdaten?.BenutzerId}");
    HttpContext.Session?.SetFormState(null);
    HttpContext.Session?.SetUserDaten(null);
    HttpContext.Session?.SetFormData(null);
    HttpContext.Session?.RemoveAllModels();
    if (userdaten != null)
      CSBP.Services.Base.ServiceBase.RemoveUndoRedoStack(userdaten.SessionId);
    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return Redirect("/");
  }
}
