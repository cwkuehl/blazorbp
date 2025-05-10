// <copyright file="FactoryServiceExtensions.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Base;

using CSBP.Services.NonService;
using Microsoft.Extensions.DependencyInjection;

/// <summary>Static class for extension methods.</summary>
public static class FactoryServiceExtensions
{
  /// <summary>Adds the FactoryService to service collection.</summary>
  /// <param name="services">Affected service collection.</param>
  /// <returns>Same service collection.</returns>
  public static IServiceCollection AddFactoryService(this IServiceCollection services)
  {
    // services.AddSingleton<IBudgetService, BudgetService>();
    // services.AddSingleton<IBudgetService>(sp => FactoryService.BudgetService);
    // services.AddSingleton<IClientService>(sp => FactoryService.ClientService);
    // foreach (var s in services)
    // {
    //   Console.WriteLine(s.ServiceType);
    // }
    return services;
  }

  /// <summary>Use the FactoryService for application builder.</summary>
  /// <param name="app">Affected application builder.</param>
  /// <returns>Same application builder.</returns>
  public static IApplicationBuilder UseFactoryService(this IApplicationBuilder app)
  {
    var httpClientFactory = app.ApplicationServices.GetService<IHttpClientFactory>();
    HttpClientFactory.SetHttpClientFactory(httpClientFactory);
    return app;
  }
}
