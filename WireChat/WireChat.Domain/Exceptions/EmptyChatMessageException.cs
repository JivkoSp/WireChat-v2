
namespace WireChat.Domain.Exceptions
{
    public sealed class EmptyChatMessageException : DomainException
    {
        internal EmptyChatMessageException() : base(message: "Chat message cannot be empty!")
        {
        }
    }
}
