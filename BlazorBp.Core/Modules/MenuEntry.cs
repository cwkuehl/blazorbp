namespace BlazorBp.Core.Modules;

public record MenuEntry(string Text, string Route, string? Icon = null, string? RequiredRole = null);