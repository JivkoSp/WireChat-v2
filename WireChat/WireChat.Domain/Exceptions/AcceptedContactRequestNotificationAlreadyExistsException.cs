
namespace WireChat.Domain.Exceptions
{
    public sealed class AcceptedContactRequestNotificationAlreadyExistsException : DomainException
    {
        internal AcceptedContactRequestNotificationAlreadyExistsException(Guid senderUserId) 
            : base(message: $"Accepted contact request notification from user with ID #{senderUserId} already exists!")
        {
        }
    }
}
