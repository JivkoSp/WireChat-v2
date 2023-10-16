
namespace WireChat.Infrastructure.EntityFramework.Models
{
    public class AddedGroupMemberNotificationReadModel
    {
        // Composite Primary Key { GroupAdminUserId, GroupMemberUserId }
        public string GroupAdminUserId { get; set; }
        public string GroupMemberUserId { get; set; }
        public DateTimeOffset DateTime { get; set; }

        // Relationships
        public Guid GroupId { get; set; }
        public virtual GroupReadModel Group { get; set; }
        public virtual UserReadModel GroupAdmin { get; set; }
        public virtual UserReadModel GroupMember { get; set; }
    }
}
