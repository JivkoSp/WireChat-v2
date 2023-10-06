
namespace WireChat.Domain.Exceptions
{
    public sealed class IssuedContactRequestNotificationAlreadyExistsException : DomainException
    {
        internal IssuedContactRequestNotificationAlreadyExistsException(Guid receiverUserId) 
            : base(message: $"Issued contact request notification to user with ID #{receiverUserId} already exists!")
        {
        }
    }
}
