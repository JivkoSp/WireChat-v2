
namespace WireChat.Infrastructure.EntityFramework.Models
{
    public class GroupReadModel
    {
        // Primary key
        public Guid GroupId { get; set; }
        public int Version { get; set; }
        public string GroupName { get; set; }

        // Relationships
        public virtual ChatReadModel Chat {  get; set; }
        public virtual List<CreatedGroupNotificationReadModel> CreatedGroupNotifications { get; set; }
        public virtual List<ActiveGroupNotificationReadModel> ActiveGroupNotifications { get; set; }
        public virtual List<AddedGroupMemberNotificationReadModel> AddedGroupMemberNotifications { get; set; }
        public virtual List<RemovedGroupMemberNotificationReadModel> RemovedGroupMemberNotifications { get; set; }
        public virtual List<BannedGroupMemberNotificationReadModel> BannedGroupMemberNotifications { get; set; }
    }
}
