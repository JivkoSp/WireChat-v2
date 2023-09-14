using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Repositories
{
    public interface IChatMessageRepository
    {
        Task<ChatMessage> GetChatMessageByIdAsync(ChatMessageID chatMessageId);
        Task AddChatMessageAsync(ChatMessage chatMessage);
        Task DeleteChatMessageAsync(ChatMessage chatMessage);
    }
}
