
namespace WireChat.Application.Dtos
{
    public class DeclinedContactRequestNotificationDto
    {
        public string SenderUserId { get; set; }
        public string ReceiverUserId { get; set; }
        public DateTimeOffset DateTime { get; set; }
        public string SenderUserName { get; set; }
        public string ReceiverUserName { get; set; }
    }
}
