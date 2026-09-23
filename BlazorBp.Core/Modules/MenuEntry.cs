namespace BlazorBp.Core.Modules;

public record MenuEntry(string Text, string Description, string Route, string? Icon = null, string? RequiredRole = null);
