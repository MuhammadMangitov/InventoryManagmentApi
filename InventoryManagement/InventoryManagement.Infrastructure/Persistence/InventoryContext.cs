using InventoryManagement.Domain.Entities;
using InventoryManagement.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure.Persistence;

public class InventoryContext : DbContext
{
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Product> Products { get; set; }

    public InventoryContext(DbContextOptions<InventoryContext> options) 
        : base(options)
    {
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfiguration).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
