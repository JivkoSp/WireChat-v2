using WireChat.Application.Dtos;

namespace WireChat.Application.Queries
{
    public record GetGroupQuery(Guid ChatId) : IQuery<GroupDto>;
}
