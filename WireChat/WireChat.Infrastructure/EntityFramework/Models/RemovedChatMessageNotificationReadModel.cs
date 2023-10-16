
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
        public virtual ChatReadModel Chat { get; set; }
        public virtual ChatMessageReadModel ChatMessage { get; set; }
        public virtual UserReadModel User { get; set; }
    }
}