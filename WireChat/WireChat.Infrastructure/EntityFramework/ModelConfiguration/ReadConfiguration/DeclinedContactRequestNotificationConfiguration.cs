using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionConverters;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.EntityFramework.ModelConfiguration.ReadConfiguration
{
    internal sealed class DeclinedContactRequestNotificationConfiguration : IEntityTypeConfiguration<DeclinedContactRequestNotificationReadModel>
    {
        private readonly IEncryptionProvider _encryptionProvider;

        public DeclinedContactRequestNotificationConfiguration(IEncryptionProvider encryptionProvider)
        {
            _encryptionProvider = encryptionProvider;   
        }

        public void Configure(EntityTypeBuilder<DeclinedContactRequestNotificationReadModel> builder)
        {
            // Table name
            builder.ToTable("DeclinedContactRequestNotification");

            // Composite primary key
            builder.HasKey(key => new { key.SenderUserId, key.ReceiverUserId });

            // Property config
            builder.Property(p => p.DateTime)
                .HasConversion(new EncryptedDateTimeOffsetConverter(_encryptionProvider))
                .IsRequired();

            // Relationships
            builder.HasOne(p => p.Sender)
                .WithMany(p => p.SenderDeclinedContactRequestNotifications)
                .HasForeignKey(p => p.SenderUserId)
                .HasConstraintName("FK_Sender_SenderDeclinedContactRequestNotifications")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Receiver)
                .WithMany(p => p.ReceiverDeclinedContactRequestNotifications)
                .HasForeignKey(p => p.ReceiverUserId)
                .HasConstraintName("FK_Receiver_ReceiverDeclinedContactRequestNotifications")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
