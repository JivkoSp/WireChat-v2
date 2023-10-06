
namespace WireChat.Domain.Exceptions
{
    public sealed class ReceivedContactRequestNotificationNotFoundException : DomainException
    {
        internal ReceivedContactRequestNotificationNotFoundException(Guid notificationHubID, Guid senderUserId) 
            : base(message: $"Received contact request notification from user with ID #{senderUserId} was not found in NotificationHub with ID #{notificationHubID}!")
        {
        }
    }
}
