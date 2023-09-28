using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionConverters;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.EntityFramework.ModelConfiguration.ReadConfiguration
{
    internal sealed class GroupConfiguration : IEntityTypeConfiguration<GroupReadModel>
    {
        private readonly IEncryptionProvider _encryptionProvider;

        public GroupConfiguration(IEncryptionProvider encryptionProvider)
        {
            _encryptionProvider = encryptionProvider;
        }

        public void Configure(EntityTypeBuilder<GroupReadModel> builder)
        {
            // Table name
            builder.ToTable("Group");

            // Primary key
            builder.HasKey(key => key.GroupId);

            // Property config
            builder.Property(p => p.GroupName)
                .HasConversion(new EncryptedStringConverter(_encryptionProvider))
                .IsRequired();

            // Relationships
            builder.HasOne(p => p.Chat)
                .WithOne()
                .HasForeignKey<GroupReadModel>(p => p.GroupId)
                .HasConstraintName("FK_Group_Chat")
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
