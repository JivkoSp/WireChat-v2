
namespace WireChat.Application.Dtos
{
    public class AddedGroupMemberNotificationDto
    {
        public string GroupAdminUserId { get; set; }
        public string GroupMemberUserId { get; set; }
        public Guid GroupId { get; set; }
        public DateTimeOffset DateTime { get; set; }
        public string GroupName { get; set; }
        public string GroupAdminUserName { get; set; }
        public string GroupMemberUserName { get; set; }
    }
}
