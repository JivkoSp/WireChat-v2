
namespace WireChat.Application.Dtos
{
    public class CreatedGroupNotificationDto
    {
        public string UserId { get; set; }
        public Guid GroupId { get; set; }
        public DateTimeOffset DateTime { get; set; }
        public string UserName { get; set; }
        public string GroupName { get; set; }
    }
}
