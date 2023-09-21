using WireChat.Application.Dtos;

namespace WireChat.Application.Queries
{
    public record GetReceivedContactRequestsQuery(Guid UserId) : IQuery<List<UserContactRequestDto>>;
}