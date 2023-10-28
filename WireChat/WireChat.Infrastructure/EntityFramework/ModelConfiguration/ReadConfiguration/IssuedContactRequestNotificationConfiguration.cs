using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionConverters;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.EntityFramework.ModelConfiguration.ReadConfiguration
{
    internal sealed class IssuedContactRequestNotificationConfiguration
        : IEntityTypeConfiguration<IssuedContactRequestNotificationReadModel>
    {
        private readonly IEncryptionProvider _encryptionProvider;

        public IssuedContactRequestNotificationConfiguration(IEncryptionProvider encryptionProvider)
        {
            _encryptionProvider = encryptionProvider;
        }

        public void Configure(EntityTypeBuilder<IssuedContactRequestNotificationReadModel> builder)
        {
            // Table name
            builder.ToTable("IssuedContactRequestNotification");

            // Composite primary key
            builder.HasKey(key => new { key.SenderUserId, key.ReceiverUserId });

            // Property config
            builder.Property(p => p.DateTime)
                .HasConversion(new EncryptedDateTimeOffsetConverter(_encryptionProvider))
                .IsRequired();

            // Relationships
            builder.HasOne(p => p.NotificationHub)
               .WithMany(p => p.IssuedContactRequestNotifications)
               .HasForeignKey(p => p.NotificationHubId)
               .HasConstraintName("FK_NotificationHub_IssuedContactRequestNotifications")
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Sender)
                .WithMany(p => p.SenderIssuedContactRequestNotifications)
                .HasForeignKey(p => p.SenderUserId)
                .HasConstraintName("FK_Sender_SenderIssuedContactRequestNotifications")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Receiver)
                .WithMany(p => p.ReceiverIssuedContactRequestNotifications)
                .HasForeignKey(p => p.ReceiverUserId)
                .HasConstraintName("FK_Receiver_ReceiverIssuedContactRequestNotifications")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
