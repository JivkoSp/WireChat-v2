using WireChat.Domain.Exceptions;

namespace WireChat.Domain.ValueObjects
{
    public record ActiveGroupNotification
    {
        public GroupID GroupId { get; }
        public NotificationHubID NotificationHubId { get; set; }
        public ActiveGroupNotification(GroupID groupId, NotificationHubID notificationHubId)
        {
            if (groupId == null)
            {
                throw new NullGroupIdException();
            }

            if (notificationHubId == null)
            {
                throw new NullNotificationHubIdException();
            }

            GroupId = groupId;
            NotificationHubId = notificationHubId;
        }
    }
}
