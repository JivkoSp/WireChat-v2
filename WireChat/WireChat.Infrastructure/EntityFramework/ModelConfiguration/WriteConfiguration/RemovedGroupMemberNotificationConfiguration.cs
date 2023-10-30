using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WireChat.Domain.ValueObjects;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionConverters;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;

namespace WireChat.Infrastructure.EntityFramework.ModelConfiguration.WriteConfiguration
{
    internal sealed class RemovedGroupMemberNotificationConfiguration : IEntityTypeConfiguration<RemovedGroupMemberNotification>
    {
        private readonly IEncryptionProvider _encryptionProvider;

        public RemovedGroupMemberNotificationConfiguration(IEncryptionProvider encryptionProvider)
        {
            _encryptionProvider = encryptionProvider;
        }

        public void Configure(EntityTypeBuilder<RemovedGroupMemberNotification> builder)
        {
            // Table name
            builder.ToTable("RemovedGroupMemberNotification");

            // Composite primary key
            builder.HasKey(key => new { key.GroupAdminUserId, key.GroupMemberUserId });

            // Property config
            builder.Property(p => p.GroupAdminUserId)
               .HasConversion(id => id.Value.ToString(), id => new UserID(Guid.Parse(id)))
               .IsRequired();

            builder.Property(p => p.GroupMemberUserId)
                .HasConversion(id => id.Value.ToString(), id => new UserID(Guid.Parse(id)))
                .IsRequired();

            builder.Property(p => p.GroupId)
                .HasConversion(id => id.Value, id => new GroupID(id))
                .IsRequired();

            builder.Property(p => p.NotificationHubId)
                .HasConversion(id => id.Value, id => new NotificationHubID(id))
                .IsRequired();

            builder.Property(typeof(DateTimeOffset), "DateTime")
               .HasConversion(new EncryptedDateTimeOffsetConverter(_encryptionProvider))
               .IsRequired();
        }
    }
}
