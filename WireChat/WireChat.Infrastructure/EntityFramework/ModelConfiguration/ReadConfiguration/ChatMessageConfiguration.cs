using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionConverters;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.EntityFramework.ModelConfiguration
{
    internal sealed class ChatMessageConfiguration : IEntityTypeConfiguration<ChatMessageReadModel>
    {
        private readonly IEncryptionProvider _encryptionProvider;

        public ChatMessageConfiguration(IEncryptionProvider encryptionProvider)
        {
            _encryptionProvider = encryptionProvider;
        }

        public void Configure(EntityTypeBuilder<ChatMessageReadModel> builder)
        {
            // Table name
            builder.ToTable("ChatMessage");

            // Primary key
            builder.HasKey(key => key.ChatMessageId);

            // Property config - Start

            builder.Property(p => p.Message)
                .HasConversion(new EncryptedStringConverter(_encryptionProvider))
                .IsRequired();

            builder.Property(p => p.MessageDateTime)
                .HasConversion(new EncryptedDateTimeOffsetConverter(_encryptionProvider))
                .IsRequired();

            // Property config - End

            // Relationships
            builder.HasOne(p => p.Chat)
                .WithMany(p => p.ChatMessages)
                .HasForeignKey(p => p.ChatId)
                .HasConstraintName("FK_Chat_ChatMessages")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.User)
                .WithMany(p => p.ChatMessages)
                .HasForeignKey(p => p.UserId)
                .HasConstraintName("FK_User_ChatMessages")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}