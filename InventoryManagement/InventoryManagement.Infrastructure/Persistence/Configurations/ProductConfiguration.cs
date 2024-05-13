using InventoryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Infrastructure.Persistence.Configurations;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product));
        builder.HasKey(p => p.Id);

        builder
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);

        builder
            .Property(p => p.Name)
            .HasMaxLength(ConfigurationConstants.DEFAULT_STRING_LENGTH)
            .IsRequired();
        builder
            .Property(p => p.Description)
            .HasMaxLength(ConfigurationConstants.LARGE_STRING_LENGTH)
            .IsRequired(false);
        builder
            .Property(p => p.Price)
            .HasColumnType("money");
        builder
            .Property(p => p.ExpireDate)
            .HasColumnType("date");
    }
}
