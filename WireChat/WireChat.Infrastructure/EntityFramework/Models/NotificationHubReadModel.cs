
namespace WireChat.Infrastructure.EntityFramework.Models
{
    public class NotificationHubReadModel
    {
        // Primary key
        public Guid NotificationHubId { get; set; }
        public int Version { get; set; }

        // Relationships
        public virtual List<IssuedContactRequestNotificationReadModel> IssuedContactRequestNotifications { get; set; }
        public virtual List<ReceivedContactRequestNotificationReadModel> ReceivedContactRequestNotifications { get; set; }
        public virtual List<AcceptedContactRequestNotificationReadModel> AcceptedContactRequestNotifications { get; set; }
        public virtual List<DeclinedContactRequestNotificationReadModel> DeclinedContactRequestNotifications { get; set; }
        public virtual List<ActiveGroupNotificationReadModel> ActiveGroupNotifications { get; set; }
        public virtual List<AddedGroupMemberNotificationReadModel> AddedGroupMemberNotifications { get; set; }
        public virtual List<RemovedGroupMemberNotificationReadModel> RemovedGroupMemberNotifications { get; set; }
        public virtual List<BannedContactNotificationReadModel> BannedContactNotifications { get; set; }
        public virtual List<BannedGroupMemberNotificationReadModel> BannedGroupMemberNotifications { get; set; }
        public virtual List<CreatedGroupNotificationReadModel> CreatedGroupNotifications { get; set; }
        public virtual List<RemovedChatMessageNotificationReadModel> RemovedChatMessageNotifications { get; set; }
    }
}