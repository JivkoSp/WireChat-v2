
namespace WireChat.Domain.Exceptions
{
    public sealed class BlockedChatUserAlreadyExistsException : DomainException
    {
        internal BlockedChatUserAlreadyExistsException(Guid userId, Guid chatId) 
            : base(message: $"User with ID #{userId} is already blocked from chat with ID #{chatId}!")
        {
        }
    }
}
