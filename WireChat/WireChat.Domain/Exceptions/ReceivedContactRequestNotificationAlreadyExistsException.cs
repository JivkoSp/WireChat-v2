
namespace WireChat.Domain.Exceptions
{
    public sealed class ReceivedContactRequestNotificationAlreadyExistsException : DomainException
    {
        internal ReceivedContactRequestNotificationAlreadyExistsException(Guid notificationHubID, Guid senderUserId) 
            : base(message: $"Received contact request notification by user with ID #{senderUserId} already exists in NotificationHub with ID #{notificationHubID}!")
        {
        }
    }
}
