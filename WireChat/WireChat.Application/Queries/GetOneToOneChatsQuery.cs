using WireChat.Application.Dtos;

namespace WireChat.Application.Queries
{
    public record GetOneToOneChatsQuery(string UserId) : IQuery<List<ChatDto>>;
}