
namespace WireChat.Infrastructure.Dtos.SignalR
{
    public class SignalRReceivedContactRequestNotificationDto
    {
        public string SenderUserName { get; set; }
        public string ReceiverUserName { get; set; }
        public DateTimeOffset DateTime { get; set; }
    }
}
