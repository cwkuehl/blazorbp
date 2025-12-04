// <copyright file="WebserviceController.cs" company="LDI">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace blazorbp.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

/// <summary>Controller für die Anmeldung und Abmeldung eines Benutzers.</summary>
[ApiController]
[Route("webapi")]
public class WebserviceController : Controller
{
  /// <summary>Daten für die HelloWorld-Funktion.</summary>
  public class HelloWorldDaten
  {
    /// <summary>Betroffener Mandant.</summary>
    public int Client { get; set; }
  }

  /// <summary>Test-Funktion gibt HelloWorldDaten im Json-Format zurück.
  /// Hier ist noch eine zweite Zeile. Ist der Zeilenumbruch vorhanden?</summary>
  /// <param name="Model">Betroffene Daten.</param>
  /// <returns>Die übergebenen Daten.</returns>
  [HttpPost("helloworld")]
  [AllowAnonymous]
  public async Task<IActionResult> HelloWorld([FromBody] HelloWorldDaten Model)
  {
    await Task.Delay(1);
    // return NotFound();
    if (Model == null)
      Model = new HelloWorldDaten { Client = -1 };
    return Json(Model);
  }

  /// <summary>Test-Funktion.</summary>
  /// <param name="Model">Betroffene Daten.</param>
  /// <returns>Die übergebenen Daten.</returns>
  [HttpPost("helloworld2")]
  [AllowAnonymous]
  public async Task<IActionResult> HelloWorld2([FromBody] HelloWorldDaten Model)
  {
    await Task.Delay(1);
    // return NotFound();
    if (Model != null)
      Model.Client = 2;
    return Json(Model);
  }
}
