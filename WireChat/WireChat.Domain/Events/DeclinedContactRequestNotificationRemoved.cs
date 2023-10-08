using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Events
{
    public record DeclinedContactRequestNotificationRemoved(NotificationHub NotificationHub,
        DeclinedContactRequestNotification DeclinedContactRequestNotification) : IDomainEvent;
}
