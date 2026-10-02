// <copyright file="Funktionen.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorSpa.Base;

using System.Globalization;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// General useful functions.
/// </summary>
public static partial class Funktionen
{
  /// <summary>Instance of random number generator.</summary>
  private static readonly RandomNumberGenerator Csp = RandomNumberGenerator.Create();

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
  public static int ToInt32(string? s)
  {
    var d = ToDecimal(s, 0);
    if (d.HasValue && d.Value >= int.MinValue && d.Value <= int.MaxValue)
      return (int)d.Value;
    return 0;
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
  /// Converts nullable DateTime to string in format yyyy-MM-dd, yyyy-MM-dd HH:mm:ss or yyyy-MM-dd HH:mm:ss.fffffff.
  /// </summary>
  /// <param name="d">Affected value.</param>
  /// <param name="time">Formats with time or not.</param>
  /// <param name="milli">Formats with milliseconds or not.</param>
  /// <returns>Converted value.</returns>
  public static string ToString(DateTime? d, bool time = false, bool milli = false)
  {
    if (!d.HasValue)
      return string.Empty;
    if (time)
    {
      if (milli)
        return d.Value.ToString("yyyy-MM-dd HH:mm:ss.fffffff");
      return d.Value.ToString("yyyy-MM-dd HH:mm:ss");
    }
    return d.Value.ToString("yyyy-MM-dd");
  }

  /// <summary>
  /// Get the string between two strings.
  /// </summary>
  /// <param name="str">Affected string.</param>
  /// <param name="from">Affected from string.</param>
  /// <param name="to">Affected to string.</param>
  /// <returns>Affected string in between.</returns>
  public static string? Between(string str, string from, string? to)
  {
    if (string.IsNullOrEmpty(str))
      return null;
    var anfang = string.IsNullOrEmpty(from) ? 0 : str.IndexOf(from);
    if (anfang >= 0)
    {
      var l = from?.Length ?? 0;
      if (string.IsNullOrEmpty(to))
        return str.Substring(anfang + l);
      var ende = str.IndexOf(to, anfang + l);
      if (ende > anfang + l)
        return str.Substring(anfang + l, ende - anfang - l);
    }
    return null;
  }

  /// <summary>
  /// Returns the right part of a string with the given length.
  /// If the string is too short, it is returned unchanged.
  /// If the string is null, the empty string is returned.
  /// </summary>
  /// <param name="value">Affected string.</param>
  /// <param name="length">The number of characters to return.</param>
  /// <returns>A shorter, the same or the empty string.</returns>
  public static string Right(this string? value, int length)
  {
    return value == null
      ? string.Empty
      : (length > value.Length ? value : value.Substring(value.Length - length, length));
  }

  /// <summary>
  /// Returns file name optionally with date and random number.
  /// </summary>
  /// <param name="name">Name am Anfang.</param>
  /// <param name="datum">With current date or not.</param>
  /// <param name="zeit">With current time or not.</param>
  /// <param name="zufall">With random number or not.</param>
  /// <param name="endung">Dateiendung ohne Punkt.</param>
  /// <returns>File name.</returns>
  public static string GetDateiname(string name, bool datum, bool zeit, bool zufall, string endung)
  {
    var sb = new StringBuilder();
    if (!string.IsNullOrEmpty(name))
      sb.Append(name);
    if (datum)
    {
      if (zeit)
        sb.Append('_').Append(DateTime.Now.ToString("yyyyMMddHHmmss"));
      else
        sb.Append('_').Append(DateTime.Today.ToString("yyyyMMdd"));
    }
    else if (zeit)
      sb.Append('_').Append(DateTime.Now.ToString("HHmmss"));
    if (zufall)
      sb.Append('_').Append(NextRandom(1000, 10000));
    if (!string.IsNullOrEmpty(endung))
      sb.Append('.').Append(endung);
    return sb.ToString();
  }

  /// <summary>
  /// Gets the next random number between two values.
  /// </summary>
  /// <param name="minValue">Minimal value.</param>
  /// <param name="maxExclusiveValue">Exclusive maximal value.</param>
  /// <returns>Random number between two values.</returns>
  public static int NextRandom(int minValue, int maxExclusiveValue)
  {
    if (minValue >= maxExclusiveValue)
      throw new ArgumentOutOfRangeException(nameof(minValue)); // "minValue must be lower than maxExclusiveValue");

    var diff = (long)maxExclusiveValue - minValue;
    var upperBound = uint.MaxValue / diff * diff;

    uint ui;
    do
    {
      ui = GetRandomUInt();
    }
    while (ui >= upperBound);
    return (int)(minValue + (ui % diff));
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
  public static bool IsLike(string? t)
  {
    return !(string.IsNullOrEmpty(t) || t == "%" || t == "%%");
  }

  /// <summary>
  /// Gets a random integer.
  /// </summary>
  /// <returns>Random integer.</returns>
  private static uint GetRandomUInt()
  {
    var randomBytes = GenerateRandomBytes(sizeof(uint));
    return BitConverter.ToUInt32(randomBytes, 0);
  }

  /// <summary>
  /// Gets random bytes.
  /// </summary>
  /// <param name="bytesNumber">Number of bytes.</param>
  /// <returns>Random bytes.</returns>
  private static byte[] GenerateRandomBytes(int bytesNumber)
  {
    var buffer = new byte[bytesNumber];
    Csp.GetBytes(buffer);
    return buffer;
  }
}

