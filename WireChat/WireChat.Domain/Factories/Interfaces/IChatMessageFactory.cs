using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Factories.Interfaces
{
    public interface IChatMessageFactory
    {
        ChatMessage Create(ChatMessageID chatMessageId, UserID userId, Message message, MessageDateTime messageDateTime);
    }
}
