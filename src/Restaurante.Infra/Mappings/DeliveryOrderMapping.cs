using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Core.Entities;

namespace Restaurant.Infra.Mappings
{
    public class DeliveryOrderMapping : IEntityTypeConfiguration<DeliveryOrder>
    {
        public void Configure(EntityTypeBuilder<DeliveryOrder> builder)
        {
            builder.ToTable("Orders");

            builder.HasOne(d => d.Address)
               .WithMany(d => d.Orders)
               .HasForeignKey(d => d.AddressId)
               .IsRequired();
        }
    }
}
