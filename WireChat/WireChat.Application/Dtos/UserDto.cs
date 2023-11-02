
namespace WireChat.Application.Dtos
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public List<BlockedChatUserDto> BlockedChatUserDtos { get; set; }
    }
}
