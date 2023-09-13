using WireChat.Domain.Exceptions;

namespace WireChat.Domain.ValueObjects
{
    public record ChatID
    {
        public Guid Value { get; }

        public ChatID(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptyChatIdException();
            }

            Value = value;
        }

        //Conversion from ValueObject to Guid.
        public static implicit operator Guid(ChatID chatId)
            => chatId.Value;

        //Conversion from Guid to ValueObject.
        public static implicit operator ChatID(Guid chatId)
            => new ChatID(chatId);
    }
}
