// <copyright file="Konstanten.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorSpa.Base;

/// <summary>
/// All public constants.
/// </summary>
public static class Konstanten
{
  /// <summary>Liefert Zeilenumbruch (Windows).</summary>
  public const string CrLf = "\r\n";

  /// <summary>Milliseconds for http request timeout (10000 for fixer.io instead of 5000).</summary>
  public const int HttpTimeout = 10000;
}
