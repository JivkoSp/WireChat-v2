
namespace WireChat.Domain.Exceptions
{
    public sealed class InvalidAddedGroupMemberDateTimeException : DomainException
    {
        internal InvalidAddedGroupMemberDateTimeException() : base(message: "Invalid AddedGroupMember datetime!")
        {
        }
    }
}
