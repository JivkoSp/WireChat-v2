using Microsoft.EntityFrameworkCore;
using WireChat.Domain.Entities;
using WireChat.Domain.Repositories;
using WireChat.Domain.ValueObjects;
using WireChat.Infrastructure.EntityFramework.Contexts;

namespace WireChat.Infrastructure.EntityFramework.Repositories
{
    internal sealed class PostgresChatMessageRepository : IChatMessageRepository
    {
        private readonly WriteDbContext _writeDbContext;

        public PostgresChatMessageRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
        }

        public Task<ChatMessage> GetChatMessageByIdAsync(ChatMessageID chatMessageId)
            => _writeDbContext.ChatMessages
                .SingleOrDefaultAsync(x => x.Id == chatMessageId);
                

        public async Task AddChatMessageAsync(ChatMessage chatMessage)
        {
            await _writeDbContext.ChatMessages.AddAsync(chatMessage);

            await _writeDbContext.SaveChangesAsync();
        }

        public async Task DeleteChatMessageAsync(ChatMessage chatMessage)
        {
            _writeDbContext.ChatMessages.Remove(chatMessage);

            await _writeDbContext.SaveChangesAsync();
        }
    }
}
