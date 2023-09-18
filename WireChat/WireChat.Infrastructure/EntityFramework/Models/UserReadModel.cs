using Microsoft.AspNetCore.Identity;

namespace WireChat.Infrastructure.EntityFramework.Models
{
    internal class UserReadModel : IdentityUser
    {
        public int Version { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        
        // Relationships
        public virtual List<UserContactRequestReadModel> SendedContactRequests { get; set; }
        public virtual List<UserContactRequestReadModel> ReceivedContactRequests { get; set; }
        public virtual List<ChatUserReadModel> ChatUsers { get; set; }
        public virtual List<ChatMessageReadModel> ChatMessages { get; set; }
    }
}