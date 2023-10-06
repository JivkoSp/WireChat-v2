
namespace WireChat.Domain.Exceptions
{
    public sealed class RemovedGroupMemberNotificationAlreadyExistsException : DomainException
    {
        internal RemovedGroupMemberNotificationAlreadyExistsException(Guid groupMemberUserId, Guid groupId) 
            : base(message: $"Removed group member notification for user with ID #{groupMemberUserId} and group with ID #{groupId} already exists!")
        {
        }
    }
}
