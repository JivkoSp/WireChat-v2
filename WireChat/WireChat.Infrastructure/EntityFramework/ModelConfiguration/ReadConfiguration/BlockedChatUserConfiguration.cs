using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.EntityFramework.ModelConfiguration.ReadConfiguration
{
    internal sealed class BlockedChatUserConfiguration : IEntityTypeConfiguration<BlockedChatUserReadModel>
    {
        public void Configure(EntityTypeBuilder<BlockedChatUserReadModel> builder)
        {
            // Table name
            builder.ToTable("BlockedChatUser");

            // Composite primary key
            builder.HasKey(key => new { key.UserId, key.ChatId });

            // Relationships
            builder.HasOne(p => p.User)
                .WithMany(p => p.BlockedChatUsers)
                .HasForeignKey(p => p.UserId)
                .HasConstraintName("FK_User_BlockedChatUsers")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Chat)
                .WithMany(p => p.BlockedChatUsers)
                .HasForeignKey(p => p.ChatId)
                .HasConstraintName("FK_Chat_BlockedChatUsers")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
