using WireChat.Application.Dtos;

namespace WireChat.ViewModels
{
    public class ContactRequestViewModel
    {
        public List<UserContactRequestDto> IssuedContactRequests { get; set; } = new List<UserContactRequestDto>();
        public List<UserContactRequestDto> ReceivedContactRequests { get; set; } = new List<UserContactRequestDto>();
    }
}
