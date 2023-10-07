using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Events
{
    public record BannedGroupMemberNotificationAdded(NotificationHub NotificationHub, 
        BannedGroupMemberNotification BannedGroupMemberNotification) : IDomainEvent;
}
