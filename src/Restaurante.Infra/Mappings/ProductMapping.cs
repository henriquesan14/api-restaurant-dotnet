using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Core.Entities;

namespace Restaurant.Infra.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            builder.Property(d => d.Description)
                    .IsRequired()
                    .HasMaxLength(300);
            builder.Property(oi => oi.Price).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(d => d.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(300);

            builder.HasOne(d => d.Category)
                .WithMany(d => d.Products)
                .HasForeignKey(d => d.CategoryId);
        }
    }
}
