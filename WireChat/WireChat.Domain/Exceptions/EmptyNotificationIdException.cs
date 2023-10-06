
namespace WireChat.Domain.Exceptions
{
    public sealed class EmptyNotificationIdException : DomainException
    {
        internal EmptyNotificationIdException() : base(message: "Notification id cannot be empty!")
        {
        }
    }
}
