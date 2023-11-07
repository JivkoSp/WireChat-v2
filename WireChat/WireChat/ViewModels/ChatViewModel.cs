using WireChat.Application.Dtos;

namespace WireChat.ViewModels
{
    public class ChatViewModel
    {
        public string CurrentUserId { get; set; }
        public string CurrentUserPicture { get; set; }
        public ChatDto ChatDto { get; set; }
    }
}