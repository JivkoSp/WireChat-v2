using WireChat.Application.Dtos;

namespace WireChat.Application.Queries
{
    public record GetChatUserQuery(Guid ChatId, string UserId) : IQuery<ChatUserDto>;
}
