using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Core.Entities;

namespace Restaurant.Infra.Mappings
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notifications");
            builder.HasKey(c => c.Id);

            builder.Property(n => n.UserId)
                .IsRequired();

            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(c => c.Message)
                .IsRequired()
            .HasMaxLength(600);

            builder.Property(c => c.RedirectUrl)
                .IsRequired(false)
            .HasMaxLength(600);

            builder.Property(n => n.IsRead)
                .HasDefaultValue(false);
        }
    }
}
