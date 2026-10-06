// <copyright file="SpaBase.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorSpa.Base;

/// <summary>
/// Static functions for user interface.
/// </summary>
public class SpaBase
{
  /// <summary>
  /// Affected Server name.
  /// </summary>
  private static readonly string Servername0 = Environment.MachineName; // Dns.GetHostName();

  /// <summary>
  /// Gets server name.
  /// </summary>
  public static string Servername => Servername0;

  /// <summary>
  /// Gets shared path.
  /// </summary>
  public static string SharedPath { get; private set; } = Path.GetTempPath();

  /// <summary>
  /// Gets temporary path.
  /// </summary>
  public static string TempPath { get; private set; } = Path.GetTempPath();

  /// <summary>
  /// Sets values for static variables.
  /// </summary>
  /// <param name="sharedpath">Affected shared path.</param>
  /// <param name="temppath">Affected temporary path.</param>
  public static void SetValues(string? sharedpath, string? temppath)
  {
    if (!string.IsNullOrEmpty(sharedpath))
      SharedPath = sharedpath;
    if (!string.IsNullOrEmpty(temppath))
      TempPath = temppath;
  }
}
