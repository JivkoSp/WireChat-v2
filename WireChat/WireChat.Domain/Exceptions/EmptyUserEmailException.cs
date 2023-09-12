
namespace WireChat.Domain.Exceptions
{
    public sealed class EmptyUserEmailException : DomainException
    {
        internal EmptyUserEmailException() : base(message: "User email cannot be empty!")
        {
        }
    }
}
