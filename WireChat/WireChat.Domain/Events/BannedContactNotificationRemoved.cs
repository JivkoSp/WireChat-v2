using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Events
{
    public record BannedContactNotificationRemoved(NotificationHub NotificationHub, 
        BannedContactNotification BannedContactNotification) : IDomainEvent;
}
