using DotNet.Monitoring.Api.Middleware;
using DotNet.Monitoring.Common.Settings;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DotNet.Monitoring.Api;

public class Startup
{
  public Startup(IConfiguration configuration)
  {
    Configuration = configuration;
  }

  public IConfiguration Configuration { get; }

  // This method gets called by the runtime. Use this method to add services to the container.
  public void ConfigureServices(IServiceCollection services)
  {

    services.AddControllers();
    services.AddSwaggerGen(c =>
    {
      c.SwaggerDoc("v1", new OpenApiInfo { Title = "DotNet.Monitoring.Api", Version = "v1" });
    });
    var config = new ApiSettings();
    Configuration.Bind("ApiSettings", config);      //  <--- This
    services.AddSingleton(config);
    services.RegisterApiServices(Configuration);
  }

  // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    if (env.IsDevelopment())
    {
      app.UseDeveloperExceptionPage();
      app.UseSwagger();
      app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DotNet.Monitoring.Api v1"));
    }
    app.UseMiddleware<PayloadLoggingMiddleware>();
    app.UseHttpsRedirection();

    app.UseRouting();

    app.UseAuthorization();


    app.UseEndpoints(endpoints =>
    {
      endpoints.MapControllers();
    });
  }
}