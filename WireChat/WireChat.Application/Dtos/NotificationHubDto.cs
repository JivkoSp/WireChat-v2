
namespace WireChat.Application.Dtos
{
    public class NotificationHubDto
    {
        public Guid NotificationHubId { get; set; }
        public List<IssuedContactRequestNotificationDto> IssuedContactRequestNotificationDtos { get; set; }
        public List<ReceivedContactRequestNotificationDto> ReceivedContactRequestNotificationDtos { get; set; }
        public List<AcceptedContactRequestNotificationDto> AcceptedContactRequestNotificationDtos { get; set; }
        public List<DeclinedContactRequestNotificationDto> DeclinedContactRequestNotificationDtos { get; set; }
        public List<ActiveGroupNotificationDto> ActiveGroupNotificationDtos { get; set; }
        public List<AddedGroupMemberNotificationDto> AddedGroupMemberNotificationDtos { get; set; }
        public List<RemovedGroupMemberNotificationDto> RemovedGroupMemberNotificationDtos { get; set; }
        public List<BannedContactNotificationDto> BannedContactNotificationDtos { get; set; }
        public List<BannedGroupMemberNotificationDto> BannedGroupMemberNotificationDtos { get; set; }
        public List<CreatedGroupNotificationDto> CreatedGroupNotificationDtos { get; set; }
        public List<RemovedChatMessageNotificationDto> RemovedChatMessageNotificationDtos { get; set; }
    }
}
