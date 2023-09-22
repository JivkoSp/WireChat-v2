using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionConverters;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;

namespace WireChat.Infrastructure.EntityFramework.ModelConfiguration.WriteConfiguration
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        private readonly IEncryptionProvider _encryptionProvider;

        public UserConfiguration(IEncryptionProvider encryptionProvider)
        {
            _encryptionProvider = encryptionProvider;
        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Table name
            builder.ToTable("User");

            // Primary key
            builder.HasKey(key => key.Id);

            // Property config - Start

            builder.Property(p => p.Id)
                .HasConversion(id => id.Value.ToString(), id => new UserID(Guid.Parse(id)))
                .IsRequired();

            builder.Property(typeof(UserFirstName), "_firstName")
                .HasConversion(new EncryptedUserFirstNameConverter(_encryptionProvider))
                .HasColumnName("UserFirstName")
                .IsRequired();

            builder.Property(typeof(UserLastName), "_lastName")
                .HasConversion(new EncryptedUserLastNameConverter(_encryptionProvider))
                .HasColumnName("UserLastName")
                .IsRequired();

            builder.Property(typeof(UserName), "_userName")
                .HasConversion(new ValueConverter<UserName, string>(x => x, x => new UserName(x)))
                .HasColumnName("UserName");

            builder.Property(typeof(UserEmail), "_email")
                .HasConversion(new EncryptedUserEmailConverter(_encryptionProvider))
                .HasColumnName("Email")
                .IsRequired();

            // Property config - End

            // Relationships
            builder.HasMany(p => p.ContactRequests);
        }
    }
}
