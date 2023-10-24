
namespace WireChat.Infrastructure.Dtos.SignalR
{
    public class SignalRBannedGroupMemberNotificationDto
    {
        public string GroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupAdminUserName { get; set; }
        public string GroupMemberUserName { get; set; }
        public DateTimeOffset DateTime { get; set; }
    }
}
