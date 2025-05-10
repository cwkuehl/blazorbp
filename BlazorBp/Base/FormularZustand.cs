// <copyright file="FormularZustand.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Base;

/// <summary>
/// Die Klasse speichert der Formular-Zustand mit allen Use cases.
/// </summary>
[Serializable]
public class FormularZustand
{
    /// <summary>Holt oder setzt die aktuelle Use case ID.</summary>
    public string? AktuellId { get; set; }

    /// <summary>Holt die betroffenen Formulare.</summary>
    public List<UseCase> UseCases { get; set; } = new List<UseCase>();

    /// <summary>
    /// Liefert Use case, die eine Action und eine ID enthalten.
    /// </summary>
    /// <param name="action">Name der Action, Formularname.</param>
    /// <param name="id">ID bzw. Parameter des Formulars.</param>
    /// <returns>Use case oder null.</returns>
    public UseCase? GetUseCaseAktion(string action, string? id = null)
    {
      if (string.IsNullOrEmpty(action))
        return null;

      foreach (UseCase uc in UseCases)
      {
        if (uc.GetFormular(action, id) != null)
          return uc;
      }
      return null;
    }
}
