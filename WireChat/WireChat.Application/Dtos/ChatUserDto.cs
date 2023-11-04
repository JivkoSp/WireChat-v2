namespace WireChat.Application.Dtos
{
    public class ChatUserDto
    {
        public string UserId { get; set; }
        public Guid ChatId { get; set; }
        public string UserName { get; set; }
        public string UserPicture { get; set; }
    }
}