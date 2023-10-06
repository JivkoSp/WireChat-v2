using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Events
{
    public record AcceptedContactRequestNotificationRemoved(NotificationHub NotificationHub,
        AcceptedContactRequestNotification AcceptedContactRequestNotification) : IDomainEvent;
}
