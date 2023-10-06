
namespace WireChat.Domain.Exceptions
{
    public sealed class InvalidRemovedChatMessageDateTimeException : DomainException
    {
        internal InvalidRemovedChatMessageDateTimeException() : base(message: "Invalid RemovedChatMessage datetime!")
        {
        }
    }
}
