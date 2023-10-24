
namespace WireChat.Infrastructure.Dtos.SignalR
{
    public class SignalRCreatedGroupNotificationDto
    {
        public string UserName { get; set; } 
        public string GroupName { get; set; } 
        public DateTimeOffset DateTime { get; set; }
    }
}
