using WireChat.Application.Dtos;

namespace WireChat.Application.Queries
{
    public record GetGroupByNameQuery(string UserId, string GroupName) : IQuery<GroupDto>;
}
