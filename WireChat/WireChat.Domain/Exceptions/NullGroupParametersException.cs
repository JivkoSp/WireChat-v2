
namespace WireChat.Domain.Exceptions
{
    public sealed class NullGroupParametersException : DomainException
    {
        internal NullGroupParametersException() : base(message: "Group cannot be initialized with one or more null parameters!")
        {
        }
    }
}
