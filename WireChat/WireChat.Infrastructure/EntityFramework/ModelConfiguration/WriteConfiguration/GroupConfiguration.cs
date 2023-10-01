using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionConverters;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;

namespace WireChat.Infrastructure.EntityFramework.ModelConfiguration.WriteConfiguration
{
    internal sealed class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        private readonly IEncryptionProvider _encryptionProvider;

        public GroupConfiguration(IEncryptionProvider encryptionProvider)
        {
            _encryptionProvider = encryptionProvider;
        }

        public void Configure(EntityTypeBuilder<Group> builder)
        {
            // Table name
            builder.ToTable("Group");

            // Primary key
            builder.HasKey(key => key.Id);

            // Property config
            builder.Property(p => p.Id)
                .HasConversion(id => id.Value, id => new ChatID(id))
                .HasColumnName("GroupId")
                .IsRequired();

            builder.Property(typeof(GroupName), "_groupName")
                .HasConversion(new EncryptedGroupNameConverter(_encryptionProvider))
                .HasColumnName("GroupName")
                .IsRequired();

            // Relationships
            builder.HasOne(p => p.Chat)
                .WithOne()
                .HasForeignKey<Group>(p => p.Id)
                .HasConstraintName("FK_Group_Chat")
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
