// <copyright file="WebserviceController.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Forms.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

/// <summary>Controller für die Anmeldung und Abmeldung eines Benutzers.</summary>
[ApiController]
[Route("webapi")]
public class WebserviceController : Controller
{
  /// <summary>Test-Funktion gibt HelloWorldDaten im Json-Format zurück.
  /// Hier ist noch eine zweite Zeile. Der Zeilenumbruch vorhanden.</summary>
  /// <param name="model">Betroffene Daten.</param>
  /// <returns>Die übergebenen Daten.</returns>
  [HttpPost("helloworld")]
  [AllowAnonymous]
  public async Task<IActionResult> HelloWorld([FromBody] HelloWorldDaten model)
  {
    await Task.Delay(1);
    //// return NotFound();
    if (model == null)
      model = new HelloWorldDaten { Client = -1 };
    return Json(model);
  }

  /// <summary>Test-Funktion.</summary>
  /// <param name="model">Betroffene Daten.</param>
  /// <returns>Die übergebenen Daten.</returns>
  [HttpPost("helloworld2")]
  [AllowAnonymous]
  public async Task<IActionResult> HelloWorld2([FromBody] HelloWorldDaten model)
  {
    await Task.Delay(1);
    //// return NotFound();
    if (model != null)
      model.Client = 2;
    return Json(model);
  }

  /// <summary>Daten für die HelloWorld-Funktion.</summary>
  public class HelloWorldDaten
  {
    /// <summary>Betroffener Mandant.</summary>
    public int Client { get; set; }
  }
}
