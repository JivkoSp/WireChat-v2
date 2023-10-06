
namespace WireChat.Domain.Exceptions
{
    public sealed class NullNotificationHubParametersException : DomainException
    {
        internal NullNotificationHubParametersException() : base(message: "NotificationHub cannot be initialized with one or more null parameters!")
        {
        }
    }
}
