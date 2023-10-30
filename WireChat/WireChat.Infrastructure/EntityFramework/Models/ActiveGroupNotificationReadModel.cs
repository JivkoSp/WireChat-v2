
namespace WireChat.Infrastructure.EntityFramework.Models
{
    public class ActiveGroupNotificationReadModel
    {
        // Primary key
        public Guid ActiveGroupNotificationId { get; set; }

        // Relationships
        public Guid NotificationHubId { get; set; } // Foreign key to the NotificationHub table
        public Guid GroupId { get; set; } // Foreign key to the Group table
        public virtual NotificationHubReadModel NotificationHub { get; set; }
        public virtual GroupReadModel Group { get; set; }
    }
}
