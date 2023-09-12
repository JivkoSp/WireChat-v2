
namespace WireChat.Domain.Exceptions
{
    public sealed class EmptyUserFirstNameException : DomainException
    {
        internal EmptyUserFirstNameException() : base(message: "User first name cannot be empty!")
        {
        }
    }
}
