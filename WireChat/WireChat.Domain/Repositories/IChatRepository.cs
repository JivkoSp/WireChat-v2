using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Repositories
{
    public interface IChatRepository
    {
        Task<Chat> GetChatByIdAsync(ChatID chatId);
        Task AddChatAsync(Chat chat);
        Task UpdateChatAsync(Chat chat);
        Task DeleteChatAsync(Chat chat);
    }
}
