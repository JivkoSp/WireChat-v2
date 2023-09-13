
namespace WireChat.Domain.Exceptions
{
    public sealed class ChatMessageNotFoundException : DomainException
    {
        internal ChatMessageNotFoundException(Guid chatMessageId) 
            : base(message: $"There is no chat message with ID #{chatMessageId}!")
        {
        }
    }
}
