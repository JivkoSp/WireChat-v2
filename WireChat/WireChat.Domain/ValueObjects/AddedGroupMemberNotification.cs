﻿using WireChat.Domain.Exceptions;

namespace WireChat.Domain.ValueObjects
{
    public record AddedGroupMemberNotification
    {
        public UserID GroupAdminUserId { get; }
        public UserID GroupMemberUserId { get; }
        public GroupID GroupId { get; }
        public NotificationHubID NotificationHubId { get; set; }
        internal DateTimeOffset DateTime { get; }

        public AddedGroupMemberNotification(UserID groupAdminUserId, UserID groupMemberUserId, GroupID groupId,
           NotificationHubID notificationHubId, DateTimeOffset dateTime)
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

            if (notificationHubId == null)
            {
                throw new NullNotificationHubIdException();
            }

            if (dateTime == default || dateTime > DateTimeOffset.Now)
            {
                throw new InvalidAddedGroupMemberDateTimeException();
            }

            GroupAdminUserId = groupAdminUserId;
            GroupMemberUserId = groupMemberUserId;
            GroupId = groupId;
            NotificationHubId = notificationHubId;
            DateTime = dateTime;
        }
    }
}
