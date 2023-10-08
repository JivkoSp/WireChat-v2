using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Events
{
    public record IssuedContactRequestNotificationAdded(NotificationHub NotificationHub, 
        IssuedContactRequestNotification IssuedContactRequestNotification) : IDomainEvent;
}
