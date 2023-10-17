using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionConverters;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.EntityFramework.ModelConfiguration.ReadConfiguration
{
    internal sealed class AddedGroupMemberNotificationConfiguration : IEntityTypeConfiguration<AddedGroupMemberNotificationReadModel>
    {
        private readonly IEncryptionProvider _encryptionProvider;

        public AddedGroupMemberNotificationConfiguration(IEncryptionProvider encryptionProvider)
        {
            _encryptionProvider = encryptionProvider;
        }

        public void Configure(EntityTypeBuilder<AddedGroupMemberNotificationReadModel> builder)
        {
            // Table name
            builder.ToTable("AddedGroupMemberNotification");

            // Composite primary key
            builder.HasKey(key => new { key.GroupAdminUserId, key.GroupMemberUserId });

            // Property config
            builder.Property(p => p.DateTime)
                .HasConversion(new EncryptedDateTimeOffsetConverter(_encryptionProvider))
                .IsRequired();

            // Relationships
            builder.HasOne(p => p.Group)
               .WithMany(p => p.AddedGroupMemberNotifications)
               .HasForeignKey(p => p.GroupId)
               .HasConstraintName("FK_Group_AddedGroupMemberNotifications")
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.GroupAdmin)
                .WithMany(p => p.GroupAdminAddedGroupMemberNotifications)
                .HasForeignKey(p => p.GroupAdminUserId)
                .HasConstraintName("FK_GroupAdmin_GroupAdminAddedGroupMemberNotifications")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.GroupMember)
                .WithMany(p => p.GroupMemberAddedGroupMemberNotifications)
                .HasForeignKey(p => p.GroupMemberUserId)
                .HasConstraintName("FK_GroupMember_GroupMemberAddedGroupMemberNotifications")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
