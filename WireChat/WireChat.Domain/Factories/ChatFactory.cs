using WireChat.Domain.Entities;
using WireChat.Domain.Factories.Interfaces;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Factories
{
    public sealed class ChatFactory : IChatFactory
    {
        public Chat Create(ChatID chatId, ChatType chatType)
            => new Chat(chatId, chatType);
    }
}
