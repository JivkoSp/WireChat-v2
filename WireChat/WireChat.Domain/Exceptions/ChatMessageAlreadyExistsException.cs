
namespace WireChat.Domain.Exceptions
{
    public sealed class ChatMessageAlreadyExistsException : DomainException
    {
        internal ChatMessageAlreadyExistsException(Guid chatMessageId) 
            : base(message: $"Chat message with ID #{chatMessageId} already exists!")
        {
        }
    }
}
