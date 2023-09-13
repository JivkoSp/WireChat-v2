
namespace WireChat.Domain.Exceptions
{
    public sealed class ChatUserAlreadyExistsException : DomainException
    {
        internal ChatUserAlreadyExistsException(Guid userId, Guid chatId) 
            : base(message: $"User #{userId} already exists in chat #{chatId}!")
        {
        }
    }
}
