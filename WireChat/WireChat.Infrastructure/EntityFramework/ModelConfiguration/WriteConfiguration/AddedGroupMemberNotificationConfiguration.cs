using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WireChat.Domain.ValueObjects;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionConverters;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;

namespace WireChat.Infrastructure.EntityFramework.ModelConfiguration.WriteConfiguration
{
    internal sealed class AddedGroupMemberNotificationConfiguration : IEntityTypeConfiguration<AddedGroupMemberNotification>
    {
        private readonly IEncryptionProvider _encryptionProvider;

        public AddedGroupMemberNotificationConfiguration(IEncryptionProvider encryptionProvider)
        {
            _encryptionProvider = encryptionProvider;
        }

        public void Configure(EntityTypeBuilder<AddedGroupMemberNotification> builder)
        {
            // Table name
            builder.ToTable("AddedGroupMemberNotification");

            // Composite primary key
            builder.HasKey(key => new { key.GroupAdminUserId, key.GroupMemberUserId });

            // Property config - Start

            builder.Property(p => p.GroupAdminUserId)
                .HasConversion(id => id.Value.ToString(), id => new UserID(Guid.Parse(id)))
                .IsRequired();

            builder.Property(p => p.GroupMemberUserId)
                .HasConversion(id => id.Value.ToString(), id => new UserID(Guid.Parse(id)))
                .IsRequired();

            builder.Property(p => p.GroupId)
               .HasConversion(id => id.Value, id => new GroupID(id))
               .IsRequired();

            builder.Property(typeof(DateTimeOffset), "DateTime")
                .HasConversion(new EncryptedDateTimeOffsetConverter(_encryptionProvider))
                .IsRequired();

            // Property config - End
        }
    }
}
