
namespace WireChat.Application.Exceptions
{
    internal class ChatNotFoundException : ApplicationException
    {
        internal ChatNotFoundException(Guid chatId) 
            : base(message: $"Chat with ID #{chatId} was NOT found!")
        {
        }
    }
}
