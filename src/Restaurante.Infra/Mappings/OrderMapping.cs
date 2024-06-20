using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Core.Entities;

namespace Restaurant.Infra.Mappings
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.Id);
            builder.Property(o => o.Type).HasMaxLength(50).IsRequired();
            builder.Property(o => o.Status).IsRequired();
            builder.Property(o => o.ValueTotal).HasColumnType("decimal(18,2)").IsRequired();

            builder.HasOne(o => o.Client)
                   .WithMany()
                   .HasForeignKey(o => o.ClientId);

            builder.HasMany(o => o.Items)
                   .WithOne()
                   .HasForeignKey(oi => oi.OrderId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired();

            builder.HasDiscriminator<string>("OrderType")
                   .HasValue<Order>("Order")
                   .HasValue<DeliveryOrder>("DeliveryOrder")
                   .HasValue<CommonOrder>("CommonOrder");
        }
    }
}
