using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WireChat.Domain.ValueObjects;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionConverters;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;

namespace WireChat.Infrastructure.EntityFramework.ModelConfiguration.WriteConfiguration
{
    internal sealed class BannedContactNotificationConfiguration : IEntityTypeConfiguration<BannedContactNotification>
    {
        private readonly IEncryptionProvider _encryptionProvider;

        public BannedContactNotificationConfiguration(IEncryptionProvider encryptionProvider)
        {
            _encryptionProvider = encryptionProvider;
        }

        public void Configure(EntityTypeBuilder<BannedContactNotification> builder)
        {
            // Table name
            builder.ToTable("BannedContactNotification");

            // Composite primary key
            builder.HasKey(key => new { key.UserId, key.ChatId });

            // Property config
            builder.Property(p => p.UserId)
                .HasConversion(id => id.Value.ToString(), id => new UserID(Guid.Parse(id)))
                .IsRequired();

            builder.Property(p => p.ChatId)
                .HasConversion(id => id.Value, id => new ChatID(id))
                .IsRequired();

            builder.Property(typeof(DateTimeOffset), "DateTime")
               .HasConversion(new EncryptedDateTimeOffsetConverter(_encryptionProvider))
               .IsRequired();
        }
    }
}
