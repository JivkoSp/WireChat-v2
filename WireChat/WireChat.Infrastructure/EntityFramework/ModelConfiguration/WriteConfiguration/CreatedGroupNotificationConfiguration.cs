﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WireChat.Domain.ValueObjects;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionConverters;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;

namespace WireChat.Infrastructure.EntityFramework.ModelConfiguration.WriteConfiguration
{
    internal sealed class CreatedGroupNotificationConfiguration : IEntityTypeConfiguration<CreatedGroupNotification>
    {
        private readonly IEncryptionProvider _encryptionProvider;

        public CreatedGroupNotificationConfiguration(IEncryptionProvider encryptionProvider)
        {
            _encryptionProvider = encryptionProvider;
        }

        public void Configure(EntityTypeBuilder<CreatedGroupNotification> builder)
        {
            // Table name
            builder.ToTable("CreatedGroupNotification");

            // Composite primary key
            builder.HasKey(key => new { key.UserId, key.GroupId });

            // Property config
            builder.Property(p => p.UserId)
                .HasConversion(id => id.Value.ToString(), id => new UserID(Guid.Parse(id)))
                .IsRequired();

            builder.Property(p => p.GroupId)
                .HasConversion(id => id.Value, id => new GroupID(id))
                .IsRequired();

            builder.Property(p => p.NotificationHubId)
                .HasConversion(id => id.Value, id => new NotificationHubID(id))
                .IsRequired();

            builder.Property(typeof(DateTimeOffset), "DateTime")
                .HasConversion(new EncryptedDateTimeOffsetConverter(_encryptionProvider))
                .IsRequired();
        }
    }
}
