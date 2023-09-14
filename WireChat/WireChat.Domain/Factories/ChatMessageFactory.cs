using WireChat.Domain.Entities;
using WireChat.Domain.Factories.Interfaces;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Factories
{
    public sealed class ChatMessageFactory : IChatMessageFactory
    {
        public ChatMessage Create(ChatMessageID chatMessageId, UserID userId, Message message, MessageDateTime messageDateTime)
            => new ChatMessage(chatMessageId, userId, message, messageDateTime);
    }
}
