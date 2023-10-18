using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionConverters;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.EntityFramework.ModelConfiguration.ReadConfiguration
{
    internal sealed class BannedGroupMemberNotificationConfiguration : IEntityTypeConfiguration<BannedGroupMemberNotificationReadModel>
    {
        private readonly IEncryptionProvider _encryptionProvider;

        public BannedGroupMemberNotificationConfiguration(IEncryptionProvider encryptionProvider)
        {
            _encryptionProvider = encryptionProvider;
        }

        public void Configure(EntityTypeBuilder<BannedGroupMemberNotificationReadModel> builder)
        {
            // Table name
            builder.ToTable("BannedGroupMemberNotification");

            // Composite primary key
            builder.HasKey(key => new { key.GroupAdminUserId, key.GroupMemberUserId });

            // Property config
            builder.Property(p => p.DateTime)
                .HasConversion(new EncryptedDateTimeOffsetConverter(_encryptionProvider))
                .IsRequired();

            // Relationships
            builder.HasOne(p => p.Group)
                .WithMany(p => p.BannedGroupMemberNotifications)
                .HasForeignKey(p => p.GroupId)
                .HasConstraintName("FK_Group_BannedGroupMemberNotifications")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.GroupAdmin)
                .WithMany(p => p.GroupAdminBannedGroupMemberNotifications)
                .HasForeignKey(p => p.GroupAdminUserId)
                .HasConstraintName("FK_GroupAdmin_GroupAdminBannedGroupMemberNotifications")
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.GroupMember)
                .WithMany(p => p.GroupMemberBannedGroupMemberNotifications)
                .HasConstraintName("FK_GroupMember_GroupMemberBannedGroupMemberNotifications")
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
