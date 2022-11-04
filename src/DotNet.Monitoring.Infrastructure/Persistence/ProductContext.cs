using DotNet.Monitoring.Contracts.Entities;
using DotNet.Monitoring.Contracts.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace DotNet.Monitoring.Infrastructure.Persistence;

public class ProductContext : DbContext
{
  public ProductContext(DbContextOptions<ProductContext> options) : base(options)
  {
  }

  public DbSet<Product> Products { get; set; }

  public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    foreach (var entry in ChangeTracker.Entries<BaseEntity>())
    {
      switch (entry.State)
      {
        case EntityState.Added:
          entry.Entity.CreatedDate = DateTime.Now;
          entry.Entity.CreatedBy = "sanjyot";
          break;

        case EntityState.Modified:
          entry.Entity.LastModifiedDate = DateTime.Now;
          entry.Entity.LastModifiedBy = "sanjyot";
          break;
      }
    }
    return base.SaveChangesAsync(cancellationToken);
  }

}