using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Core.Entities;

namespace Restaurant.Infra.Mappings
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Name)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.HasOne(d => d.State)
                .WithMany(d => d.Cities)
                .HasForeignKey(d => d.StateId);

            builder.HasMany(d => d.Addresses)
                .WithOne(p => p.City)
                .HasForeignKey(a => a.CityId);
        }
    }
}
