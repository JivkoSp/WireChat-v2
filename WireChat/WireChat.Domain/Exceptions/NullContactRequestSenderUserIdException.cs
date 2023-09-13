
namespace WireChat.Domain.Exceptions
{
    public sealed class NullContactRequestSenderUserIdException : DomainException
    {
        internal NullContactRequestSenderUserIdException() : base(message: "The UserID for ContactRequest Sender cannot be null!")
        {
        }
    }
}
