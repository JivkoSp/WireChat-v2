
namespace WireChat.Infrastructure.EntityFramework.Models
{
    public class ReceivedContactRequestNotificationReadModel
    {
        // Composite Primary Key { SenderUserId, ReceiverUserId }
        public string SenderUserId { get; set; }
        public string ReceiverUserId { get; set; }
        public DateTimeOffset DateTime { get; set; }

        // Relationships
        public virtual UserReadModel Sender { get; set; }
        public virtual UserReadModel Receiver { get; set; }
    }
}
