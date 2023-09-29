using Microsoft.EntityFrameworkCore;
using WireChat.Domain.Entities;
using WireChat.Domain.Repositories;
using WireChat.Domain.ValueObjects;
using WireChat.Infrastructure.EntityFramework.Contexts;

namespace WireChat.Infrastructure.EntityFramework.Repositories
{
    internal sealed class PostgresGroupRepository : IGroupRepository
    {
        private readonly WriteDbContext _writeDbContext;

        public PostgresGroupRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
        }

        public Task<Group> GetGroupByIdAsync(GroupID groupId)
            => _writeDbContext.Groups
                .SingleOrDefaultAsync(x => x.Id == groupId);

        public async Task AddGroupAsync(Group group)
        {
            await _writeDbContext.Groups.AddAsync(group);

            await _writeDbContext.SaveChangesAsync();
        }

        public async Task UpdateGroupAsync(Group group)
        {
            _writeDbContext.Groups.Update(group);

            await _writeDbContext.SaveChangesAsync();
        }

        public async Task DeleteGroupAsync(Group group)
        {
            _writeDbContext.Groups.Remove(group);

            await _writeDbContext.SaveChangesAsync();
        }
    }
}
