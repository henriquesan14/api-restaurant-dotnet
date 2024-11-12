using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Core.Entities;

namespace Restaurant.Infra.Mappings
{
    public class StockMovementConfiguration : IEntityTypeConfiguration<StockMovement>
    {
        public void Configure(EntityTypeBuilder<StockMovement> builder)
        {
            builder.ToTable("StockMovements");
            // Configuração da chave primária
            builder.HasKey(sm => sm.Id);

            
            builder.HasOne(sm => sm.Product)
                .WithMany(sp => sp.StockMovements)
                .HasForeignKey(sm => sm.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuração das propriedades
            builder.Property(sm => sm.Quantity)
                .HasColumnType("decimal(18,2)") // Precisão da quantidade
                .IsRequired();

            builder.Property(sm => sm.MovementDate)
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            // Configuração do tipo de movimento (supondo que seja um Enum)
            builder.Property(sm => sm.MovementType)
                .IsRequired();

            // Index para otimizar consultas baseadas em StockProductId e MovementDate
            builder.HasIndex(sm => new { sm.ProductId, sm.MovementDate });
        }
    }
}
