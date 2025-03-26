using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Core.Entities;

namespace Restaurant.Infra.Mappings
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");

            builder.HasKey(oi => oi.Id);

            builder.Property(oi => oi.Quantity)
            .IsRequired()                          // Quantidade é obrigatória
            .HasDefaultValue(1);                   // Valor padrão de quantidade é 1

            builder.Property(oi => oi.Status)
                .IsRequired();                         // Status é obrigatório

            builder.Property(oi => oi.Observation)
                .HasMaxLength(500)                    // Definindo o comprimento máximo para a observação
                .IsRequired(false);

            // Definir a propriedade calculada (não é mapeada no banco, mas é utilizada no código)
            builder.Ignore(oi => oi.SubTotal);

            builder.HasOne(oi => oi.MenuItem)
                   .WithMany(mi => mi.OrderItems)
                   .HasForeignKey(oi => oi.MenuItemId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(oi => oi.Order)
                   .WithMany(o => o.Items) // Assume que Order possui uma propriedade ICollection<OrderItem> Items
                   .HasForeignKey(oi => oi.OrderId)
                   .IsRequired();

            
        }
    }
}
