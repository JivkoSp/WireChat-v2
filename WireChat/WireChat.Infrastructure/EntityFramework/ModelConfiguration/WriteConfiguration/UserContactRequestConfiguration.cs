using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WireChat.Domain.ValueObjects;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionConverters;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;

namespace WireChat.Infrastructure.EntityFramework.ModelConfiguration.WriteConfiguration
{
    internal sealed class UserContactRequestConfiguration : IEntityTypeConfiguration<UserContactRequest>
    {
        private readonly IEncryptionProvider _encryptionProvider;

        public UserContactRequestConfiguration(IEncryptionProvider encryptionProvider)
        {
            _encryptionProvider = encryptionProvider;
        }

        public void Configure(EntityTypeBuilder<UserContactRequest> builder)
        {
            // Table name
            builder.ToTable("UserContactRequest");

            // Composite primary key
            builder.HasKey(key => new { key.SenderUserId, key.ReceiverUserId });

            // Property config
            builder.Property(p => p.SenderUserId)
                .HasConversion(new ValueConverter<UserID, string>(id => id.Value.ToString(), id => new UserID(Guid.Parse(id))))
                .IsRequired();

            builder.Property(p => p.ReceiverUserId)
                .HasConversion(new ValueConverter<UserID, string>(id => id.Value.ToString(), id => new UserID(Guid.Parse(id))))
                .IsRequired();

            builder.Property(typeof(string), "Message")
                .HasConversion(new EncryptedStringConverter(_encryptionProvider));
        }
    }
}
