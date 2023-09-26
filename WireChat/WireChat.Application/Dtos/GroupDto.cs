
namespace WireChat.Application.Dtos
{
    public class GroupDto
    {
        public Guid GroupId { get; set; }
        public string GroupName { get; set; }
        public ChatDto ChatDto { get; set; }
    }
}
