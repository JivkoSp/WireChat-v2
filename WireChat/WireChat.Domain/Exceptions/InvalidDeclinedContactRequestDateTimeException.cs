
namespace WireChat.Domain.Exceptions
{
    public sealed class InvalidDeclinedContactRequestDateTimeException : DomainException
    {
        internal InvalidDeclinedContactRequestDateTimeException() : base(message: "Invalid DeclinedContact datetime!")
        {
        }
    }
}
