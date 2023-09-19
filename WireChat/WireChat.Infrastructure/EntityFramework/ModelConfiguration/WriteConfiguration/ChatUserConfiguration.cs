using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WireChat.Domain.ValueObjects;

namespace WireChat.Infrastructure.EntityFramework.ModelConfiguration.WriteConfiguration
{
    internal sealed class ChatUserConfiguration : IEntityTypeConfiguration<ChatUser>
    {
        public void Configure(EntityTypeBuilder<ChatUser> builder)
        {
            // Table name
            builder.ToTable("ChatUser");

            // Composite primary key
            builder.HasKey(key => new { key.UserID, key.ChatID });

            // Property config - Start

            builder.Property(p => p.UserID)
                .HasConversion(id => id.Value.ToString(), id => new UserID(Guid.Parse(id)))
                .HasColumnName("UserId")
                .IsRequired();

            builder.Property(p => p.ChatID)
                .HasConversion(id => id.Value.ToString(), id => new ChatID(Guid.Parse(id)))
                .HasColumnName("ChatId")
                .IsRequired();

            // Property config - End
        }
    }
}
