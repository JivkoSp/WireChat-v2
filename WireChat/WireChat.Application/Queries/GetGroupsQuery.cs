using WireChat.Application.Dtos;

namespace WireChat.Application.Queries
{
    public record GetGroupsQuery(string UserId) : IQuery<List<GroupDto>>;
}
