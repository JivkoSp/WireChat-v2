using WireChat.Domain.Exceptions;

namespace WireChat.Domain.ValueObjects
{
    public record CreatedGroupNotification
    {
        public UserID UserId { get; }
        public GroupID GroupId { get; }
        public NotificationHubID NotificationHubId { get; set; }
        internal DateTimeOffset DateTime { get; }

        public CreatedGroupNotification(UserID userId, GroupID groupId, NotificationHubID notificationHubId, DateTimeOffset dateTime)
        {
            if (userId == null)
            {
                throw new NullUserIdException();
            }

            if (groupId == null)
            {
                throw new NullGroupIdException();
            }

            if (notificationHubId == null)
            {
                throw new NullNotificationHubIdException();
            }

            if (dateTime == default || dateTime > DateTimeOffset.Now)
            {
                throw new InvalidCreatedGroupDateTimeException();
            }

            UserId = userId;
            GroupId = groupId;
            NotificationHubId = notificationHubId;
            DateTime = dateTime;
        }
    }
}
