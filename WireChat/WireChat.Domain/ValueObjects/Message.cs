using WireChat.Domain.Exceptions;

namespace WireChat.Domain.ValueObjects
{
    public record Message
    {
        internal string Value { get; }

        public Message(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyChatMessageException();
            }

            Value = value;
        }

        //Conversion from ValueObject to String.
        public static implicit operator string(Message message)
            => message.Value;

        //Conversion from String to ValueObject.
        public static implicit operator Message(string message)
            => new Message(message);
    }
}
