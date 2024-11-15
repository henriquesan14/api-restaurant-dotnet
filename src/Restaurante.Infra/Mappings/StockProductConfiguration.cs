using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Core.Entities;

namespace Restaurant.Infra.Mappings
{
    public class StockProductConfiguration : IEntityTypeConfiguration<StockProduct>
    {
        public void Configure(EntityTypeBuilder<StockProduct> builder)
        {
            builder.ToTable("StockProducts");
            // Configuração da chave primária
            builder.HasKey(sp => sp.Id);

            builder.HasOne(ps => ps.Product)
            .WithOne(p => p.StockProduct)
            .HasForeignKey<StockProduct>(ps => ps.ProductId);

            // Configuração das propriedades
            builder.Property(sp => sp.QuantityInStock)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(sp => sp.MinimumStock)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.HasMany(ps => ps.StockMovements)
                .WithOne(sm => sm.StockProduct)
                .HasForeignKey(sm => sm.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
