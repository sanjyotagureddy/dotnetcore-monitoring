using DotNet.Monitoring.Infrastructure;
using DotNet.Monitoring.Services.Mapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotNet.Monitoring.Services;

public static class ModuleRegistration
{
  public static IServiceCollection RegisterServicesModule(this IServiceCollection services, IConfiguration configuration)
  {
    services.RegisterInfrastructureServices(configuration);
    services.AddAutoMapper(typeof(ProfileMapper).Assembly);
    return services;
  }
}