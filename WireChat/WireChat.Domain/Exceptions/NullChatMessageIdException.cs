
namespace WireChat.Domain.Exceptions
{
    public sealed class NullChatMessageIdException : DomainException
    {
        internal NullChatMessageIdException() : base(message: "ChatMessageId cannot be null!")
        {
        }
    }
}
