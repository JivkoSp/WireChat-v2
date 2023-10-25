
namespace WireChat.Infrastructure.Dtos.SignalR
{
    public class SignalRRemovedGroupMemberNotificationDto
    {
        public string GroupAdminUserName { get; set; }
        public string GroupMemberUserName { get; set; }
        public string GroupId { get; set; }
        public string GroupName { get; set; } 
        public DateTimeOffset DateTime { get; set; }
    }
}
