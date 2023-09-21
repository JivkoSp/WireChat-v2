using WireChat.Application.Dtos;

namespace WireChat.Application.Queries
{
    public record GetChatMessagesQuery(Guid ChatId) : IQuery<List<ChatMessageDto>>;
}