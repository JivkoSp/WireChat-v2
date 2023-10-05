using WireChat.Domain.Exceptions;

namespace WireChat.Domain.ValueObjects
{
    public record CreatedGroupNotification
    {
        public UserID UserId { get; }
        public GroupID GroupId { get; }
        internal DateTimeOffset DateTime { get; }

        public CreatedGroupNotification(UserID userId, GroupID groupId, DateTimeOffset dateTime)
        {
            if (userId == null)
            {
                throw new NullUserIdException();
            }

            if (groupId == null)
            {
                throw new NullGroupIdException();
            }

            if (dateTime == default || dateTime > DateTimeOffset.Now)
            {
                throw new InvalidCreatedGroupDateTimeException();
            }

            UserId = userId;
            GroupId = groupId;
            DateTime = dateTime;
        }
    }
}
