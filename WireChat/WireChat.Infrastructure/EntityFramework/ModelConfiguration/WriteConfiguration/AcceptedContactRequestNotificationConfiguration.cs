using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WireChat.Domain.ValueObjects;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionConverters;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;

namespace WireChat.Infrastructure.EntityFramework.ModelConfiguration.WriteConfiguration
{
    internal sealed class AcceptedContactRequestNotificationConfiguration
        : IEntityTypeConfiguration<AcceptedContactRequestNotification>
    {
        private readonly IEncryptionProvider _encryptionProvider;

        public AcceptedContactRequestNotificationConfiguration(IEncryptionProvider encryptionProvider)
        {
            _encryptionProvider = encryptionProvider;
        }

        public void Configure(EntityTypeBuilder<AcceptedContactRequestNotification> builder)
        {
            // Table name
            builder.ToTable("AcceptedContactRequestNotification");

            // Composite primary key
            builder.HasKey(key => new { key.SenderUserId, key.ReceiverUserId });

            // Property config - Start

            builder.Property(p => p.SenderUserId)
                .HasConversion(id => id.Value.ToString(), id => new UserID(Guid.Parse(id)))
                .IsRequired();

            builder.Property(p => p.ReceiverUserId)
                .HasConversion(id => id.Value.ToString(), id => new UserID(Guid.Parse(id)))
                .IsRequired();

            builder.Property(typeof(DateTimeOffset), "DateTime")
                .HasConversion(new EncryptedDateTimeOffsetConverter(_encryptionProvider))
                .IsRequired();

            // Property config - End
        }
    }
}
