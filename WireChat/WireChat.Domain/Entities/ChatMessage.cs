using WireChat.Domain.Exceptions;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Entities
{
    public class ChatMessage : AggregateRoot<ChatMessageID>
    {
        private UserID _userID;
        private Message _message;
        private MessageDateTime _messageDateTime;

        private ChatMessage() {}

        internal ChatMessage(ChatMessageID chatMessageId, UserID userId, Message message, MessageDateTime messageDateTime)
        {
            ValidateConstructorParameters<NullChatMessageParametersException>([chatMessageId, userId, message, messageDateTime]);

            Id = chatMessageId;
            _userID = userId;
            _message = message;
            _messageDateTime = messageDateTime;
        }
    }
}
