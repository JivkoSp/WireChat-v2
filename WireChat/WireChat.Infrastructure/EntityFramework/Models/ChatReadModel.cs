namespace WireChat.Infrastructure.EntityFramework.Models
{
    public class ChatReadModel
    {
        // Primary key
        public Guid ChatId { get; set; }
        public int Version { get; set; }
        public string ChatType {get; set; }

        // Relationships
        public virtual List<ChatUserReadModel> ChatUsers { get; set; }
        public virtual List<BlockedChatUserReadModel> BlockedChatUsers { get; set; } 
        public virtual List<ChatMessageReadModel> ChatMessages { get; set; }
        public virtual List<BannedContactNotificationReadModel> BannedContactNotifications { get; set; }
        public virtual List<RemovedChatMessageNotificationReadModel> RemovedChatMessageNotifications { get; set; }
    }
}