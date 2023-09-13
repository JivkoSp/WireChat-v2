
namespace WireChat.Domain.Exceptions
{
    public sealed class EmptyChatTypeException : DomainException
    {
        internal EmptyChatTypeException() : base(message: "The ChatType cannot be empty!")
        {
        }
    }
}
