using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionConverters;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.EntityFramework.ModelConfiguration.ReadConfiguration
{
    internal sealed class UserContactRequestConfiguration : IEntityTypeConfiguration<UserContactRequestReadModel>
    {
        private readonly IEncryptionProvider _encryptionProvider;

        public UserContactRequestConfiguration(IEncryptionProvider encryptionProvider)
        {
            _encryptionProvider = encryptionProvider;
        }

        public void Configure(EntityTypeBuilder<UserContactRequestReadModel> builder)
        {
             // Table name
            builder.ToTable("UserContactRequest");

            // Composite primary key
            builder.HasKey(key => new { key.SenderUserId, key.ReceiverUserId });

            // Property config
            builder.Property(p => p.Message)
                .HasConversion(new EncryptedStringConverter(_encryptionProvider));

             // Relationships
             builder.HasOne(p => p.Sender)
                .WithMany(p => p.SendedContactRequests)
                .HasForeignKey(p => p.SenderUserId)
                .HasConstraintName("FK_Sender_SendedContactRequests")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Receiver)
                .WithMany(p => p.ReceivedContactRequests)
                .HasForeignKey(p => p.ReceiverUserId)
                .HasConstraintName("FK_Receiver_ReceivedContactRequests")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}