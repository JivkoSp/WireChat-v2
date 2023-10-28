using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionConverters;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.EntityFramework.ModelConfiguration.ReadConfiguration
{
    internal sealed class AcceptedContactRequestNotificationConfiguration 
        : IEntityTypeConfiguration<AcceptedContactRequestNotificationReadModel>
    {
        private readonly IEncryptionProvider _encryptionProvider;

        public AcceptedContactRequestNotificationConfiguration(IEncryptionProvider encryptionProvider)
        {
            _encryptionProvider = encryptionProvider;
        }

        public void Configure(EntityTypeBuilder<AcceptedContactRequestNotificationReadModel> builder)
        {
            // Table name
            builder.ToTable("AcceptedContactRequestNotification");

            // Composite primary key
            builder.HasKey(key => new { key.SenderUserId, key.ReceiverUserId });

            // Property config
            builder.Property(p => p.DateTime)
                .HasConversion(new EncryptedDateTimeOffsetConverter(_encryptionProvider))
                .IsRequired();

            // Relationships
            builder.HasOne(p => p.NotificationHub)
                .WithMany(p => p.AcceptedContactRequestNotifications)
                .HasForeignKey(p => p.NotificationHubId)
                .HasConstraintName("FK_NotificationHub_AcceptedContactRequestNotifications")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Sender)
                .WithMany(p => p.SenderAcceptedContactRequestNotifications)
                .HasForeignKey(p => p.SenderUserId)
                .HasConstraintName("FK_Sender_SenderAcceptedContactRequestNotifications")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Receiver)
                .WithMany(p => p.ReceiverAcceptedContactRequestNotifications)
                .HasForeignKey(p => p.ReceiverUserId)
                .HasConstraintName("FK_Receiver_ReceiverAcceptedContactRequestNotifications")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
