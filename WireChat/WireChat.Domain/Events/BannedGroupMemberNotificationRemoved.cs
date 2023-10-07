using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Events
{
    public record BannedGroupMemberNotificationRemoved(NotificationHub NotificationHub, 
        BannedGroupMemberNotification BannedGroupMemberNotification) : IDomainEvent;
}
