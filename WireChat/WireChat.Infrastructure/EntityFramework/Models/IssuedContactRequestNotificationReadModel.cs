
namespace WireChat.Infrastructure.EntityFramework.Models
{
    public class IssuedContactRequestNotificationReadModel
    {
        // Composite Primary Key { SenderUserId, ReceiverUserId }
        public string SenderUserId { get; set; }
        public string ReceiverUserId { get; set; }
        public DateTimeOffset DateTime { get; set; }

        // Relationships
        public Guid NotificationHubId { get; set; } // Foreign key to the NotificationHub table
        public virtual NotificationHubReadModel NotificationHub { get; set; }
        public virtual UserReadModel Sender { get; set; }
        public virtual UserReadModel Receiver { get; set; }
    }
}
