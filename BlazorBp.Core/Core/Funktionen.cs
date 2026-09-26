// <copyright file="Funktionen.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

using System.Globalization;

namespace BlazorBp.Core.Core;

/// <summary>
/// General useful functions.
/// </summary>
public static partial class Funktionen
{
  /// <summary>German culture info.</summary>
  private static readonly CultureInfo CultureInfoDeRo = CultureInfo.CreateSpecificCulture("de-DE");

  /// <summary>English culture info.</summary>
  private static readonly CultureInfo CultureInfoEnRo = CultureInfo.CreateSpecificCulture("en-GB");

  /// <summary>Current culture info.</summary>
  private static CultureInfo cultureInfoCuSt = CultureInfo.CreateSpecificCulture("de-DE");

  /// <summary>Gets the current culture info.</summary>
  public static CultureInfo CultureInfoCu => cultureInfoCuSt;

  /// <summary>Gets the German culture info.</summary>
  public static CultureInfo CultureInfoDe => CultureInfoDeRo;

  /// <summary>Gets the English culture info.</summary>
  public static CultureInfo CultureInfoEn => CultureInfoEnRo;

  /// <summary>
  /// Function does nothing.
  /// </summary>
  /// <param name="obj">Optional parameter is not used.</param>
  /// <returns>Number 0.</returns>
  public static int MachNichts(object? obj = null)
  {
    if (obj == null)
      return 0;
    return 0;
  }

  /// <summary>
  /// Returns first or second string depending on boolean value.
  /// </summary>
  /// <param name="b">Affected boolean value.</param>
  /// <param name="s1">First string if true.</param>
  /// <param name="s2">Second string if false.</param>
  /// <returns>First or second string.</returns>
  public static string? Iif(bool b, string? s1, string? s2)
  {
    if (b)
      return s1;
    return s2;
  }

  /// <summary>
  /// Optionally trims a string and returns null if it is empty.
  /// </summary>
  /// <param name="s">Affected string.</param>
  /// <param name="trim">Trim value or not.</param>
  /// <returns>Converted string.</returns>
  public static string? TrimNull(this string? s, bool trim = true)
  {
    if (trim)
      s = s?.Trim();
    if (string.IsNullOrEmpty(s))
    {
      return null;
    }
    return s;
  }

  /// <summary>
  /// Converts string to nullable bool.
  /// </summary>
  /// <param name="s">Affected string.</param>
  /// <returns>Converted value.</returns>
  public static bool? ToBool(string? s)
  {
    if (!string.IsNullOrWhiteSpace(s) && bool.TryParse(s, out var d))
      return d;
    return null;
  }

  /// <summary>
  /// Converts string to decimal.
  /// </summary>
  /// <returns>Converted value.</returns>
  /// <param name="s">Affected string.</param>
  /// <param name="digits">Number of digits to round.</param>
  /// <param name="english">Parse with English culture or not.</param>
  public static decimal? ToDecimal(string? s, int digits = -1, bool english = false)
  {
    if (!string.IsNullOrWhiteSpace(s) && decimal.TryParse(s, NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands,
        english ? CultureInfoEn : CultureInfoCu, out var d))
    {
      if (digits >= 0)
        d = Math.Round(d, digits, MidpointRounding.AwayFromZero);
      return d;
    }
    return null;
  }

  /// <summary>
  /// Converts string to integer.
  /// </summary>
  /// <returns>Converted value.</returns>
  /// <param name="s">Affected string.</param>
  public static int? ToNullableInt32(string? s)
  {
    var d = ToDecimal(s, 0);
    if (d.HasValue && d.Value >= int.MinValue && d.Value <= int.MaxValue)
      return (int)d.Value;
    return null;
  }

  /// <summary>
  /// Converts nullable decimal to string.
  /// </summary>
  /// <param name="d">Affected value.</param>
  /// <param name="digits">Number of digits to print.</param>
  /// <param name="ci">Affected culture info.</param>
  /// <param name="withoutkomma">True, if the decimal separator is removed.</param>
  /// <returns>Converted value.</returns>
  public static string ToString(decimal? d, int digits = -1, CultureInfo? ci = null, bool withoutkomma = false)
  {
    if (!d.HasValue)
      return string.Empty;
    var v = d.Value.ToString(digits < 0 ? "N" : $"N{digits}", ci ?? CultureInfoCu);
    if (withoutkomma)
      v = v.Replace(",", "");
    return v;
  }

  /// <summary>
  /// Liefert den Suchtext für eine Like-Suche: aus * wird % und falls kein %, wird % angehängt.
  /// </summary>
  /// <param name="s">Betroffener Suchstring.</param>
  /// <returns>Suchtext für eine Like-Suche.</returns>
  public static string GetSuche(string? s)
  {
    if (string.IsNullOrEmpty(s))
      return "";
    var st = s.Replace("*", "%");
    if (!st.Contains("%"))
      st += "%";
    return st;
  }

  /// <summary>
  /// Checks if it is a filtering like expression. Empty, % and %% are not.
  /// </summary>
  /// <param name="t">Affected like expression.</param>
  /// <returns>It is a filtering like expression or not.</returns>
  public static bool IsLike(string t)
  {
    return !(string.IsNullOrEmpty(t) || t == "%" || t == "%%");
  }
}

