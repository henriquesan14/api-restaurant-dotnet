using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Core.Entities;

namespace Restaurant.Infra.Mappings
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(d => d.Id);

            builder.HasOne(p => p.Category)
            .WithMany(pc => pc.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

            // Configuração das propriedades
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.Description)
                .HasMaxLength(1000);

            builder.Property(p => p.QuantityInStock)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(sp => sp.MinimumStock)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.UnitOfMeasure)
                .HasMaxLength(50);

            builder.HasOne(p => p.StockProduct)
            .WithOne(ps => ps.Product)
            .HasForeignKey<StockProduct>(ps => ps.ProductId);

            // Relacionamento entre Product e MenuItemProduct (supondo que MenuItemProduct seja outra entidade)
            builder.HasMany(p => p.MenuItemProducts)
                .WithOne(mip => mip.Product)
                .HasForeignKey(mip => mip.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
