
namespace WireChat.Domain.Exceptions
{
    public sealed class NullContactRequestReceiverUserIdException : DomainException
    {
        internal NullContactRequestReceiverUserIdException() : base(message: "The UserID for ContactRequest Receiver cannot be null!")
        {
        }
    }
}
