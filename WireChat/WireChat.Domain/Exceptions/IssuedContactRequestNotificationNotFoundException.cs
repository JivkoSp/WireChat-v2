
namespace WireChat.Domain.Exceptions
{
    public sealed class IssuedContactRequestNotificationNotFoundException : DomainException
    {
        internal IssuedContactRequestNotificationNotFoundException(Guid notificationHubID, Guid receiverUserId) 
            : base(message: $"Issued contact request notification to user with ID #{receiverUserId} was not found in NotificationHub with ID #{notificationHubID}!")
        {
        }
    }
}
