using WireChat.Application.Dtos;

namespace WireChat.Application.Queries
{
    public record GetUserInfoQuery(string UserId) : IQuery<UserInfoDto>;
}
