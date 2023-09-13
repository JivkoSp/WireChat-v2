
namespace WireChat.Domain.Exceptions
{
    public sealed class ChatUserNotFoundException : DomainException
    {
        internal ChatUserNotFoundException(Guid userId, Guid chatId) 
            : base(message: $"There is no chat with ID #{chatId} that has user #{userId}!")
        {
        }
    }
}
