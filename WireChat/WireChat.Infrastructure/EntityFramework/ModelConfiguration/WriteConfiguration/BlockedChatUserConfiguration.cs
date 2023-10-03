using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WireChat.Domain.ValueObjects;

namespace WireChat.Infrastructure.EntityFramework.ModelConfiguration.WriteConfiguration
{
    internal sealed class BlockedChatUserConfiguration : IEntityTypeConfiguration<BlockedChatUser>
    {
        public void Configure(EntityTypeBuilder<BlockedChatUser> builder)
        {
            // Table name
            builder.ToTable("BlockedChatUser");

            // Composite primary key
            builder.HasKey(key => new { key.UserID, key.ChatID });

            // Property config - Start

            builder.Property(p => p.UserID)
                .HasConversion(id => id.Value.ToString(), id => new UserID(Guid.Parse(id)))
                .HasColumnName("UserId")
                .IsRequired();

            builder.Property(p => p.ChatID)
                .HasConversion(id => id.Value, id => new ChatID(id))
                .HasColumnName("ChatId")
                .IsRequired();

            // Property config - End
        }
    }
}
