namespace WireChat.Infrastructure.EntityFramework.Models
{
    internal class UserContactRequestReadModel
    {
        // Composite Primary Key { SenderUserId, ReceiverUserId }
        public string SenderUserId { get; set; }
        public string ReceiverUserId { get; set; }
        public string Message { get; set; }

        // Relationships
        public virtual UserReadModel Sender { get; set; }
        public virtual UserReadModel Receiver { get; set; }
    }
}