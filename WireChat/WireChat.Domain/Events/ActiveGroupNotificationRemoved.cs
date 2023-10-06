using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Events
{
    public record ActiveGroupNotificationRemoved(NotificationHub NotificationHub, ActiveGroupNotification ActiveGroupNotification) : IDomainEvent;
}
