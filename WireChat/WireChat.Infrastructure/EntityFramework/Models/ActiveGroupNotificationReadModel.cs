
namespace WireChat.Infrastructure.EntityFramework.Models
{
    public class ActiveGroupNotificationReadModel
    {
        // Primary key
        public Guid ActiveGroupNotificationId { get; set; }

        // Relationships
        public Guid GroupId { get; set; }
        public virtual GroupReadModel Group { get; set; }
    }
}
