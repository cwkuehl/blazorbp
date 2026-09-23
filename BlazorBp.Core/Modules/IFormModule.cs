namespace BlazorBp.Core.Modules;

using Microsoft.Extensions.DependencyInjection;

public interface IFormModule
{
    /// Eindeutiger Schlüssel, z.B. "Demo"
    string Key { get; }

    // Default, überschreibbar
    int SortOrder => 100;
    
    /// Schlüssel für Untermenü, z.B. "submenudemo"
    string SubKey { get; }

    /// Icon für Untermenü, z.B. "bi bi-screwdriver-nav-menu"
    string Icon { get; }

    /// Gibt an, ob das Untermenü standardmäßig geöffnet sein soll.
    bool Expanded { get; }

    /// Menüeinträge, die dieses Modul beisteuert
    IEnumerable<MenuEntry> GetMenuEntries();

    /// Rollen, die für den Zugriff auf dieses Modul nötig sind
    IEnumerable<string> RequiredRoles { get; }

    /// DI-Registrierung modul-eigener Services
    void ConfigureServices(IServiceCollection services);
}