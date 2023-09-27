using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Factories.Interfaces
{
    public interface IGroupFactory
    {
        Group Create(GroupID groupId, GroupName groupName, Chat chat);
    }
}
