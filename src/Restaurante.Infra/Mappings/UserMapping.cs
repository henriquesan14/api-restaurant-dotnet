using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Core.Entities;

namespace Restaurant.Infra.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.FirstName)
                    .IsRequired()
                    .HasMaxLength(200);
            builder.Property(d => d.LastName)
                    .IsRequired()
                    .HasMaxLength(10);
            builder.Property(d => d.Document)
                    .IsRequired()
                    .HasMaxLength(14);
            builder.Property(d => d.Email)
                    .IsRequired()
                    .HasMaxLength(200);
            builder.HasIndex(e => e.Email)
                    .IsUnique();
            builder.Property(d => d.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(11);
            builder.Property(d => d.Password)
                    .IsRequired()
                    .HasMaxLength(200);

            builder.HasOne(d => d.Role)
                .WithMany(p => p.Users)
                .HasForeignKey(a => a.RoleId);

            builder.HasMany(d => d.Addresses)
                .WithOne(p => p.User)
                .HasForeignKey(a => a.UserId);

            builder.HasMany(d => d.Orders)
                .WithOne(d => d.Client)
                .HasForeignKey(d => d.ClientId);
        }
    }
}
