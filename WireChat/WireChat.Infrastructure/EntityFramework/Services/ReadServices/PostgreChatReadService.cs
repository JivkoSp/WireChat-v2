using Microsoft.EntityFrameworkCore;
using WireChat.Application.Services.ReadServices;
using WireChat.Infrastructure.EntityFramework.Contexts;

namespace WireChat.Infrastructure.EntityFramework.Services.ReadServices
{
    internal sealed class PostgreChatReadService : IChatReadService
    {
        private readonly ReadDbContext _readDbContext;

        public PostgreChatReadService(ReadDbContext readDbContext)
        {
            _readDbContext = readDbContext;
        }

        public Task<bool> ExistsByIdAsync(Guid id)
            => _readDbContext.Chats.AnyAsync(x => x.ChatId == id);
    }
}
