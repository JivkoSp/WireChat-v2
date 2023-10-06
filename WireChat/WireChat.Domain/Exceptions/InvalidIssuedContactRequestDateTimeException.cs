
namespace WireChat.Domain.Exceptions
{
    public sealed class InvalidIssuedContactRequestDateTimeException : DomainException
    {
        internal InvalidIssuedContactRequestDateTimeException() : base(message: "Invalid IssuedContactRequest datetime!")
        {
        }
    }
}
