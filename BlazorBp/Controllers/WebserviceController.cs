// <copyright file="WebserviceController.cs" company="LDI">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace blazorbp.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

  /// <summary>Controller für die Anmeldung und Abmeldung eines Benutzers.</summary>
public class WebserviceController : Controller
{
  /// <summary>Daten für die HelloWorld-Funktion.</summary>
  public class HelloWorldDaten
  {
    /// <summary>Betroffener Mandant.</summary>
    public int Client { get; set; }
  }

  /// <summary>Test-Funktion.</summary>
  /// <param name="Model">Betroffene Daten.</param>
  /// <returns>Die üpergebenen Daten.</returns>
  [HttpPost("/webservice/helloworld")]
  [AllowAnonymous]
  public async Task<IActionResult> HelloWorld([FromBody] HelloWorldDaten Model)
  {
    await Task.Delay(1);
    // return NotFound();
    return Json(Model);
  }
}
