
namespace WireChat.Infrastructure.Dtos.SignalR
{
    public class SignalRRemovedChatMessageNotificationDto
    {
        public string ChatId { get; set; }
        public string UserName { get; set; } 
        public DateTimeOffset DateTime { get; set; }
    }
}
