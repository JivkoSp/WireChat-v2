
namespace WireChat.Domain.Exceptions
{
    public sealed class EmptyChatIdException : DomainException
    {
        internal EmptyChatIdException() : base(message: "Chat id cannot be empty!")
        {
        }
    }
}
