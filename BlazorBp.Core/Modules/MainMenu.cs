// <copyright file="MainMenu.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Core.Modules;

public record MainMenu(string Key, int SortOrder, string SubKey, string Icon, bool Expanded,
  IEnumerable<string> RequiredRoles, IEnumerable<MenuEntry> Entries);
