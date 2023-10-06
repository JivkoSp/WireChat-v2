using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Events
{
    public record ActiveGroupNotificationAdded(NotificationHub NotificationHub, ActiveGroupNotification ActiveGroupNotification) : IDomainEvent;
}
