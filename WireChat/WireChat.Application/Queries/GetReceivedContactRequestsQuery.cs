using WireChat.Application.Dtos;

namespace WireChat.Application.Queries
{
    public record GetReceivedContactRequestsQuery(string UserId) : IQuery<List<UserContactRequestDto>>;
}