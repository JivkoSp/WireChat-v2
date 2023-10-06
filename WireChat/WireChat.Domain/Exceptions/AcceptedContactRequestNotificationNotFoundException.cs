
namespace WireChat.Domain.Exceptions
{
    public sealed class AcceptedContactRequestNotificationNotFoundException : DomainException
    {
        internal AcceptedContactRequestNotificationNotFoundException(Guid notificationHubID, Guid senderUserId) 
            : base(message: $"Accepted contact request notification from user with ID #{senderUserId} was not found in NotificationHub with ID #{notificationHubID}!")
        {
        }
    }
}
