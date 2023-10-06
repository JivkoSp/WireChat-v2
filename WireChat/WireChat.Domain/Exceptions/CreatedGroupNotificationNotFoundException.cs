
namespace WireChat.Domain.Exceptions
{
    public sealed class CreatedGroupNotificationNotFoundException : DomainException
    {
        internal CreatedGroupNotificationNotFoundException(Guid notificationHubID, Guid groupId) 
            : base(message: $"Created group notification for group with ID #{groupId} was not found in NotificationHub with ID #{notificationHubID}!")
        {
        }
    }
}
