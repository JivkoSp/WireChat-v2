
namespace WireChat.Domain.Exceptions
{
    public sealed class EmptyUserNameException : DomainException
    {
        internal EmptyUserNameException() : base(message: "Username cannot be empty!")
        {
        }
    }
}
