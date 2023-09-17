namespace WireChat.Application.Dtos
{
    public class ChatMessageDto
    {
        public Guid ChatMessageId { get; set; }
        public Guid UserId { get; set; }
        public string Message { get; set; }
        public DateTimeOffset MessageDateTime { get; set; }
    }
}