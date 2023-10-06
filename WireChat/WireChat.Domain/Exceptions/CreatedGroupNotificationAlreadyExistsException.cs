
namespace WireChat.Domain.Exceptions
{
    public sealed class CreatedGroupNotificationAlreadyExistsException : DomainException
    {
        internal CreatedGroupNotificationAlreadyExistsException(Guid notificationHubID, Guid groupId) 
            : base(message: $"Created group notification for group with ID #{groupId} already exists in notification hub with ID #{notificationHubID}!")
        {
        }
    }
}
