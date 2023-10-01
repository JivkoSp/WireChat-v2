using WireChat.Domain.Entities;
using WireChat.Domain.Factories.Interfaces;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Factories
{
    public class GroupFactory : IGroupFactory
    {
        public Group Create(ChatID chatId, GroupName groupName, Chat chat)
            => new Group(chatId, groupName, chat);
    }
}
