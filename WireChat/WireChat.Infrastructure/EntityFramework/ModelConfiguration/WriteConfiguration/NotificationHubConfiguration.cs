using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Infrastructure.EntityFramework.ModelConfiguration.WriteConfiguration
{
    internal sealed class NotificationHubConfiguration : IEntityTypeConfiguration<NotificationHub>
    {
        public void Configure(EntityTypeBuilder<NotificationHub> builder)
        {
            // Table name
            builder.ToTable("NotificationHub");

            // Primary key
            builder.HasKey(key => key.Id);

            // Property config
            builder.Property(p => p.Id)
                .HasConversion(id => id.Value, id => new NotificationHubID(id))
                .HasColumnName("NotificationHubId")
                .IsRequired();

            // Relationships
            builder.HasMany(p => p.IssuedContactRequestNotifications)
                .WithOne()
                .HasForeignKey("NotificationHubId")
                .HasConstraintName("FK_NotificationHub_IssuedContactRequestNotifications")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.ReceivedContactRequestNotifications)
                .WithOne()
                .HasForeignKey("NotificationHubId")
                .HasConstraintName("FK_NotificationHub_ReceivedContactRequestNotifications")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.AcceptedContactRequestNotifications)
                .WithOne()
                .HasForeignKey("NotificationHubId")
                .HasConstraintName("FK_NotificationHub_AcceptedContactRequestNotifications")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.DeclinedContactRequestNotifications)
                .WithOne()
                .HasForeignKey("NotificationHubId")
                .HasConstraintName("FK_NotificationHub_DeclinedContactRequestNotifications")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.ActiveGroupNotifications)
                .WithOne()
                .HasForeignKey("NotificationHubId")
                .HasConstraintName("FK_NotificationHub_ActiveGroupNotifications")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.AddedGroupMemberNotifications)
                .WithOne()
                .HasForeignKey("NotificationHubId")
                .HasConstraintName("FK_NotificationHub_AddedGroupMemberNotifications")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.RemovedGroupMemberNotifications)
                .WithOne()
                .HasForeignKey("NotificationHubId")
                .HasConstraintName("FK_NotificationHub_RemovedGroupMemberNotifications")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.BannedContactNotifications)
                .WithOne()
                .HasForeignKey("NotificationHubId")
                .HasConstraintName("FK_NotificationHub_BannedContactNotifications")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.BannedGroupMemberNotifications)
                .WithOne()
                .HasForeignKey("NotificationHubId")
                .HasConstraintName("FK_NotificationHub_BannedGroupMemberNotifications")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.CreatedGroupNotifications)
                .WithOne()
                .HasForeignKey("NotificationHubId")
                .HasConstraintName("FK_NotificationHub_CreatedGroupNotifications")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.RemovedChatMessageNotifications)
                .WithOne()
                .HasForeignKey("NotificationHubId")
                .HasConstraintName("FK_NotificationHub_RemovedChatMessageNotifications")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
