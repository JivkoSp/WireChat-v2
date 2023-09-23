
namespace WireChat.Infrastructure.Dtos.SignalR
{
    public class SignalRContactRequestDto
    {
        public string ContactName { get; set; }
        public string ContactMessage { get; set; }
        public DateTimeOffset DateTime { get; set; }
    }
}
