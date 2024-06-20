using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Core.Entities;

namespace Restaurant.Infra.Mappings
{
    public class OrderItemMapping : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");

            builder.HasKey(oi => oi.Id);
            builder.Property(oi => oi.Quantity).IsRequired();
            builder.Property(oi => oi.Status).IsRequired();

            builder.HasOne(oi => oi.Product)
                   .WithMany()
                   .HasForeignKey(oi => oi.ProductId)
                   .IsRequired();

            builder.HasOne(oi => oi.Order)
                   .WithMany(o => o.Items) // Assume que Order possui uma propriedade ICollection<OrderItem> Items
                   .HasForeignKey(oi => oi.OrderId)
                   .IsRequired();

            // Ignorar a serialização circular com Order e Product usando JsonIgnore
            //builder.Navigation(oi => oi.Product).AutoInclude();
            //builder.Navigation(oi => oi.Order).AutoInclude();
        }
    }
}
