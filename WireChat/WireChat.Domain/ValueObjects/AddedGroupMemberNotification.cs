using WireChat.Domain.Exceptions;

namespace WireChat.Domain.ValueObjects
{
    public record AddedGroupMemberNotification
    {
        public UserID GroupAdminUserId { get; }
        public UserID GroupMemberUserId { get; }
        public GroupID GroupId { get; }
        internal DateTimeOffset DateTime { get; }

        public AddedGroupMemberNotification(UserID groupAdminUserId, UserID groupMemberUserId, GroupID groupId, DateTimeOffset dateTime)
        {
            if (groupAdminUserId == null)
            {
                throw new NullUserIdException();
            }

            if (groupMemberUserId == null)
            {
                throw new NullUserIdException();
            }

            if (groupId == null)
            {
                throw new NullGroupIdException();
            }

            if (dateTime == default || dateTime > DateTimeOffset.Now)
            {
                throw new InvalidAddedGroupMemberDateTimeException();
            }

            GroupAdminUserId = groupAdminUserId;
            GroupMemberUserId = groupMemberUserId;
            GroupId = groupId;
            DateTime = dateTime;
        }
    }
}
