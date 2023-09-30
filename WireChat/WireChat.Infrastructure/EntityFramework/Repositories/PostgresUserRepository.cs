using Microsoft.EntityFrameworkCore;
using WireChat.Domain.Entities;
using WireChat.Domain.Repositories;
using WireChat.Domain.ValueObjects;
using WireChat.Infrastructure.EntityFramework.Contexts;

namespace WireChat.Infrastructure.EntityFramework.Repositories
{
    internal sealed class PostgresUserRepository : IUserRepository
    {
        private readonly WriteDbContext _writeDbContext;

        public PostgresUserRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
        }

        public Task<User> GetUserByIdAsync(UserID userId)
            => _writeDbContext.Users
                .Include(x => x.SendedContactRequests)
                .Include(x => x.ReceivedContactRequests)
                .SingleOrDefaultAsync(x => x.Id == userId);

        // TODO
        // Maybe delete the below methods because they are more related to Identity, rather than the Domain layer.

        public async Task AddUserAsync(User user)
        {
            await _writeDbContext.Users.AddAsync(user);

            await _writeDbContext.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _writeDbContext.Users.Update(user);

            await _writeDbContext.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            _writeDbContext.Users.Remove(user);

            await _writeDbContext.SaveChangesAsync();
        }
    }
}
