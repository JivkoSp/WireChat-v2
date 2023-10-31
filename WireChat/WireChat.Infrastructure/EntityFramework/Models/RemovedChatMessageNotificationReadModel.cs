
namespace WireChat.Infrastructure.EntityFramework.Models
{
    public class RemovedChatMessageNotificationReadModel
    {
        // Composite Primary Key { ChatId, ChatMessageId }
        public Guid ChatId { get; set; }
        public Guid ChatMessageId { get; set; }
        public string UserId { get; set; }
        public DateTimeOffset DateTime { get; set; }

        // Relationships
        public Guid NotificationHubId { get; set; } // Foreign key to the NotificationHub table
        public virtual NotificationHubReadModel NotificationHub { get; set; }
        public virtual ChatReadModel Chat { get; set; }
        public virtual ChatMessageReadModel ChatMessage { get; set; }
        public virtual UserReadModel User { get; set; }
    }
}