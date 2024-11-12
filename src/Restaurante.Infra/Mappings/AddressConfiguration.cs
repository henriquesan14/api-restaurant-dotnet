using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Core.Entities;

namespace Restaurant.Infra.Mappings
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Street)
                    .IsRequired()
                    .HasMaxLength(200);
            builder.Property(d => d.Number)
                    .IsRequired()
                    .HasMaxLength(10);
            builder.Property(d => d.District)
                    .IsRequired()
                    .HasMaxLength(100);
            builder.Property(d => d.ZipCode)
                    .IsRequired()
                    .HasMaxLength(8);
            builder.Property(d => d.Complement)
                    .HasMaxLength(300);

            builder.HasOne(d => d.City)
                .WithMany(p => p.Addresses)
                .HasForeignKey(a => a.CityId);

            builder.HasOne(d => d.User)
                .WithMany(p => p.Addresses)
                .HasForeignKey(a => a.CityId);

            builder.HasMany(d => d.Orders)
                .WithOne(d => d.Address)
                .HasForeignKey(d => d.AddressId);

        }
    }
}
