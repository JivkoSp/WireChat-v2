using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionConverters;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.EntityFramework.ModelConfiguration.ReadConfiguration
{
    internal sealed class CreatedGroupNotificationConfiguration : IEntityTypeConfiguration<CreatedGroupNotificationReadModel>
    {
        private readonly IEncryptionProvider _encryptionProvider;

        public CreatedGroupNotificationConfiguration(IEncryptionProvider encryptionProvider)
        {
            _encryptionProvider = encryptionProvider;
        }

        public void Configure(EntityTypeBuilder<CreatedGroupNotificationReadModel> builder)
        {
            // Table name
            builder.ToTable("CreatedGroupNotification");

            // Composite primary key
            builder.HasKey(key => new { key.UserId, key.GroupId });

            // Property config
            builder.Property(p => p.DateTime)
                .HasConversion(new EncryptedDateTimeOffsetConverter(_encryptionProvider))
                .IsRequired();

            // Relationships
            builder.HasOne(p => p.User)
                .WithMany(p => p.CreatedGroupNotifications)
                .HasForeignKey(p => p.UserId)
                .HasConstraintName("FK_User_CreatedGroupNotifications")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Group)
                .WithMany(p => p.CreatedGroupNotifications)
                .HasForeignKey(p => p.GroupId)
                .HasConstraintName("FK_Group_CreatedGroupNotifications")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
