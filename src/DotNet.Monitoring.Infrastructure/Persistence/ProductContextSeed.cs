using DotNet.Monitoring.Contracts.Entities;
using Microsoft.Extensions.Logging;

namespace DotNet.Monitoring.Infrastructure.Persistence;

public class ProductContextSeed
{
  public static async Task SeedAsync(ProductContext orderContext, ILogger<ProductContextSeed> logger)
  {
    if (!orderContext.Products.Any())
    {
      await orderContext.Products.AddRangeAsync(GetPreconfiguredOrders());
      await orderContext.SaveChangesAsync();

      logger.LogInformation($"Seed database associated with context {nameof(ProductContext)}");
    }
  }

  private static IEnumerable<Product> GetPreconfiguredOrders()
  {
    return new List<Product>
    {
      new()
      {
        Name = "Product 1",
        Description = "Product 1 Description",
        Price = 649.99,
        ShortDescription = "Product 1 Short desc"
      },new()
      {
        Name = "Product 2",
        Description = "Product 2 Description",
        Price = 199.49,
        ShortDescription = "Product 2 Short desc"
      },new()
      {
        Name = "Product 3",
        Description = "Product 3 Description",
        Price = 149.99,
        ShortDescription = "Product 3 Short desc"
      },new()
      {
        Name = "Product 4",
        Description = "Product 4 Description",
        Price = 759.99,
        ShortDescription = "Product 4 Short desc"
      }
    };
  }
}