// <copyright file="Konstanten.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Base;

/// <summary>Konstanten für die Anwendung.</summary>
public static class Konstanten
{
  /// <summary>Blazor mit Interaktivität?</summary>
  public const bool Interactive = false;

  /// <summary>Session Timeout in Sekunden.</summary>
  public const int SESSION_TIMEOUT = 245; // Countdown hat (x - 5) / 2 Sekunden, weil Cookie Expiration erst nach der Hälfte der Zeit verlängert wird.

  /// <summary>Session Timeout in Sekunden.</summary>
  public const string CLAIM_SID = "123xQp5ß";
}
