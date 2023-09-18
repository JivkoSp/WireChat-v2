using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionConverters;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.EntityFramework.ModelConfiguration.ReadConfiguration
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<UserReadModel>
    {
        private readonly IEncryptionProvider _encryptionProvider;

        public UserConfiguration(IEncryptionProvider encryptionProvider)
        {
            _encryptionProvider = encryptionProvider;
        }

        public void Configure(EntityTypeBuilder<UserReadModel> builder)
        {
            // Table name
            builder.ToTable("User");

            // Primary key
            builder.HasKey(key => key.Id);

            // Property config 
            
            builder.Property(p => p.UserFirstName)
                .HasConversion(new EncryptedStringConverter(_encryptionProvider))
                .IsRequired();
            
            builder.Property(p => p.UserLastName)
                .HasConversion(new EncryptedStringConverter(_encryptionProvider))
                .IsRequired();

            builder.Property(p => p.Email)
                .HasConversion(new EncryptedStringConverter(_encryptionProvider))
                .IsRequired();

            builder.Property(p => p.NormalizedEmail)
                .HasConversion(new EncryptedStringConverter(_encryptionProvider));
            
            builder.Property(p => p.PhoneNumber)
                .HasConversion(new EncryptedStringConverter(_encryptionProvider));
        }
    }
}