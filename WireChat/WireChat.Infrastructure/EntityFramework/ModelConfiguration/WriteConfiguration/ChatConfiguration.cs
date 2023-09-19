
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionConverters;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;

namespace WireChat.Infrastructure.EntityFramework.ModelConfiguration.WriteConfiguration
{
    internal sealed class ChatConfiguration : IEntityTypeConfiguration<Chat>
    {
        private readonly IEncryptionProvider _encryptionProvider;

        public ChatConfiguration(IEncryptionProvider encryptionProvider)
        {
            _encryptionProvider = encryptionProvider;
        }

        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            // Table name
            builder.ToTable("Chat");

            // Primary key
            builder.HasKey(key => key.Id);

            // Property config
            builder.Property(p => p.Id)
                .HasConversion(id => id.Value, id => new ChatID(id))
                .HasColumnName("ChatId")
                .IsRequired();

            builder.Property(typeof(ChatType), "_chatType")
                .HasConversion(new EncryptedChatTypeConverter(_encryptionProvider))
                .HasColumnName("ChatType")
                .IsRequired();

            // Relationships
            builder.HasMany(p => p.Users);

            builder.HasMany(p => p.Messages);
        }
    }
}
