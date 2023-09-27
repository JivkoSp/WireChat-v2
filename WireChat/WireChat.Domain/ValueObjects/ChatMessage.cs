using WireChat.Domain.Exceptions;

namespace WireChat.Domain.ValueObjects
{
    public record ChatMessage
    {
        public ChatMessageID ChatMessageID { get; }
        public ChatID ChatID { get; }
        public UserID UserID { get; }
        internal string Message { get; }
        internal DateTimeOffset DateTime { get; }

        private ChatMessage() {}

        public ChatMessage(ChatMessageID chatMessageId, ChatID chatId, UserID userId, string message, DateTimeOffset dateTime)
        {
            if(chatMessageId == null)
            {
                throw new NullChatMessageIdException();
            }

            if (chatId == null)
            {
                throw new NullChatIdException();
            }

            if (userId == null)
            {
                throw new NullUserIdException();
            }

            if (string.IsNullOrWhiteSpace(message))
            {
                throw new EmptyChatMessageException();
            }

            if (dateTime == default || dateTime > DateTimeOffset.Now)
            {
                throw new InvalidMessageDateTimeException();
            }

            ChatMessageID = chatMessageId;
            ChatID = chatId;
            UserID = userId;
            Message = message;
            DateTime = dateTime;
        }
    }
}
