using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Repositories
{
    public interface INotificationHubRepository
    {
        Task<NotificationHub> GetNotificationHubByIdAsync(NotificationHubID notificationHubId);
        Task AddNotificationHubAsync(NotificationHub notificationHub);
        Task UpdateNotificationHubAsync(NotificationHub notificationHub);
    }
}
