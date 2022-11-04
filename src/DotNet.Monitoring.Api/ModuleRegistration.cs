using DotNet.Monitoring.AssemblyScanning.Container;
using DotNet.Monitoring.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotNet.Monitoring.Api;

public static class ModuleRegistration
{
  public static IServiceCollection RegisterApiServices(this IServiceCollection services, IConfiguration configuration)
  {
    services.RegisterAssemblyScanningContainer();
    services.RegisterServicesModule(configuration);
    return services;
  }
}