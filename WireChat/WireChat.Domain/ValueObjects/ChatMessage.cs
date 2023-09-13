using WireChat.Domain.Exceptions;

namespace WireChat.Domain.ValueObjects
{
    public record ChatMessage
    {
        public UserID UserID { get; }
        public string Value { get; }

        public ChatMessage(UserID userId, string value)
        {
            if (userId == null)
            {
                throw new NullUserIdException();
            }

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyChatMessageException();
            }

            UserID = userId;
            Value = value;
        }
    }
}
