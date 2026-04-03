// <copyright file="FormData.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlazorBp.Base;

/// <summary>
/// Die Klasse speichert Daten Formulare.
/// </summary>
[Serializable]
public class FormData
{
  /// <summary>
  /// Alle möglichen Daten aus Formularen.
  /// </summary>
  [JsonInclude]
  private Dictionary<string, string> Data = new();

  /// <summary>
  /// Holt oder setzt Daten eines Formulars.
  /// </summary>
  /// <param name="key">Betroffener Schlüssel, z.B. "AG100Name".</param>
  /// <returns>Betroffener Wert oder null.</returns>
  public string? this[string key]
  {
    get
    {
      if (Data.ContainsKey(key))
        return Data[key];
      return null;
    }
    set
    {
      if (value == null)
      {
        if (Data.ContainsKey(key))
          Data.Remove(key);
      }
      else
        Data[key] = value;
    }
  }

  /// <summary>
  /// Liefert die Daten als JSON-String.
  /// </summary>
  /// <returns>Daten als JSON-String.</returns>
  public string ToJsonString()
  {
    string json = JsonSerializer.Serialize(Data);
    return json;
  }

  /// <summary>Füllt die Daten aus einem JSON-String.</summary>
  /// <param name="json">JSON-String mit den Daten.</param>
  public void FromJsonString(string json)
  {
    // Optionen für die Deserialisierung mit Fehlerbehandlung.
    var options = new JsonSerializerOptions
    {
      AllowTrailingCommas = true, // Trailing commas erlauben
      ReadCommentHandling = JsonCommentHandling.Skip, // Kommentare überspringen
      Converters = { }, // Keine Fehler werfen, wenn das JSON ungültig ist
    };
    Dictionary<string, string>? data = null;
    try
    {
      data = JsonSerializer.Deserialize<Dictionary<string, string>>(json, options);
    }
    catch (JsonException)
    {
      // Fehler beim Deserialisieren ignorieren und mit leeren Daten fortfahren.
      data = [];
    }
    Data.Clear();
    foreach (var kvp in data ?? [])
    {
      Data[kvp.Key] = kvp.Value;
    }
  }
}