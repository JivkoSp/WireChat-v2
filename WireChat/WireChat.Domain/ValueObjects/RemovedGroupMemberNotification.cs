using WireChat.Domain.Exceptions;

namespace WireChat.Domain.ValueObjects
{
    public record RemovedGroupMemberNotification
    {
        public UserID GroupAdminUserId { get; }
        public UserID GroupMemberUserId { get; }
        public GroupID GroupId { get; }
        internal DateTimeOffset DateTime { get; }

        public RemovedGroupMemberNotification(UserID groupAdminUserId, UserID groupMemberUserId, GroupID groupId, DateTimeOffset dateTime)
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
                throw new InvalidRemovedGroupMemberDateTimeException();
            }

            GroupAdminUserId = groupAdminUserId;
            GroupMemberUserId = groupMemberUserId;
            GroupId = groupId;
            DateTime = dateTime;
        }
    }
}
