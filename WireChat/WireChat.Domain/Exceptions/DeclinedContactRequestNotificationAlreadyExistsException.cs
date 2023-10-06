
namespace WireChat.Domain.Exceptions
{
    public sealed class DeclinedContactRequestNotificationAlreadyExistsException : DomainException
    {
        internal DeclinedContactRequestNotificationAlreadyExistsException(Guid senderUserId) 
            : base(message: $"Declined contact request notification by user with ID #{senderUserId} already exists!")
        {
        }
    }
}
