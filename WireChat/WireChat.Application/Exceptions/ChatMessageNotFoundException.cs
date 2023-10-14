
namespace WireChat.Application.Exceptions
{
    public sealed class ChatMessageNotFoundException : ApplicationException
    {
        internal ChatMessageNotFoundException(Guid chatMessageId) 
            : base(message: $"Chat message with ID #{chatMessageId} was NOT found!")
        {
        }
    }
}
