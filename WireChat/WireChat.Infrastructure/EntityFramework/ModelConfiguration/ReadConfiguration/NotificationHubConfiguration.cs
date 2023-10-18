using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.EntityFramework.ModelConfiguration.ReadConfiguration
{
    internal sealed class NotificationHubConfiguration : IEntityTypeConfiguration<NotificationHubReadModel>
    {
        public void Configure(EntityTypeBuilder<NotificationHubReadModel> builder)
        {
            // Table name
            builder.ToTable("NotificationHub");

            // Primary key
            builder.HasKey(key => key.NotificationHubId);
        }
    }
}
