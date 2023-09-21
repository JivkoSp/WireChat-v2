using WireChat.Application.Dtos;

namespace WireChat.Application.Queries
{
    public record GetIssuedContactRequestsQuery(Guid UserId) : IQuery<List<UserContactRequestDto>>;
}