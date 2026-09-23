namespace BlazorBp.Core.Modules;

using Microsoft.Extensions.DependencyInjection;

public interface IFormModule
{
    /// Eindeutiger Schlüssel, z.B. "Ag", "Demo"
    string Key { get; }

    /// Menüeinträge, die dieses Modul beisteuert
    IEnumerable<MenuEntry> GetMenuEntries();

    /// Rollen, die für den Zugriff auf dieses Modul nötig sind
    IEnumerable<string> RequiredRoles { get; }

    /// DI-Registrierung modul-eigener Services
    void ConfigureServices(IServiceCollection services);
}