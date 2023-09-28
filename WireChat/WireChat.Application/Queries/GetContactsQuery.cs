using WireChat.Application.Dtos;

namespace WireChat.Application.Queries
{
    public record GetContactsQuery(string UserId) : IQuery<List<ChatUserDto>>;
}
