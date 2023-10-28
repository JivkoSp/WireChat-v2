using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionConverters;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.EntityFramework.ModelConfiguration.ReadConfiguration
{
    internal sealed class RemovedGroupMemberNotificationConfiguration
        : IEntityTypeConfiguration<RemovedGroupMemberNotificationReadModel>
    {
        private readonly IEncryptionProvider _encryptionProvider;

        public RemovedGroupMemberNotificationConfiguration(IEncryptionProvider encryptionProvider)
        {
            _encryptionProvider = encryptionProvider;
        }

        public void Configure(EntityTypeBuilder<RemovedGroupMemberNotificationReadModel> builder)
        {
            // Table name
            builder.ToTable("RemovedGroupMemberNotification");

            // Composite primary key
            builder.HasKey(key => new { key.GroupAdminUserId, key.GroupMemberUserId });

            // Property config
            builder.Property(p => p.DateTime)
                .HasConversion(new EncryptedDateTimeOffsetConverter(_encryptionProvider))
                .IsRequired();

            // Relationships
            builder.HasOne(p => p.NotificationHub)
               .WithMany(p => p.RemovedGroupMemberNotifications)
               .HasForeignKey(p => p.NotificationHubId)
               .HasConstraintName("FK_NotificationHub_RemovedGroupMemberNotifications")
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Group)
                .WithMany(p => p.RemovedGroupMemberNotifications)
                .HasForeignKey(p => p.GroupId)
                .HasConstraintName("FK_Group_RemovedGroupMemberNotifications")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.GroupAdmin)
                .WithMany(p => p.GroupAdminRemovedGroupMemberNotifications)
                .HasForeignKey(p => p.GroupAdminUserId)
                .HasConstraintName("FK_GroupAdmin_GroupAdminRemovedGroupMemberNotifications")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.GroupMember)
                .WithMany(p => p.GroupMemberRemovedGroupMemberNotifications)
                .HasForeignKey(p => p.GroupMemberUserId)
                .HasConstraintName("FK_GroupMember_GroupMemberRemovedGroupMemberNotifications")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
