
namespace WireChat.Domain.Exceptions
{
    public sealed class UserContactRequestNotFoundException : DomainException
    {
        internal UserContactRequestNotFoundException(Guid senderUserId) 
            : base(message: $"There is no contact request from User with ID #{senderUserId}!")
        {
        }
    }
}
