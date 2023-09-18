using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.EntityFramework.ModelConfiguration
{
    internal sealed class ChatUserConfiguration : IEntityTypeConfiguration<ChatUserReadModel>
    {
        public void Configure(EntityTypeBuilder<ChatUserReadModel> builder)
        {
             // Table name
            builder.ToTable("ChatUser");

            // Composite primary key
            builder.HasKey(key => new { key.UserId, key.ChatId });

            // Relationships
            builder.HasOne(p => p.User)
                .WithMany(p => p.ChatUsers)
                .HasForeignKey(p => p.UserId)
                .HasConstraintName("FK_User_ChatUsers")
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasOne(p => p.Chat)
                .WithMany(p => p.ChatUsers)
                .HasForeignKey(p => p.ChatId)
                .HasConstraintName("FK_Chat_ChatUsers")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}