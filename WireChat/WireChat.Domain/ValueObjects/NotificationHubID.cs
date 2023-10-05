using WireChat.Domain.Exceptions;

namespace WireChat.Domain.ValueObjects
{
    public record NotificationHubID
    {
        public Guid Value { get; }

        public NotificationHubID(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptyNotificationIdException();
            }

            Value = value;
        }

        //Conversion from ValueObject to Guid.
        public static implicit operator Guid(NotificationHubID notificationId)
            => notificationId.Value;

        //Conversion from Guid to ValueObject.
        public static implicit operator NotificationHubID(Guid notificationId)
            => new NotificationHubID(notificationId);
    }
}
