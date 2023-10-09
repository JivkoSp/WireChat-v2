using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Factories.Interfaces
{
    public interface INotificationHubFactory
    {
        NotificationHub Create(NotificationHubID notificationId);
    }
}
