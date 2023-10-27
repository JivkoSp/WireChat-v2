using WireChat.Domain.Exceptions;

namespace WireChat.Domain.ValueObjects
{
    public record BannedContactNotification
    {
        public UserID UserId { get; }
        public ChatID ChatId { get; set; }
        public NotificationHubID NotificationHubId { get; set; }
        internal DateTimeOffset DateTime { get; }

        public BannedContactNotification(UserID userId, ChatID chatId, NotificationHubID notificationHubId, DateTimeOffset dateTime)
        {
            if (userId == null)
            {
                throw new NullUserIdException();
            }

            if (chatId == null)
            {
                throw new NullChatIdException();
            }

            if (notificationHubId == null)
            {
                throw new NullNotificationHubIdException();
            }

            if (dateTime == default || dateTime > DateTimeOffset.Now)
            {
                throw new InvalidBannedContactDateTimeException();
            }

            UserId = userId;
            ChatId = chatId;
            NotificationHubId = notificationHubId;
            DateTime = dateTime;
        }
    }
}
