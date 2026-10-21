// <copyright file="StartTask.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorSpa.Core.Components;

using Microsoft.AspNetCore.Http;

/// <summary>
/// Komponente zum Lesen der Download-Daten.
/// </summary>
public static class StartTask
{
  /// <summary>Liste von Funktionen zum Starten von Aufgaben.</summary>
  private static List<Func<string, string, HttpContext, IServiceProvider, (bool, string?)>> funcStart = new();

  /// <summary>Funktion zum Starten von Aufgaben registrieren.</summary>
  /// <param name="func">Zu registrierende Funktion.</param>
  public static void RegisterFuncStartTask(Func<string, string, HttpContext, IServiceProvider, (bool, string?)>? func)
  {
    if (func != null)
      funcStart.Add(func);
  }

  /// <summary>Startet eine asynchrone, länger laufende Aufgabe.</summary>
  /// <param name="page">Betroffene Seite, z.B. "AG100".</param>
  /// <param name="id">Betroffene Formular-ID.</param>
  /// <param name="context">Betroffener HttpContext.</param>
  /// <param name="sp">Betroffener IServiceProvider.</param>
  public static void Do(string page, string id, HttpContext context, IServiceProvider sp)
  {
    bool b = false;
    string? fehler = null;
    foreach (var func in funcStart)
    {
      (b, fehler) = func(page, id, context, sp);
      if (b)
        break;
    }
  }
}
