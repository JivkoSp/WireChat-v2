
namespace WireChat.Infrastructure.Dtos.SignalR
{
    public class SignalAddedContactDto
    {
        public string IssuerUserName { get; set; }
        public string ReceiverUserName { get; set; }
        public string IssuerUserPicture { get; set; }
        public string ReceiverUserPicture { get; set; }
        public Guid ChatId { get; set; }
    }
}
