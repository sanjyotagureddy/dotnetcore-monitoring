using Microsoft.Extensions.DependencyInjection;

namespace DotNet.Monitoring.AssemblyScanning.Container.Attributes;

public class InjectableAttribute : Attribute
{
  public ServiceLifetime Lifetime { get; }
  public InjectableAttribute(ServiceLifetime lifeTime = ServiceLifetime.Transient)
  {
    Lifetime = lifeTime;
  }
}