﻿using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Events
{
    public record RemovedChatMessageNotificationRemoved(NotificationHub NotificationHub,
        RemovedChatMessageNotification RemovedChatMessageNotification) : IDomainEvent;
}
