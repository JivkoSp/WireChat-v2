
namespace WireChat.Domain.Exceptions
{
    public sealed class DeclinedContactRequestNotificationNotFoundException : DomainException
    {
        internal DeclinedContactRequestNotificationNotFoundException(Guid notificationHubID, Guid senderUserId) 
            : base(message: $"Declined contact request notification from user with ID #{senderUserId} was not found in NotificationHub with ID #{notificationHubID}!")
        {
        }
    }
}
