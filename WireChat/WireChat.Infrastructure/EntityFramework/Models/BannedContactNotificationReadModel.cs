
namespace WireChat.Infrastructure.EntityFramework.Models
{
    public class BannedContactNotificationReadModel
    {
        // Composite Primary Key { UserId, ChatId }
        public string UserId { get; set; }
        public Guid ChatId { get; set; }
        public DateTimeOffset DateTime { get; set; }

        // Relationships
        public Guid NotificationHubId { get; set; } // Foreign key to the NotificationHub table
        public virtual NotificationHubReadModel NotificationHub { get; set; }
        public virtual UserReadModel User { get; set; }
        public virtual ChatReadModel Chat { get; set; }
    }
}