// <copyright file="Formular.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Base;

using CSBP.Services.Base;

/// <summary>
/// Die Klasse speichert ein Formular mit Controller und Action.
/// </summary>
[Serializable]
public class Formular
{
    /// <summary>Holt oder setzt den Namen des Formulars.</summary>
    public string? Name { get; set; }

    /// <summary>Holt oder setzt die betroffene Action.</summary>
    public string? Action { get; set; }

    /// <summary>Holt oder setzt die betroffene Area.</summary>
    public string? Area { get; set; }

    /// <summary>Holt oder setzt die betroffene ID.</summary>
    public string? Id { get; set; }

    /// <summary>
    /// Liefert die URL für das Formular.
    /// </summary>
    /// <param name="id">Gibt an, ob die ID mit übergeben werden soll.</param>
    /// <param name="close">Gibt an, ob die Action mit ID geschlossen werden soll.</param>
    /// <returns>URL für das Formular.</returns>
    internal string GetHref(bool id = false, bool close = false)
    {
      if (close)
        return $"/close/{Action}/{Id}";
      return $"{Functions.Iif(string.IsNullOrEmpty(Area), "", $"/{Area}")}/{Action}{Functions.Iif(string.IsNullOrEmpty(Id) || !id, "", $"/{Id}")}";
    }
}
