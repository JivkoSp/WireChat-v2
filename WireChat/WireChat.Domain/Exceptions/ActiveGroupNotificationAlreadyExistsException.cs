
namespace WireChat.Domain.Exceptions
{
    public sealed class ActiveGroupNotificationAlreadyExistsException : DomainException
    {
        internal ActiveGroupNotificationAlreadyExistsException(Guid groupId) 
            : base(message: $"Active group notification for group with ID #{groupId} already exists!")
        {
        }
    }
}
