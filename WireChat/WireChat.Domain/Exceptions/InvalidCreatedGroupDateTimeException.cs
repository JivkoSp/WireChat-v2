
namespace WireChat.Domain.Exceptions
{
    public sealed class InvalidCreatedGroupDateTimeException : DomainException
    {
        internal InvalidCreatedGroupDateTimeException() : base(message: "Invalid CreatedGroup datetime!")
        {
        }
    }
}
