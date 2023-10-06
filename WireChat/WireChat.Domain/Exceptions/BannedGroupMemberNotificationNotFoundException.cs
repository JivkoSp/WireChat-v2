
namespace WireChat.Domain.Exceptions
{
    public sealed class BannedGroupMemberNotificationNotFoundException : DomainException
    {
        internal BannedGroupMemberNotificationNotFoundException(Guid notificationHubID, Guid userId) 
            : base(message: $"Banned group member notification for user with ID #{userId} was not found in NotificationHub with ID #{notificationHubID}!")
        {
        }
    }
}
