using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Events
{
    public record AcceptedContactRequestNotificationAdded(NotificationHub NotificationHub, 
        AcceptedContactRequestNotification AcceptedContactRequestNotification) : IDomainEvent;
}
