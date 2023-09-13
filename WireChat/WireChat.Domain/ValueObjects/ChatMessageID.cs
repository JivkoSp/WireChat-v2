using WireChat.Domain.Exceptions;

namespace WireChat.Domain.ValueObjects
{
    public record ChatMessageID
    {
        public Guid Value { get; }

        public ChatMessageID(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptyChatMessageIdException();
            }

            Value = value;
        }

        //Conversion from ValueObject to Guid.
        public static implicit operator Guid(ChatMessageID chatMessageId)
            => chatMessageId.Value;

        //Conversion from Guid to ValueObject.
        public static implicit operator ChatMessageID(Guid chatMessageId)
            => new ChatMessageID(chatMessageId);
    }
}
