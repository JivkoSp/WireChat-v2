using WireChat.Domain.Exceptions;

namespace WireChat.Domain.ValueObjects
{
    public record IssuedContactRequestNotification
    {
        public UserID SenderUserId { get; }
        public UserID ReceiverUserId { get; }
        internal DateTimeOffset DateTime { get; }

        public IssuedContactRequestNotification(UserID senderUserId, UserID receiverUserId, DateTimeOffset dateTime)
        {
            if (senderUserId == null)
            {
                throw new NullUserIdException();
            }

            if (receiverUserId == null)
            {
                throw new NullUserIdException();
            }

            if (dateTime == default || dateTime > DateTimeOffset.Now)
            {
                throw new InvalidIssuedContactRequestDateTimeException();
            }

            SenderUserId = senderUserId;
            ReceiverUserId = receiverUserId;
            DateTime = dateTime;
        }
    }
}
