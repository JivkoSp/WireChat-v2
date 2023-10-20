using Microsoft.EntityFrameworkCore;
using WireChat.Application.Services.ReadServices;
using WireChat.Infrastructure.EntityFramework.Contexts;

namespace WireChat.Infrastructure.EntityFramework.Services.ReadServices
{
    internal sealed class PostgresGroupReadService : IGroupReadService
    {
        private readonly ReadDbContext _readDbContext;

        public PostgresGroupReadService(ReadDbContext readDbContext)
        {
            _readDbContext = readDbContext;
        }

        public Task<bool> ExistsByIdAsync(Guid id)
            => _readDbContext.Groups.AnyAsync(x => x.GroupId == id);
    }
}
