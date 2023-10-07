using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Events
{
    public record CreatedGroupNotificationAdded(NotificationHub NotificationHub, CreatedGroupNotification CreatedGroupNotification) : IDomainEvent;
}
