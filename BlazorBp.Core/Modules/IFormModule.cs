// <copyright file="IFormModule.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Core.Modules;

using BlazorBp.Core.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

public interface IFormModule
{
  /// <summary>Liefert die Hauptmenüs, die dieses Modul bereitstellt.</summary>
  /// <returns>Liste der Hauptmenüs.</returns>
  IEnumerable<MainMenu> GetMainMenues();

  /// <summary>DI-Registrierung modul-eigener Services.</summary>
  /// <param name="services">Betroffene Service-Collection.</param>
  void ConfigureServices(IServiceCollection services);

  /// <summary>App-Konfiguration ergänzen, z.B. mit MapGet.</summary>
  /// <param name="app">Betroffene WebApplication.</param>
  void ConfigureApp(WebApplication app);

  /// <summary>Liefert die Formulare, die dieses Modul bereitstellt.</summary>
  /// <returns>Dictionary mit den Formularen.</returns>
  Dictionary<string, Formular> GetForms();
}
