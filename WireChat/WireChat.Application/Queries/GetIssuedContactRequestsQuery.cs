using WireChat.Application.Dtos;

namespace WireChat.Application.Queries
{
    public record GetIssuedContactRequestsQuery : IQuery<List<UserContactRequestDto>>;
}