
namespace WireChat.Domain.Exceptions
{
    public sealed class BannedContactNotificationNotFoundException : DomainException
    {
        internal BannedContactNotificationNotFoundException(Guid notificationHubID, Guid userId) 
            : base(message: $"Banned contact notification for user with ID #{userId} was not found in NotificationHub with ID #{notificationHubID}!")
        {
        }
    }
}
