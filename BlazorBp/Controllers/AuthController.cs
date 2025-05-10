// <copyright file="AuthController.cs" company="LDI">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace blazorbp.Controllers;

using System.Security.Claims;
using System.Text.Json;
using BlazorBp.Base;
using CSBP.Services.Base;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

  /// <summary>Controller für die Anmeldung und Abmeldung eines Benutzers.</summary>
public class AuthController : Controller
{
  // [HttpGet("/auth/login")]
  // [AllowAnonymous]
  // public async Task<IActionResult> LoginUser(string u, string p)
  // {
  //   return Redirect("/");
  // }

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

  /// <summary>Anmeldung für einen Benutzer.</summary>
  /// <param name="Model">Daten für die Anmeldung eines Benutzers.</param>
  /// <returns>Daten des angemeldeten Benutzers.</returns>
  [HttpPost("/auth/login")]
  [AllowAnonymous]
  public async Task<IActionResult> LoginUser([FromBody] UserInfo Model)
  {
    if (Model == null)
      return NoContent();
    // using StreamReader reader = new(HttpContext.Request.Body, false);
    // var str = await reader.ReadToEndAsync();
    // // {"id":"1x","client":1,"username":"admin","password":"test","nr":null,"submitControl":null,"handler":null,"modalArt":null,"modalId":null,"focus":"Password","readonlyHiddenError":null,"submit":null}
    // var Model = System.Text.Json.JsonSerializer.Deserialize<UserInfo>(str);
    var sessionId = UserDaten.GetNewSessionId();
    var daten = new ServiceDaten(sessionId, Model.Client, Model.Username, null);
  #if DEBUG
    var r = new ServiceErgebnis<UserDaten>(new UserDaten(sessionId, daten.MandantNr, daten.BenutzerId, new List<string> { UserDaten.RoleUser, UserDaten.RoleAdmin, UserDaten.RoleSuperadmin }));
    if (!(daten.MandantNr == 1 && daten.BenutzerId == "admin" && Model.Password == "test"))
    {
      var r0 = CSBP.Services.Factory.FactoryService.LoginService.Login(daten, Model?.Password, false);
      if (!r0.Ok)
        r.Errors.Add(Message.New("M0000Login fehlgeschlagen"));
    }
  #else
    var r = CSBP.Services.Factory.FactoryService.LoginService.Login(daten, Model?.Password, false);
  #endif
    if (r.Ok && r.Ergebnis != null)
    {
      // Rollen bestimmen.
      var ud = r.Ergebnis;
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
  [HttpGet("/auth/logout")]
  //// [Authorize] // Kein Redirect mit ReturnUrl.
  public async Task<IActionResult> LogoutUser()
  {
    var daten = HttpContext.Session?.GetUserDaten();
    System.Diagnostics.Debug.Print($"{DateTime.Now.ToString("HH:mm:ss.fff")} LogoutUser {daten?.MandantNr} {daten?.BenutzerId}");
    HttpContext.Session?.SetFormState(null);
    HttpContext.Session?.SetUserDaten(null);
    if (daten != null)
      ServiceBase.RemoveUndoRedoStack(daten.SessionId);
    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return Redirect("/");
  }
}
