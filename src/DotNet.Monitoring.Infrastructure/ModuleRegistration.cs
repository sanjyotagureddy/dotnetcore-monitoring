
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotNet.Monitoring.Infrastructure;

public static class ModuleRegistration
{
  public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
  {
    //services.AddDbContext<ApplicationContext>(op =>
    //  op.UseSqlServer(configuration.GetConnectionString("Product")));
    return services;
  }
}