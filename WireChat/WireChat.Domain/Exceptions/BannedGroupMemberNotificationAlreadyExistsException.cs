
namespace WireChat.Domain.Exceptions
{
    public sealed class BannedGroupMemberNotificationAlreadyExistsException : DomainException
    {
        internal BannedGroupMemberNotificationAlreadyExistsException(Guid notificationHubID, Guid userId) 
            : base(message: $"Banned group member notification for user with ID #{userId} already exists in notification hub with ID #{notificationHubID}!")
        {
        }
    }
}
