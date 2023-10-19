using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WireChat.Domain.ValueObjects;

namespace WireChat.Infrastructure.EntityFramework.ModelConfiguration.WriteConfiguration
{
    internal sealed class ActiveGroupNotificationConfiguration : IEntityTypeConfiguration<ActiveGroupNotification>
    {
        public void Configure(EntityTypeBuilder<ActiveGroupNotification> builder)
        {
            // Table name
            builder.ToTable("ActiveGroupNotification");

            //Shadow property for ActiveGroupNotificationId.
            builder.Property<Guid>("ActiveGroupNotificationId");

            //Primary key
            builder.HasKey("ActiveGroupNotificationId");

            // Property config
            builder.Property(p => p.GroupId)
                .HasConversion(id => id.Value, id => new GroupID(id))
                .IsRequired();
        }
    }
}
