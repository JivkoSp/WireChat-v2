using WireChat.Domain.Entities;
using WireChat.Domain.Factories.Interfaces;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Factories
{
    public class NotificationHubFactory : INotificationHubFactory
    {
        public NotificationHub Create(NotificationHubID notificationId)
            => new NotificationHub(notificationId);
    }
}
