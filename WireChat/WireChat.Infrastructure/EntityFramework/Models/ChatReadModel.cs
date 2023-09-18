namespace WireChat.Infrastructure.EntityFramework.Models
{
    internal class ChatReadModel
    {
        // Primary key
        public Guid ChatId { get; set; }
        public string ChatType {get; set; }

        // Relationships
        public virtual List<ChatUserReadModel> ChatUsers { get; set; }
        public virtual List<ChatMessageReadModel> ChatMessages { get; set; }
    }
}