using WireChat.Application.Dtos;

namespace WireChat.Application.Queries
{
    public record GetNotificationHubQuery(Guid NotificationHubId) : IQuery<NotificationHubDto>;
}
