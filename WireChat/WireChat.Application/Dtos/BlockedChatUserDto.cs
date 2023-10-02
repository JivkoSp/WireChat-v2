
namespace WireChat.Application.Dtos
{
    public class BlockedChatUserDto
    {
        public string UserId { get; set; }
        public Guid ChatId { get; set; }
        public string UserName { get; set; }
    }
}
