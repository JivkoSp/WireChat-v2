
namespace WireChat.Domain.Exceptions
{
    public sealed class InvalidBannedContactDateTimeException : DomainException
    {
        internal InvalidBannedContactDateTimeException() : base(message: "Invalid BannedContact datetime!")
        {
        }
    }
}
