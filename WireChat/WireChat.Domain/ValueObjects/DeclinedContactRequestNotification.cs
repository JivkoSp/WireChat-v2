using WireChat.Domain.Exceptions;

namespace WireChat.Domain.ValueObjects
{
    public record DeclinedContactRequestNotification
    {
        public UserID SenderUserId { get; }
        public UserID ReceiverUserId { get; }
        internal DateTimeOffset DateTime { get; }

        public DeclinedContactRequestNotification(UserID senderUserId, UserID receiverUserId, DateTimeOffset dateTime)
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
                throw new InvalidDeclinedContactRequestDateTimeException();
            }

            SenderUserId = senderUserId;
            ReceiverUserId = receiverUserId;    
            DateTime = dateTime;
        }
    }
}
