namespace WireChat.Application.Dtos
{
    public class ChatUserDto
    {
        public Guid UserId { get; set; }
        public Guid ChatId { get; set; }
        public string UserName { get; set; }
    }
}