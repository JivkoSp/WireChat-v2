using WireChat.Application.Dtos;

namespace WireChat.Application.Queries
{
    public record GetGroupChatsQuery(Guid UserId) : IQuery<List<ChatDto>>;
}