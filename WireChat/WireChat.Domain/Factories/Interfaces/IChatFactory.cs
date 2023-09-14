using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Factories.Interfaces
{
    public interface IChatFactory
    {
        Chat Create(ChatID chatId, ChatType chatType);
    }
}
