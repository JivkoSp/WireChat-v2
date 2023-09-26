
namespace WireChat.Domain.Exceptions
{
    public sealed class EmptyGroupNameException : DomainException
    {
        internal EmptyGroupNameException() : base(message: "Group name cannot be empty!")
        {
        }
    }
}
