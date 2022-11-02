using DotNet.Monitoring.AssemblyScanning.Container.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace DotNet.Monitoring.AssemblyScanning.Container;

public static class ModuleRegistration
{
  public static IServiceCollection RegisterAssemblyScanningContainer(this IServiceCollection services)
  {
   services.Scan(i =>
      i.FromCallingAssembly()
        .InjectableAttribute(ServiceLifetime.Transient)
        .InjectableAttribute(ServiceLifetime.Scoped)
        .InjectableAttribute(ServiceLifetime.Singleton)
    );
    return services;
  }
}