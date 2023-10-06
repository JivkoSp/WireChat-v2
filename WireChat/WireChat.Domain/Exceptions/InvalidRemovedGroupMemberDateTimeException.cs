
namespace WireChat.Domain.Exceptions
{
    public sealed class InvalidRemovedGroupMemberDateTimeException : DomainException
    {
        internal InvalidRemovedGroupMemberDateTimeException() : base(message: "Invalid RemovedGroupMember datetime!")
        {
        }
    }
}
