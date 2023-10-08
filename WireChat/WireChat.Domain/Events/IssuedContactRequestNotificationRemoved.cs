﻿using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Events
{
    public record IssuedContactRequestNotificationRemoved(NotificationHub NotificationHub,
        IssuedContactRequestNotification IssuedContactRequestNotification) : IDomainEvent;
}
