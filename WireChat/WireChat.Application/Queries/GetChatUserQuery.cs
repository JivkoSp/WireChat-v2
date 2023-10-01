using WireChat.Application.Dtos;

namespace WireChat.Application.Queries
{
    public record GetChatUserQuery(string UserId) : IQuery<ChatUserDto>;
}
