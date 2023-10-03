using Microsoft.EntityFrameworkCore;
using WireChat.Domain.Entities;
using WireChat.Domain.Repositories;
using WireChat.Domain.ValueObjects;
using WireChat.Infrastructure.EntityFramework.Contexts;

namespace WireChat.Infrastructure.EntityFramework.Repositories
{
    internal sealed class PostgresChatRepository : IChatRepository
    {
        private readonly WriteDbContext _writeDbContext;

        public PostgresChatRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
        }

        public Task<Chat> GetChatByIdAsync(ChatID chatId)
            => _writeDbContext.Chats
                .Include(x => x.Users)
                .Include(x => x.BlockedUsers)
                .Include(x => x.Messages)
                .SingleOrDefaultAsync(x => x.Id == chatId);

        public async Task AddChatAsync(Chat chat)
        {
            await _writeDbContext.Chats.AddAsync(chat);

            await _writeDbContext.SaveChangesAsync();
        }

        public async Task UpdateChatAsync(Chat chat)
        {
            _writeDbContext.Chats.Update(chat);

            await _writeDbContext.SaveChangesAsync();
        }

        public async Task DeleteChatAsync(Chat chat)
        {
            _writeDbContext.Chats.Remove(chat);

            await _writeDbContext.SaveChangesAsync();
        }
    }
}
