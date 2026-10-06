// <copyright file="DownloadData.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Core.Components.Pages;

using System.Text;
using Microsoft.AspNetCore.Http;

/// <summary>
/// Komponente zum Lesen der Download-Daten.
/// </summary>
public static class DownloadData
{
  /// <summary>Liste von Funktionen zum Erzeugen von CSV-Dateien.</summary>
  private static List<Func<string, string, HttpContext, IServiceProvider, (string?, string?)>> _funcCsv = new();

  /// <summary>Liste von Funktionen zum Erzeugen von HTML-Dateien.</summary>
  private static List<Func<string, string, HttpContext, IServiceProvider, (byte[]?, string?)>> _funcHtml = new();

  /// <summary>Funktion zum Erzeugen von CSV-Dateien registrieren.</summary>
  /// <param name="func">Zu registrierende Funktion.</param>
  public static void RegisterFuncCsv(Func<string, string, HttpContext, IServiceProvider, (string?, string?)>? func)
  {
    if (func != null)
      _funcCsv.Add(func);
  }

  /// <summary>Funktion zum Erzeugen von HTML-Dateien registrieren.</summary>
  /// <param name="func">Zu registrierende Funktion.</param>
  public static void RegisterFuncHtml(Func<string, string, HttpContext, IServiceProvider, (byte[]?, string?)>? func)
  {
    if (func != null) 
      _funcHtml.Add(func);
  }

  /// <summary>Daten für CSV-Dateien lesen.</summary>
  /// <param name="page">Betroffene Seite, z.B. "AG100".</param>
  /// <param name="id">Betroffene Formular-ID.</param>
  /// <param name="context">Betroffener HttpContext.</param>
  /// <param name="sp">Betroffener IServiceProvider.</param>
  /// <returns>CSV-String oder null.</returns>
  public static string? GetCsv(string page, string id, HttpContext context, IServiceProvider sp)
  {
    string? s = null;
    string? fehler = null;
    foreach (var func in _funcCsv)
    {
      (s, fehler) = func(page, id, context, sp);
      if (!string.IsNullOrEmpty(s))
        return s;
      if (!string.IsNullOrEmpty(fehler))
        break;
    }
    var csv0 = $"""
      Seite;Fehler
      {page};{fehler ?? "CSV-Export nicht implementiert"}
      """;
    return csv0;
  }

  /// <summary>Daten für HTML-Dateien lesen.</summary>
  /// <param name="page">Betroffene Seite, z.B. "AG100".</param>
  /// <param name="id">Betroffene Formular-ID.</param>
  /// <param name="context">Betroffener HttpContext.</param>
  /// <param name="sp">Betroffener IServiceProvider.</param>
  /// <returns>Byte-Array oder null.</returns>
  public static byte[]? GetHtml(string page, string id, HttpContext context, IServiceProvider sp)
  {
    byte[]? s = null;
    string? fehler = null;
    foreach (var func in _funcHtml)
    {
      (s, fehler) = func(page, id, context, sp);
      if (s != null && s.Length > 0)
        return s;
      if (!string.IsNullOrEmpty(fehler))
        break;
    }
    var s0 = $"""
      Seite;Fehler
      {page};{fehler ?? "HTML-Export nicht implementiert"}
      """;
    return Encoding.UTF8.GetBytes(s0);
  }
}
