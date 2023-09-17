namespace WireChat.Application.Dtos
{
    public class UserContactRequestDto
    {
        public Guid SenderUserId { get; set; }
        public Guid ReceiverUserId { get; set; }
        public string Message { get; set; }
    }
}