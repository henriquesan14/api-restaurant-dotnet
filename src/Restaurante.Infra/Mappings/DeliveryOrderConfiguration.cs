using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Core.Entities;

namespace Restaurant.Infra.Mappings
{
    public class DeliveryOrderConfiguration : IEntityTypeConfiguration<DeliveryOrder>
    {
        public void Configure(EntityTypeBuilder<DeliveryOrder> builder)
        {
            builder.ToTable("Orders");

            builder.Property(o => o.DeliveryStatus).IsRequired();

            builder.HasOne(d => d.Address)
               .WithMany(d => d.Orders)
               .HasForeignKey(d => d.AddressId)
               .IsRequired();
        }
    }
}
