
namespace WireChat.Domain.Exceptions
{
    public sealed class NullGroupIdException : DomainException
    {
        internal NullGroupIdException() : base(message: "GroupId cannot be null!")
        {
        }
    }
}
