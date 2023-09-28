using WireChat.Application.Dtos;

namespace WireChat.Application.Queries
{
    public record GetChatQuery(Guid ChatId) : IQuery<ChatDto>;
}