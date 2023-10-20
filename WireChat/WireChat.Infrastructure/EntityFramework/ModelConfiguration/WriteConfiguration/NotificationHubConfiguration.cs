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
            builder.HasMany(p => p.IssuedContactRequestNotifications);
            builder.HasMany(p => p.ReceivedContactRequestNotifications);
            builder.HasMany(p => p.AcceptedContactRequestNotifications);
            builder.HasMany(p => p.DeclinedContactRequestNotifications);
            builder.HasMany(p => p.ActiveGroupNotifications);
            builder.HasMany(p => p.AddedGroupMemberNotifications);
            builder.HasMany(p => p.RemovedGroupMemberNotifications);
            builder.HasMany(p => p.BannedContactNotifications);
            builder.HasMany(p => p.BannedGroupMemberNotifications);
            builder.HasMany(p => p.CreatedGroupNotifications);
            builder.HasMany(p => p.RemovedChatMessageNotifications);
        }
    }
}
