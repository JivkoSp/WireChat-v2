using WireChat.Application.Dtos;

namespace WireChat.Application.Queries
{
    public record GetOneToOneChatsQuery : IQuery<List<ChatDto>>;
}