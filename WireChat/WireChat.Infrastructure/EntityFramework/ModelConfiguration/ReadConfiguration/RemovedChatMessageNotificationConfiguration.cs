using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionConverters;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.EntityFramework.ModelConfiguration.ReadConfiguration
{
    internal sealed class RemovedChatMessageNotificationConfiguration
        : IEntityTypeConfiguration<RemovedChatMessageNotificationReadModel>
    {
        private readonly IEncryptionProvider _encryptionProvider;

        public RemovedChatMessageNotificationConfiguration(IEncryptionProvider encryptionProvider)
        {
            _encryptionProvider = encryptionProvider;
        }

        public void Configure(EntityTypeBuilder<RemovedChatMessageNotificationReadModel> builder)
        {
            // Table name
            builder.ToTable("RemovedChatMessageNotification");

            // Composite primary key
            builder.HasKey(key => new { key.ChatId, key.ChatMessageId });

            // Property config
            builder.Property(p => p.DateTime)
                .HasConversion(new EncryptedDateTimeOffsetConverter(_encryptionProvider))
                .IsRequired();

            // Relationships
            builder.HasOne(p => p.Chat)
                .WithMany(p => p.RemovedChatMessageNotifications)
                .HasForeignKey(p => p.ChatId)
                .HasConstraintName("FK_Chat_RemovedChatMessageNotifications")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.ChatMessage)
                .WithOne()
                .HasForeignKey<RemovedChatMessageNotificationReadModel>(p => p.ChatMessageId)
                .HasConstraintName("FK_ChatMessage_RemovedChatMessageNotification")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.User)
                .WithMany(p => p.RemovedChatMessageNotifications)
                .HasForeignKey(p => p.UserId)
                .HasConstraintName("FK_User_RemovedChatMessageNotifications")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
