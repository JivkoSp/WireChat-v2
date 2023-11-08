using WireChat.Application.Dtos;

namespace WireChat.Application.Queries
{
    public record GetBlockedChatMembersQuery(Guid ChatId) : IQuery<List<BlockedChatUserDto>>;
}
