using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Events
{
    public record AddedGroupMemberNotificationAdded(NotificationHub NotificationHub, 
        AddedGroupMemberNotification AddedGroupMemberNotification) : IDomainEvent;
}
