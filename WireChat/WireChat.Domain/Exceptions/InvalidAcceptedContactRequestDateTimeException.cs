
namespace WireChat.Domain.Exceptions
{
    public sealed class InvalidAcceptedContactRequestDateTimeException : DomainException
    {
        internal InvalidAcceptedContactRequestDateTimeException() : base(message: "Invalid AcceptedContactRequest datetime!")
        {
        }
    }
}
