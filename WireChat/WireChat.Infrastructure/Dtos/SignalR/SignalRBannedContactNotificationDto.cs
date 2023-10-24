
namespace WireChat.Infrastructure.Dtos.SignalR
{
    public class SignalRBannedContactNotificationDto
    {
        public string ChatId { get; set; }
        public string IssuerUserName { get; set; }
        public string BannedUserName { get; set; }
        public DateTimeOffset DateTime {  get; set; }
    }
}
