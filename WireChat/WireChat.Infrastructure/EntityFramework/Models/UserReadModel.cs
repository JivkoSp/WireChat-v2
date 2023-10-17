using Microsoft.AspNetCore.Identity;

namespace WireChat.Infrastructure.EntityFramework.Models
{
    public class UserReadModel : IdentityUser
    {
        public int Version { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        
        // Relationships
        public virtual List<UserContactRequestReadModel> SendedContactRequests { get; set; }
        public virtual List<UserContactRequestReadModel> ReceivedContactRequests { get; set; }
        public virtual List<ChatUserReadModel> ChatUsers { get; set; }
        public virtual List<BlockedChatUserReadModel> BlockedChatUsers { get; set; }
        public virtual List<ChatMessageReadModel> ChatMessages { get; set; }
        public virtual List<IssuedContactRequestNotificationReadModel> SenderIssuedContactRequestNotifications { get; set; }
        public virtual List<IssuedContactRequestNotificationReadModel> ReceiverIssuedContactRequestNotifications { get; set; }
        public virtual List<ReceivedContactRequestNotificationReadModel> SenderReceivedContactRequestNotifications { get; set; }
        public virtual List<ReceivedContactRequestNotificationReadModel> ReceiverReceivedContactRequestNotifications { get; set; }
        public virtual List<AcceptedContactRequestNotificationReadModel> SenderAcceptedContactRequestNotifications { get; set; }
        public virtual List<AcceptedContactRequestNotificationReadModel> ReceiverAcceptedContactRequestNotifications { get; set; }
        public virtual List<DeclinedContactRequestNotificationReadModel> SenderDeclinedContactRequestNotifications { get; set; }
        public virtual List<DeclinedContactRequestNotificationReadModel> ReceiverDeclinedContactRequestNotifications { get; set; }
        public virtual List<AddedGroupMemberNotificationReadModel> GroupAdminAddedGroupMemberNotifications { get; set; }
        public virtual List<AddedGroupMemberNotificationReadModel> GroupMemberAddedGroupMemberNotifications { get; set; }
        public virtual List<RemovedGroupMemberNotificationReadModel> GroupAdminRemovedGroupMemberNotifications { get; set; }
        public virtual List<RemovedGroupMemberNotificationReadModel> GroupMemberRemovedGroupMemberNotifications { get; set; }
        public virtual List<BannedContactNotificationReadModel> BannedContactNotifications { get; set; }
        public virtual List<BannedGroupMemberNotificationReadModel> GroupAdminBannedGroupMemberNotifications { get; set; }
        public virtual List<BannedGroupMemberNotificationReadModel> GroupMemberBannedGroupMemberNotifications { get; set; }
        public virtual List<CreatedGroupNotificationReadModel> CreatedGroupNotifications { get; set; }
        public virtual List<RemovedChatMessageNotificationReadModel> RemovedChatMessageNotifications { get; set; }
    }
}