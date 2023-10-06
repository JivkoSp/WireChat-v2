
namespace WireChat.Domain.Exceptions
{
    public sealed class AddedGroupMemberNotificationAlreadyExistsException : DomainException
    {
        internal AddedGroupMemberNotificationAlreadyExistsException(Guid groupMemberUserId, Guid groupId) 
            : base(message: $"Added group member notification for user with ID #{groupMemberUserId} and group with ID #{groupId} already exists!")
        {
        }
    }
}
