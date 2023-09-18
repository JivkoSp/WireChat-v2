using Microsoft.AspNetCore.Identity;

namespace WireChat.Infrastructure.EntityFramework.Models
{
    internal class UserReadModel : IdentityUser
    {
        public int Version { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        
        // Relationships
        public virtual List<UserContactRequestReadModel> UserContactRequests { get; set; }
        public virtual List<ChatUserReadModel> ChatUsers { get; set; }

    }
}