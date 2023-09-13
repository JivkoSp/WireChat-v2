
namespace WireChat.Domain.Exceptions
{
    public sealed class InvalidMessageDateTimeException : DomainException
    {
        internal InvalidMessageDateTimeException() : base(message: "Invalid Message datetime!")
        {
        }
    }
}
