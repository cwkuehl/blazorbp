namespace BlazorBp.Forms.Demo;

using BlazorBp.Core.Modules;
using BlazorBp.Forms.Demo.Apis;
using BlazorBp.Forms.Demo.Impl;
using Microsoft.Extensions.DependencyInjection;

public class DemoModule : IFormModule
{
    public string Key => "Demo";

    public IEnumerable<string> RequiredRoles => ["User"];

    public IEnumerable<MenuEntry> GetMenuEntries() =>
    [
        new("SSR testen", "/demo/dm010"),
    ];

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddSingleton<IDemoService, DemoService>();
    }
}