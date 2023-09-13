
namespace WireChat.Domain.Exceptions
{
    public sealed class NullChatMessageParametersException : DomainException
    {
        internal NullChatMessageParametersException() 
            : base(message: "ChatMessage cannot be initialized with one or more null parameters!")
        {
        }
    }
}
