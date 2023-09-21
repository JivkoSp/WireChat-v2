using WireChat.Application.Dtos;

namespace WireChat.Application.Queries
{
    public record GetIssuedContactRequestsQuery(string UserId) : IQuery<List<UserContactRequestDto>>;
}