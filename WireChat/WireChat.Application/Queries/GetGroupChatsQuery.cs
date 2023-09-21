using WireChat.Application.Dtos;

namespace WireChat.Application.Queries
{
    public record GetGroupChatsQuery(string UserId) : IQuery<List<ChatDto>>;
}