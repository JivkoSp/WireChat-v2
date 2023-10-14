
namespace WireChat.Application.Dtos
{
    public class RemovedChatMessageNotificationDto
    {
        public Guid ChatId { get; set; }
        public Guid ChatMessageId { get; set; }
        public string UserId { get; set; }
        public DateTimeOffset DateTime { get; set; }
        public string UserName { get; set; }
    }
}
