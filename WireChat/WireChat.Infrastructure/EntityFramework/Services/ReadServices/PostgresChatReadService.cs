using Microsoft.EntityFrameworkCore;
using WireChat.Application.Services.ReadServices;
using WireChat.Infrastructure.EntityFramework.Contexts;

namespace WireChat.Infrastructure.EntityFramework.Services.ReadServices
{
    internal sealed class PostgresChatReadService : IChatReadService
    {
        private readonly ReadDbContext _readDbContext;

        public PostgresChatReadService(ReadDbContext readDbContext)
        {
            _readDbContext = readDbContext;
        }

        public Task<bool> ExistsByIdAsync(Guid id)
            => _readDbContext.ChatReadModels.AnyAsync(x => x.ChatId == id);
    }
}
