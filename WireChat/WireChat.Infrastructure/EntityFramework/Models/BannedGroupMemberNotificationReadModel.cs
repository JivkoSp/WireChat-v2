
namespace WireChat.Infrastructure.EntityFramework.Models
{
    public class BannedGroupMemberNotificationReadModel
    {
        // Composite Primary Key { GroupAdminUserId, GroupMemberUserId }
        public string GroupAdminUserId { get; set; }
        public string GroupMemberUserId { get; set; }
        public DateTimeOffset DateTime { get; set; }

        // Relationships
        public Guid NotificationHubId { get; set; } // Foreign key to the NotificationHub table
        public Guid GroupId { get; set; } // Foreign key to the Group table
        public virtual NotificationHubReadModel NotificationHub { get; set; }
        public virtual GroupReadModel Group { get; set; }
        public virtual UserReadModel GroupAdmin { get; set; }
        public virtual UserReadModel GroupMember { get; set; }
    }
}
