
namespace WireChat.Application.Dtos
{
    public class BannedContactNotificationDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public Guid ChatId { get; set; }
        public DateTimeOffset DateTime { get; set; }
    }
}
