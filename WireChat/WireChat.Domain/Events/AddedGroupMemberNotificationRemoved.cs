using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Events
{
    public record AddedGroupMemberNotificationRemoved(NotificationHub NotificationHub,
        AddedGroupMemberNotification AddedGroupMemberNotification) : IDomainEvent;
}
