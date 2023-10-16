
namespace WireChat.Infrastructure.EntityFramework.Models
{
    public class CreatedGroupNotificationReadModel
    {
        // Composite Primary Key { UserId, GroupId }
        public string UserId { get; set; }
        public Guid GroupId { get; set; }
        public DateTimeOffset DateTime { get; set; }

        // Relationships
        public virtual UserReadModel User { get; set; }
        public virtual GroupReadModel Group { get; set; }
    }
}
