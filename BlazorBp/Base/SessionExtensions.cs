// <copyright file="SessionExtensions.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Base;

using System.Text.Json;
using CSBP.Services.Base;

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

  /// <summary>Lesen eines Boolean-Wertes aus der Session.</summary>
  /// <param name="session">Betroffene Session.</param>
  /// <param name="key">Betroffener Schlüssel.</param>
  /// <returns>Boolean-Wert oder null.</returns>
  public static bool? GetBoolean(this ISession session, string key)
  {
    var data = session.Get(key);
    if (data == null)
    {
      return null;
    }
    return BitConverter.ToBoolean(data, 0);
  }

  /// <summary>Speichern eines Boolean-Wertes in der Session.</summary>
  /// <param name="session">Betroffene Session.</param>
  /// <param name="key">Betroffener Schlüssel.</param>
  /// <param name="value">Betroffener Wert.</param>
  public static void SetBoolean(this ISession session, string key, bool value)
  {
    session.Set(key, BitConverter.GetBytes(value));
  }

  // public static Header? GetHeader(this ISession session)
  // {
  //   var key = typeof(Header).FullName ?? "";
  //   var data = session.GetObjectFromJson<Header>(key);
  //   return data;
  // }

  // public static void SetHeader(this ISession session, Header value)
  // {
  //   var key = typeof(Header).FullName ?? "";
  //   if (value == null)
  //     session.Remove(key);
  //   else
  //     session.SetObjectAsJson(key, value);
  // }

  /// <summary>Lesen des Formular-Zustands in der Session.</summary>
  /// <param name="session">Betroffene Session.</param>
  /// <returns>Formular-Zustand oder null.</returns>
  public static FormularZustand? GetFormState(this ISession session)
  {
    var key = typeof(FormularZustand).FullName ?? "";
    var data = session.GetObjectFromJson<FormularZustand>(key);
    return data;
  }

  /// <summary>Speichern des Formular-Zustands in der Session.</summary>
  /// <param name="session">Betroffene Session.</param>
  /// <param name="value">Betroffener Wert.</param>
  public static void SetFormState(this ISession session, FormularZustand? value)
  {
    var key = typeof(FormularZustand).FullName ?? "";
    if (value == null)
      session.Remove(key);
    else
      session.SetObjectAsJson(key, value);
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
