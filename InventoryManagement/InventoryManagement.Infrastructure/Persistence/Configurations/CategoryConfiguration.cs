using InventoryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.Persistence.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(nameof(Category));
            builder.HasKey(c => c.Id);

            builder
                .HasOne(c => c.Parent)
                .WithMany(ch => ch.Children)
                .HasForeignKey(c => c.ParentId);
            builder
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            builder
                .Property(c => c.Name)
                .HasMaxLength(ConfigurationConstants.DEFAULT_STRING_LENGTH)
                .IsRequired();
            builder
                .Property(c => c.Description)
                .HasMaxLength(ConfigurationConstants.LARGE_STRING_LENGTH)
                .IsRequired(false);
        }
    }
}
