namespace WireChat.Infrastructure.EntityFramework.Models
{
    internal class ChatMessageReadModel
    {
        // Primary key
        public Guid ChatMessageId { get; set; }
        public string Message { get; set; }
        public DateTimeOffset MessageDateTime { get; set; }

        // Relationships
        public Guid ChatId { get; set; } // Foreign key to the Chat table
        public Guid UserId { get; set; } // Foreign key to the User table
        public virtual ChatReadModel Chat { get; set; }
        public virtual UserReadModel User { get; set; }
    }
}