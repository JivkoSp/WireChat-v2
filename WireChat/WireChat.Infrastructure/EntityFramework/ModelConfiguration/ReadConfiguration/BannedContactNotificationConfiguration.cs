using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionConverters;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.EntityFramework.ModelConfiguration.ReadConfiguration
{
    internal sealed class BannedContactNotificationConfiguration : IEntityTypeConfiguration<BannedContactNotificationReadModel>
    {
        private readonly IEncryptionProvider _encryptionProvider;

        public BannedContactNotificationConfiguration(IEncryptionProvider encryptionProvider)
        {
            _encryptionProvider = encryptionProvider;
        }

        public void Configure(EntityTypeBuilder<BannedContactNotificationReadModel> builder)
        {
            // Table name
            builder.ToTable("BannedContactNotification");

            // Composite primary key
            builder.HasKey(key => new { key.UserId, key.ChatId });

            // Property config
            builder.Property(p => p.DateTime)
                .HasConversion(new EncryptedDateTimeOffsetConverter(_encryptionProvider))
                .IsRequired();

            // Relationships
            builder.HasOne(p => p.NotificationHub)
               .WithMany(p => p.BannedContactNotifications)
               .HasForeignKey(p => p.NotificationHubId)
               .HasConstraintName("FK_NotificationHub_BannedContactNotifications")
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.User)
                .WithMany(p => p.BannedContactNotifications)
                .HasForeignKey(p => p.UserId)
                .HasConstraintName("FK_User_BannedContactNotifications")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Chat)
                .WithMany(p => p.BannedContactNotifications)
                .HasForeignKey(p => p.ChatId)
                .HasConstraintName("FK_Chat_BannedContactNotifications")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
