
namespace WireChat.Application.Exceptions
{
    public sealed class ChatNotFoundException : ApplicationException
    {
        internal ChatNotFoundException(Guid chatId) 
            : base(message: $"Chat with ID #{chatId} was NOT found!")
        {
        }
    }
}
