
namespace WireChat.Domain.Exceptions
{
    public sealed class EmptyContactRequestMessageException : DomainException
    {
        internal EmptyContactRequestMessageException() : base(message: "The ContactRequest Message cannot be empty!")
        {
        }
    }
}
