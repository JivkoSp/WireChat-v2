
namespace WireChat.Domain.Exceptions
{
    public sealed class BlockedChatUserNotFoundException : DomainException
    {
        internal BlockedChatUserNotFoundException(Guid userId, Guid chatId) 
            : base(message: $"There is no chat with ID #{chatId} that has blocked user with ID #{userId}!")
        {
        }
    }
}
