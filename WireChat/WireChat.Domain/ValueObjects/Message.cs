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
    }
}
