
namespace WireChat.Domain.Exceptions
{
    public sealed class NullNotificationHubIdException : DomainException
    {
        internal NullNotificationHubIdException() : base(message: "NotificationHubId cannot be null!")
        {
        }
    }
}
