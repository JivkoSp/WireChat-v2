namespace WireChat.Application.Dtos
{
    public class UserContactRequestDto
    {
        public string SenderUserName { get; set; }
        public string ReceiverUserName { get; set; }
        public string Message { get; set; }
    }
}