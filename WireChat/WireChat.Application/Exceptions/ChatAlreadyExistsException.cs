namespace WireChat.Application.Exceptions
{
    public sealed class ChatAlreadyExistsException : ApplicationException
    {
        internal ChatAlreadyExistsException(Guid chatId) : base(message: $"Chat with ID #{chatId} already exists!")
        {
        }
    }
}