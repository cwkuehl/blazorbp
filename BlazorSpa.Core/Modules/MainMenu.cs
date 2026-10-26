// <copyright file="MainMenu.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorSpa.Core.Modules;

/// <summary>
/// Klasse für die Definition des Hauptmenüs.
/// </summary>
/// <param name="Key">Betroffener Schlüssel.</param>
/// <param name="SortOrder">Betroffene Sortierreihenfolge.</param>
/// <param name="SubKey">Betroffener Unterschlüssel.</param>
/// <param name="Icon">Icon für das Menüelement.</param>
/// <param name="Expanded">Gibt an, ob das Menüelement erweitert ist.</param>
/// <param name="RequiredRoles">Erforderliche Rollen für den Zugriff auf das Menüelement.</param>
/// <param name="Entries">Die Einträge des Hauptmenüs.</param>
public record MainMenu(string Key, int SortOrder, string SubKey, string Icon, bool Expanded,
  IEnumerable<string> RequiredRoles, IEnumerable<MenuEntry> Entries);
