
namespace WireChat.Domain.Exceptions
{
    public sealed class NullChatParametersException : DomainException
    {
        internal NullChatParametersException() : base(message: "The Chat cannot be initialized with one or more null parameters!")
        {
        }
    }
}
