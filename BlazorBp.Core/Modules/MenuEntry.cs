// <copyright file="MenuEntry.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Core.Modules;

public record MenuEntry(string Text, string Description, string Route, string? Icon = null, string? RequiredRole = null);
