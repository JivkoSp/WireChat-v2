using WireChat.Application.Dtos;

namespace WireChat.Application.Queries
{
    public record GetChatUsersQuery(Guid ChatId) : IQuery<List<ChatUserDto>>;
}