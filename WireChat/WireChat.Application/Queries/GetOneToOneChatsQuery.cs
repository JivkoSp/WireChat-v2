using WireChat.Application.Dtos;

namespace WireChat.Application.Queries
{
    public record GetOneToOneChatsQuery(Guid UserId) : IQuery<List<ChatDto>>;
}