using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Repositories
{
    public interface IGroupRepository
    {
        Task<Group> GetGroupByIdAsync(ChatID groupId);
        Task AddGroupAsync(Group group);
        Task UpdateGroupAsync(Group group);
        Task DeleteGroupAsync(Group group);
    }
}
