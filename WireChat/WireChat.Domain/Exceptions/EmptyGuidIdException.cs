
namespace WireChat.Domain.Exceptions
{
    public sealed class EmptyGuidIdException : DomainException
    {
        internal EmptyGuidIdException() : base(message: "Guid id cannot be empty!")
        {
        }
    }
}
