
namespace WireChat.Infrastructure.Dtos.SignalR
{
    public class SignalRChatMessageDto
    {
        public Guid ChatId { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public DateTimeOffset MessageDateTime { get; set; }
        public bool IsFromCurrentUser { get; set; } = false;
    }
}
