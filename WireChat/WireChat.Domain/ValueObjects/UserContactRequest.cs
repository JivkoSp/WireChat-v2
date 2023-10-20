using WireChat.Domain.Exceptions;

namespace WireChat.Domain.ValueObjects
{
    public record UserContactRequest
    {
        public UserID SenderUserId { get; }
        public UserID ReceiverUserId { get; }
        internal string Message { get; }

        public UserContactRequest(UserID senderUserId, UserID receiverUserId, string message)
        {
            if (senderUserId == null)
            {
                throw new NullContactRequestSenderUserIdException();
            }

            if(receiverUserId == null)
            {
                throw new NullContactRequestReceiverUserIdException();
            }

            if(string.IsNullOrWhiteSpace(message))
            {
                throw new EmptyContactRequestMessageException();
            }

            SenderUserId = senderUserId;
            ReceiverUserId = receiverUserId;
            Message = message;
        }
    }
}
