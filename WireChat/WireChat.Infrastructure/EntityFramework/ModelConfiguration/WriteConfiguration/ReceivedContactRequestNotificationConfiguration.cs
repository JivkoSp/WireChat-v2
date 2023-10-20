using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WireChat.Domain.ValueObjects;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionConverters;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;

namespace WireChat.Infrastructure.EntityFramework.ModelConfiguration.WriteConfiguration
{
    internal sealed class ReceivedContactRequestNotificationConfiguration
        : IEntityTypeConfiguration<ReceivedContactRequestNotification>
    {
        private readonly IEncryptionProvider _encryptionProvider;

        public ReceivedContactRequestNotificationConfiguration(IEncryptionProvider encryptionProvider)
        {
            _encryptionProvider = encryptionProvider;
        }

        public void Configure(EntityTypeBuilder<ReceivedContactRequestNotification> builder)
        {
            // Table name
            builder.ToTable("ReceivedContactRequestNotification");

            // Composite primary key
            builder.HasKey(key => new { key.SenderUserId, key.ReceiverUserId });

            // Property config
            builder.Property(p => p.SenderUserId)
               .HasConversion(id => id.Value.ToString(), id => new UserID(Guid.Parse(id)))
               .IsRequired();

            builder.Property(p => p.ReceiverUserId)
                .HasConversion(id => id.Value.ToString(), id => new UserID(Guid.Parse(id)))
                .IsRequired();

            builder.Property(typeof(DateTimeOffset), "DateTime")
               .HasConversion(new EncryptedDateTimeOffsetConverter(_encryptionProvider))
               .IsRequired();
        }
    }
}
