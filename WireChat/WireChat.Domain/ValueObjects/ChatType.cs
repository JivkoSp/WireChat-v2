using WireChat.Domain.Exceptions;

namespace WireChat.Domain.ValueObjects
{
    public record ChatType
    {
        internal string Value { get; }

        public ChatType(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyChatTypeException();
            }

            Value = value;
        }

        //Conversion from ValueObject to String.
        public static implicit operator string(ChatType chatType)
            => chatType.Value;

        //Conversion from String to ValueObject.
        public static implicit operator ChatType(string chatType)
            => new ChatType(chatType);
    }
}