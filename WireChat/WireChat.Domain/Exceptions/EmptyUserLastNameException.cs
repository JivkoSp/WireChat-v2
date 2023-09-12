
namespace WireChat.Domain.Exceptions
{
    public sealed class EmptyUserLastNameException : DomainException
    {
        internal EmptyUserLastNameException() : base(message: "User last name cannot be empty!")
        {
        }
    }
}
