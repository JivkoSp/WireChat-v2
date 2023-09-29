
namespace WireChat.Infrastructure.Dtos.SignalR
{
    public class SignalRContactRequestDto
    {
        public string SenderUserName { get; set; }
        public string ReceiverUserName { get; set; }
        public string ContactMessage { get; set; }
        public DateTimeOffset DateTime { get; set; }
    }
}
