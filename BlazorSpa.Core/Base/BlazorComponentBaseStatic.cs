// <copyright file="BlazorComponentBaseStatic.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorSpa.Core.Base;

using Microsoft.AspNetCore.Http;

/// <summary>
/// Statische Hilfsfunktionen.
/// </summary>
public static class BlazorComponentBaseStatic
{
  /// <summary>
  /// Alle möglichen Formulare als Kopiervorlage für Use cases.
  /// </summary>
  private static readonly Dictionary<string, Formular> Formulare = new()
  {
    { "Index", new Formular { Action = "index", Area = "", Name = "Startseite" } },
  };

  /// <summary>
  /// Hinzufügen von Formularen, die in der statischen Formulare-Liste nicht enthalten sind.
  /// </summary>
  /// <param name="forms">Neue Formulare.</param>
  public static void AddFormulare(Dictionary<string, Formular> forms)
  {
    foreach (var kv in forms)
    {
      Formulare[kv.Key] = kv.Value;
    }
  }

  /// <summary>
  /// Lesen des Table-Model einer Formular-Instanz.
  /// </summary>
  /// <typeparam name="TU">Typ des Table-Models.</typeparam>
  /// <param name="session">Betroffene Session.</param>
  /// <param name="form">Betroffener Formularname.</param>
  /// <param name="id">Betroffene ID.</param>
  /// <returns>Das gelesene Table-Model oder null.</returns>
  public static TU? ReadFormularTableModel<TU>(ISession session, string form, string id)
  {
    var model = session.GetObjectFromJson<TU>($"{form}.Table.{id}");
    return model;
  }

  /// <summary>
  /// Lesen des Form-Model einer Formular-Instanz.
  /// </summary>
  /// <typeparam name="TU">Typ des Form-Models.</typeparam>
  /// <param name="session">Betroffene Session.</param>
  /// <param name="form">Betroffener Formularname.</param>
  /// <param name="id">Betroffene ID.</param>
  /// <returns>Das gelesene Form-Model oder null.</returns>
  public static TU? ReadFormularFormModel<TU>(ISession session, string form, string id)
  {
    var model = session.GetObjectFromJson<TU>($"{form}.Form.{id}");
    return model;
  }

  /// <summary>
  /// Prüfen, ob die ReturnUrl gültig ist, d.h. ein relativer Pfad ohne externe Protokolle oder doppelte Slashes.
  /// </summary>
  /// <param name="returnUrl">Zu prüfende ReturnUrl.</param>
  /// <returns>True, wenn die ReturnUrl gültig ist.</returns>
  public static bool IsValidReturnUrl(string returnUrl)
  {
    if (string.IsNullOrWhiteSpace(returnUrl))
      return false;

    // Prüfen, ob es sich um einen relativen Pfad handelt (beginnt mit '/')
    // und ob keine externen Protokolle oder doppelte Slashes (//) verwendet werden.
    return returnUrl.StartsWith("/")
      && !returnUrl.StartsWith("//")
      && !returnUrl.StartsWith("/\\")
      && Uri.IsWellFormedUriString(returnUrl, UriKind.Relative);
  }

  /// <summary>
  /// Versuch, ein Formular aus der statischen Formulare-Liste zu lesen.
  /// </summary>
  /// <param name="name">Name des zu lesenden Formulars.</param>
  /// <param name="formular">Das gelesene Formular oder null.</param>
  /// <returns>True, wenn das Formular gefunden wurde.</returns>
  internal static bool TryGetFormular(string name, out Formular? formular)
  {
    return Formulare.TryGetValue(name, out formular);
  }
}
