using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Events
{
    public record RemovedChatMessageNotificationAdded(NotificationHub NotificationHub, 
        RemovedChatMessageNotification RemovedChatMessageNotification) : IDomainEvent;
}
