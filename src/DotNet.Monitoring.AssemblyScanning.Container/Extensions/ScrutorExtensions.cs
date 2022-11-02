using DotNet.Monitoring.AssemblyScanning.Container.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace DotNet.Monitoring.AssemblyScanning.Container.Extensions;

public static class ScrutorExtensions
{
  public static IImplementationTypeSelector InjectableAttributes(this IImplementationTypeSelector selector)
  {
    var lifeTimes = Enum.GetValues(typeof(ServiceLifetime)).Cast<ServiceLifetime>();

    return lifeTimes.Aggregate(selector, (current, item) => current.InjectableAttribute(item));
  }

  public static IImplementationTypeSelector InjectableAttribute(this IImplementationTypeSelector selector, ServiceLifetime lifeTime)
  {
    return selector.AddClasses(c => c.WithAttribute<InjectableAttribute>(i => i.Lifetime == lifeTime))
      .AsImplementedInterfaces()
      .WithLifetime(lifeTime);
  }
}