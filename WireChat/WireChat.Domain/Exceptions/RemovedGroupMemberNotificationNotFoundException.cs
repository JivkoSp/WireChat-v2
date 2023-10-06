
namespace WireChat.Domain.Exceptions
{
    public sealed class RemovedGroupMemberNotificationNotFoundException : DomainException
    {
        internal RemovedGroupMemberNotificationNotFoundException(Guid notificationHubID, Guid userId) 
            : base(message: $"Removed group member notification for user with ID #{userId} was not found in NotificationHub with ID #{notificationHubID}!")
        {
        }
    }
}
