
namespace WireChat.Domain.Exceptions
{
    public sealed class InvalidBannedGroupMemberDateTimeException : DomainException
    {
        internal InvalidBannedGroupMemberDateTimeException() : base(message: "Invalid BannedGroupMember datetime!")
        {
        }
    }
}
