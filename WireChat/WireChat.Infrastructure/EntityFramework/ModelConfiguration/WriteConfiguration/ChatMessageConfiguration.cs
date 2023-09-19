using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WireChat.Domain.Entities;
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
            builder.HasKey(key => key.Id);

            // Property config - Start

            builder.Property(p => p.Id)
                .HasConversion(id => id.Value, id => new ChatMessageID(id))
                .HasColumnName("ChatMessageId")
                .IsRequired();

            builder.Property(typeof(UserID), "_userID")
                .HasConversion(new ValueConverter<UserID, string>(id => id.Value.ToString(), id => new UserID(Guid.Parse(id))))
                .HasColumnName("UserId")
                .IsRequired();  

            builder.Property(typeof(Message), "_message")
                .HasConversion(new EncryptedMessageConverter(_encryptionProvider))
                .HasColumnName("Message")
                .IsRequired();

            builder.Property(typeof(MessageDateTime), "_messageDateTime")
                .HasConversion(new EncryptedMessageDateTimeConverter(_encryptionProvider))
                .HasColumnName("MessageDateTime")
                .IsRequired();

            // Property config - End
        }
    }
}
