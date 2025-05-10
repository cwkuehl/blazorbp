// <copyright file="ListItem.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Models;

/// <summary>Ein Eintrag in einer Liste.</summary>
/// <param name="Key">Betroffener Schlüssel.</param>
/// <param name="Value">Betroffener Wert.</param>
public record ListItem(string Key, string Value);
