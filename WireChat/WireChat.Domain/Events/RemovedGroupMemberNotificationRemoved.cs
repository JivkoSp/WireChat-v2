using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Events
{
    public record RemovedGroupMemberNotificationRemoved(NotificationHub NotificationHub,
        RemovedGroupMemberNotification RemovedGroupMemberNotification) : IDomainEvent;
}
