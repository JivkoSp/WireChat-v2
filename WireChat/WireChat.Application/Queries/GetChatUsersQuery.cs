using WireChat.Application.Dtos;

namespace WireChat.Application.Queries
{
    public record GetChatUsersQuery : IQuery<List<ChatUserDto>>;
}