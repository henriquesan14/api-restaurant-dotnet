using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Core.Entities;

namespace Restaurant.Infra.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Name)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.Property(d => d.CategoryType)
                    .IsRequired();

            builder.HasMany(d => d.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(a => a.CategoryId);
        }
    }
}
