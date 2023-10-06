
namespace WireChat.Domain.Exceptions
{
    public sealed class InvalidReceivedContactRequestDateTimeException : DomainException
    {
        internal InvalidReceivedContactRequestDateTimeException() : base(message: "Invalid ReceivedContactRequest datetime!")
        {
        }
    }
}
