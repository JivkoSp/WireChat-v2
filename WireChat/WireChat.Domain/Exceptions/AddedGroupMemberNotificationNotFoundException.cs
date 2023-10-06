
namespace WireChat.Domain.Exceptions
{
    public sealed class AddedGroupMemberNotificationNotFoundException : DomainException
    {
        internal AddedGroupMemberNotificationNotFoundException(Guid notificationHubID, Guid groupMemberUserId) 
            : base(message: $"Added group member notification for user with ID #{groupMemberUserId} was not found in NotificationHub with ID #{notificationHubID}!")
        {
        }
    }
}
