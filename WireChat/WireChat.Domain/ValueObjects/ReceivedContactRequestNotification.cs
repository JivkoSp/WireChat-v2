using WireChat.Domain.Exceptions;

namespace WireChat.Domain.ValueObjects
{
    public record ReceivedContactRequestNotification
    {
        public UserID SenderUserId { get; }
        public UserID ReceiverUserId { get; }
        public NotificationHubID NotificationHubId { get; set; }
        internal DateTimeOffset DateTime { get; }

        public ReceivedContactRequestNotification(UserID senderUserId, UserID receiverUserId, 
            NotificationHubID notificationHubId, DateTimeOffset dateTime)
        {
            if (senderUserId == null)
            {
                throw new NullUserIdException();
            }

            if (receiverUserId == null)
            {
                throw new NullUserIdException();
            }

            if (notificationHubId == null)
            {
                throw new NullNotificationHubIdException();
            }

            if (dateTime == default || dateTime > DateTimeOffset.Now)
            {
                throw new InvalidReceivedContactRequestDateTimeException();
            }

            SenderUserId = senderUserId;
            ReceiverUserId = receiverUserId;
            NotificationHubId = notificationHubId;
            DateTime = dateTime;
        }
    }
}
