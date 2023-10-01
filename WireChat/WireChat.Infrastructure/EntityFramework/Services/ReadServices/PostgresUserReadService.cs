using Microsoft.EntityFrameworkCore;
using WireChat.Application.Queries;
using WireChat.Application.Queries.Dispatcher;
using WireChat.Application.Services.ReadServices;
using WireChat.Infrastructure.EntityFramework.Contexts;

namespace WireChat.Infrastructure.EntityFramework.Services.ReadServices
{
    internal sealed class PostgresUserReadService : IUserReadService
    {
        private readonly ReadDbContext _readDbContext;
        private readonly IQueryDispatcher _queryDispatcher;

        public PostgresUserReadService(ReadDbContext readDbContext, IQueryDispatcher queryDispatcher)
        {
            _readDbContext = readDbContext;
            _queryDispatcher = queryDispatcher;
        }

        public Task<bool> ExistsByIdAsync(Guid id)
            => _readDbContext.UserReadModels.AnyAsync(x => x.Id == id.ToString());

        public async Task<bool> HasUserInContactsAsync(Guid userId, Guid otherUserId)
        {
            var getContactsQuery = new GetContactsQuery(userId.ToString());

            var chatUserReadModels = await _queryDispatcher.DispatchAsync(getContactsQuery);

            return chatUserReadModels.Any(x => x.UserId == otherUserId.ToString());
        }
    }
}
