using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionConverters;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.EntityFramework.ModelConfiguration.ReadConfiguration
{
    internal sealed class ChatConfiguration : IEntityTypeConfiguration<ChatReadModel>
    {
        private readonly IEncryptionProvider _encryptionProvider;

        public ChatConfiguration(IEncryptionProvider encryptionProvider)
        {
            _encryptionProvider = encryptionProvider;
        }

        public void Configure(EntityTypeBuilder<ChatReadModel> builder)
        {
            // Table name
            builder.ToTable("Chat");

            // Primary key
            builder.HasKey(key => key.ChatId);

            // Property config
            builder.Property(p => p.ChatType)
                .HasConversion(new EncryptedStringConverter(_encryptionProvider))
                .IsRequired();
        }
    }
}