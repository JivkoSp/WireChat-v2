using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Events
{
    public record ReceivedContactRequestNotificationAdded(NotificationHub NotificationHub, 
        ReceivedContactRequestNotification ReceivedContactRequestNotification) : IDomainEvent;
}
