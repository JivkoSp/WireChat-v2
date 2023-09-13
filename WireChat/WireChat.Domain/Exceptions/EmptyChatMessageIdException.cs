
namespace WireChat.Domain.Exceptions
{
    public sealed class EmptyChatMessageIdException : DomainException
    {
        internal EmptyChatMessageIdException() : base(message: "ChatMessage id cannot be empty!")
        {
        }
    }
}
