
namespace WireChat.Infrastructure.Dtos.SignalR
{
    public class SignalRRemoveChatUserDto
    {
        public string ChatId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}
