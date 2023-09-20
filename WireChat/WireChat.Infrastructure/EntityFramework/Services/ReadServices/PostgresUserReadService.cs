using Microsoft.EntityFrameworkCore;
using WireChat.Application.Services.ReadServices;
using WireChat.Infrastructure.EntityFramework.Contexts;

namespace WireChat.Infrastructure.EntityFramework.Services.ReadServices
{
    internal sealed class PostgresUserReadService : IUserReadService
    {
        private readonly ReadDbContext _readDbContext;

        public PostgresUserReadService(ReadDbContext readDbContext)
        {
            _readDbContext = readDbContext;
        }

        public Task<bool> ExistsByIdAsync(Guid id)
            => _readDbContext.UserReadModels.AnyAsync(x => x.Id == id.ToString());
    }
}
