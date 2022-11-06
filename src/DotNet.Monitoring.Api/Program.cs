using System;
using DotNet.Monitoring.Api.Extensions;
using DotNet.Monitoring.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Formatting.Json;
using Serilog.Sinks.Elasticsearch;

namespace DotNet.Monitoring.Api;

public class Program
{
  public static void Main(string[] args)
  {
    var host = CreateHostBuilder(args).Build();
    host.MigrateDatabase<ProductContext>((context, service) =>
      {
        var logger = service.GetService<ILogger<ProductContextSeed>>();
        ProductContextSeed
          .SeedAsync(context, logger)
          .Wait();
      }).Run();
  }

  public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
      .UseSerilog((context, configuration) =>
      {
        configuration.Enrich.FromLogContext()
          .ReadFrom.Configuration(context.Configuration)
          .Enrich.WithMachineName()
          .WriteTo.Console(outputTemplate: "[{SourceContext}]{NewLine}{Timestamp:ddMMyyyy HH:mm:ss} {Level:u4}] {Message:lj}{NewLine}{Exception}")
          .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(context.Configuration["ElasticConfiguration:Uri"]))
          {
            IndexFormat = $"{context.Configuration["ApplicationName"]}-logs-{context.HostingEnvironment.EnvironmentName?.ToLower().Replace(".", "-")}-{DateTime.Now:yyyy-MM}",
            AutoRegisterTemplate = true,
            NumberOfShards = 2,
            NumberOfReplicas = 1
          })
          .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName ?? "Development")
          .WriteTo.File(new JsonFormatter(), "Logs\\logs.txt");
      })
      .ConfigureWebHostDefaults(webBuilder =>
      {
        webBuilder.UseStartup<Startup>();
      });
}