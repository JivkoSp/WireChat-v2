namespace WireChat.Infrastructure.EntityFramework.Models
{
    internal class ChatUserReadModel
    {
         // Composite Primary Key { UserId, ChatId }
         public string UserId { get; set; }
         public Guid ChatId { get; set; }

         // Relationships
         public virtual UserReadModel User { get; set; }
         public virtual ChatReadModel Chat { get; set; }
    }
}