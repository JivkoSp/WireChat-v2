
namespace WireChat.Domain.Exceptions
{
    public sealed class BannedContactNotificationAlreadyExistsException : DomainException
    {
        internal BannedContactNotificationAlreadyExistsException(Guid notificationHubID, Guid userId) 
            : base(message: $"Banned contact notification for user with ID #{userId} already exists in notification hub with ID #{notificationHubID}!")
        {
        }
    }
}
