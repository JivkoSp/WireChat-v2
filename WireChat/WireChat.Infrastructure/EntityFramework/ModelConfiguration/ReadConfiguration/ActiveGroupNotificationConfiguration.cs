using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.EntityFramework.ModelConfiguration.ReadConfiguration
{
    internal sealed class ActiveGroupNotificationConfiguration : IEntityTypeConfiguration<ActiveGroupNotificationReadModel>
    {
        public void Configure(EntityTypeBuilder<ActiveGroupNotificationReadModel> builder)
        {
            // Table name
            builder.ToTable("ActiveGroupNotification");

            // Primary key
            builder.HasKey(key => key.ActiveGroupNotificationId);

            // Relationships
            builder.HasOne(p => p.NotificationHub)
               .WithMany(p => p.ActiveGroupNotifications)
               .HasForeignKey(p => p.NotificationHubId)
               .HasConstraintName("FK_NotificationHub_ActiveGroupNotifications")
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Group)
                .WithMany(p => p.ActiveGroupNotifications)
                .HasForeignKey(p => p.GroupId)
                .HasConstraintName("FK_Group_ActiveGroupNotifications")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
