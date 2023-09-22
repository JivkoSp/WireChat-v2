namespace WireChat.Application.Dtos
{
    public class UserContactRequestDto
    {
        public string SenderUserId { get; set; }
        public string ReceiverUserId { get; set; }
        public string Message { get; set; }
    }
}