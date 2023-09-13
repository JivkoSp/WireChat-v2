
namespace WireChat.Domain.Exceptions
{
    public sealed class NullChatIdException : DomainException
    {
        internal NullChatIdException() : base(message: "ChatId cannot be null!")
        {
        }
    }
}
