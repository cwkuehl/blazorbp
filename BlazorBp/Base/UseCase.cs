// <copyright file="UseCase.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Base;

/// <summary>
/// Die Klasse speichert einen UseCase mit Formularen.
/// </summary>
[Serializable]
public class UseCase
{
  /// <summary>Holt oder setzt die betroffene ID, d.h. Action mit evtl. unterscheidender Nummer.</summary>
  public string? Id { get; set; }

  /// <summary>Holt oder setzt den Namen des Use case.</summary>
  public string? Name { get; set; }

  /// <summary>Holt die betroffenen Formulare.</summary>
  public List<Formular> Formulare { get; set; } = new List<Formular>();

  /// <summary>
  /// Liefert Formular innerhalb des Use case, das eine Action und eine ID enthalten.
  /// </summary>
  /// <param name="action">Name der Action, Formularname.</param>
  /// <param name="id">ID bzw. Parameter des Formulars.</param>
  /// <returns>Formular oder null.</returns>
  public Formular? GetFormular(string action, string? id = null)
  {
    if (string.IsNullOrEmpty(action))
      return null;

    action = action.ToLower();
    foreach (var f in Formulare)
    {
      if (f.Action == action && f.Id == id)
        return f;
    }
    return null;
  }
}
