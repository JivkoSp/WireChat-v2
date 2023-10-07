using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Events
{
    public record DeclinedContactRequestNotificationAdded(NotificationHub NotificationHub, 
        DeclinedContactRequestNotification DeclinedContactRequestNotification) : IDomainEvent;
}
