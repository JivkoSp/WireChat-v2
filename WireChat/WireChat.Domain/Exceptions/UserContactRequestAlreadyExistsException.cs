
namespace WireChat.Domain.Exceptions
{
    public sealed class UserContactRequestAlreadyExistsException : DomainException
    {
        internal UserContactRequestAlreadyExistsException(Guid senderUserId) 
            : base(message: $"Contact request from User with ID #{senderUserId} already exists!")
        {
        }
    }
}
