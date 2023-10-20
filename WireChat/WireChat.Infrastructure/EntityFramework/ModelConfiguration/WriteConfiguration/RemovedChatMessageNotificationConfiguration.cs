using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WireChat.Domain.ValueObjects;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionConverters;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;

namespace WireChat.Infrastructure.EntityFramework.ModelConfiguration.WriteConfiguration
{
    internal sealed class RemovedChatMessageNotificationConfiguration : IEntityTypeConfiguration<RemovedChatMessageNotification>
    {
        private readonly IEncryptionProvider _encryptionProvider;

        public RemovedChatMessageNotificationConfiguration(IEncryptionProvider encryptionProvider)
        {
            _encryptionProvider = encryptionProvider;
        }

        public void Configure(EntityTypeBuilder<RemovedChatMessageNotification> builder)
        {
            // Table name
            builder.ToTable("RemovedChatMessageNotification");

            // Composite primary key
            builder.HasKey(key => new { key.ChatId, key.ChatMessageId });

            // Property config
            builder.Property(p => p.ChatId)
                .HasConversion(id => id.Value, id => new ChatID(id))
                .IsRequired();

            builder.Property(p => p.ChatMessageId)
                .HasConversion(id => id.Value, id => new ChatMessageID(id))
                .IsRequired();

            builder.Property(p => p.UserId)
                .HasConversion(id => id.Value.ToString(), id => new UserID(Guid.Parse(id)))
                .IsRequired();

            builder.Property(typeof(DateTimeOffset), "DateTime")
               .HasConversion(new EncryptedDateTimeOffsetConverter(_encryptionProvider))
               .IsRequired();
        }
    }
}
