
namespace WireChat.Domain.Exceptions
{
    public sealed class ActiveGroupNotificationNotFoundException : DomainException
    {
        internal ActiveGroupNotificationNotFoundException(Guid notificationHubID, Guid groupId) 
            : base(message: $"Active group notification for group with ID #{groupId} was not found in NotificationHub with ID #{notificationHubID}!")
        {
        }
    }
}
