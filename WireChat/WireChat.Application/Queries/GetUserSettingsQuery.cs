using WireChat.Application.Dtos;

namespace WireChat.Application.Queries
{
    public record GetUserSettingsQuery(string UserId) : IQuery<UserDto>;
}
