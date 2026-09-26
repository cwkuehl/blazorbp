// <copyright file="SessionExtensions.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Base;

using System.Text.Json;
using CSBP.Services.Base;
using Microsoft.AspNetCore.Http;

/// <summary>Zugriffe auf die Session-Daten.</summary>
public static class SessionExtensions
{
  /// <summary>Lesen eines JSON-Objekts aus der Session.</summary>
  /// <param name="session">Betroffene Session.</param>
  /// <param name="key">Betroffener Schlüssel.</param>
  /// <returns>JSON-Objekt oder null.</returns>
  public static T? GetObjectFromJson<T>(this ISession session, string key)
  {
    var value = session.GetString(key);
    return value == null ? default(T) : JsonSerializer.Deserialize<T>(value);
  }

  /// <summary>Speichert ein Objekt als JSON in der Session.</summary>
  /// <param name="session">Betroffene Session.</param>
  /// <param name="key">Betroffener Schlüssel.</param>
  /// <param name="value">Betroffener Wert.</param>
  public static void SetObjectAsJson(this ISession session, string key, object? value)
  {
    if (value != null)
      session.SetString(key, JsonSerializer.Serialize(value));
  }

  /// <summary>Lesen der User-Daten in der Session.</summary>
  /// <param name="session">Betroffene Session.</param>
  /// <returns>User-Daten oder null.</returns>
  public static UserDaten? GetUserDaten(this ISession session)
  {
    var key = typeof(UserDaten).FullName ?? "";
    var data = session.GetObjectFromJson<UserDaten>(key);
    return data;
  }

  /// <summary>Speichern der User-Daten in der Session.</summary>
  /// <param name="session">Betroffene Session.</param>
  /// <param name="value">Betroffener Wert.</param>
  public static void SetUserDaten(this ISession session, UserDaten? value)
  {
    var key = typeof(UserDaten).FullName ?? "";
    if (value == null)
      session.Remove(key);
    else
      session.SetObjectAsJson(key, value);
  }
}
