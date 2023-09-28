using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WireChat.Domain.ValueObjects;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionConverters;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;

namespace WireChat.Infrastructure.EntityFramework.ModelConfiguration.WriteConfiguration
{
    internal sealed class ChatMessageConfiguration : IEntityTypeConfiguration<ChatMessage>
    {
        private readonly IEncryptionProvider _encryptionProvider;

        public ChatMessageConfiguration(IEncryptionProvider encryptionProvider)
        {
            _encryptionProvider = encryptionProvider;
        }

        public void Configure(EntityTypeBuilder<ChatMessage> builder)
        {
            // Table name
            builder.ToTable("ChatMessage");

            // Primary key
            builder.HasKey(key => key.ChatMessageID);

            // Property config - Start

            builder.Property(p => p.ChatMessageID)
                .HasConversion(id => id.Value, id => new ChatMessageID(id))
                .HasColumnName("ChatMessageId")
                .IsRequired();

            builder.Property(p => p.ChatID)
                .HasConversion(id => id.Value, id => new ChatID(id))
                .HasColumnName("ChatId")
                .IsRequired();

            builder.Property(p => p.UserID)
                .HasConversion(id => id.Value.ToString(), id => new UserID(Guid.Parse(id)))
                .HasColumnName("UserId")
                .IsRequired();  

            builder.Property(typeof(string), "Message")
                .HasConversion(new EncryptedStringConverter(_encryptionProvider))
                .IsRequired();

            builder.Property(typeof(DateTimeOffset), "DateTime")
                .HasConversion(new EncryptedDateTimeOffsetConverter(_encryptionProvider))
                .HasColumnName("MessageDateTime")
                .IsRequired();

            // Property config - End
        }
    }
}
