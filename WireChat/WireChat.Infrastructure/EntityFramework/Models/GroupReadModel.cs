
namespace WireChat.Infrastructure.EntityFramework.Models
{
    public class GroupReadModel
    {
        // Primary key
        public Guid GroupId { get; set; }
        public int Version { get; set; }
        public string GroupName { get; set; }

        // Relationships
        public virtual ChatReadModel Chat {  get; set; }
    }
}
