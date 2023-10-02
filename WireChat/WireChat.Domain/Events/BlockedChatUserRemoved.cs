using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Events
{
    public record BlockedChatUserRemoved(Chat Chat, BlockedChatUser BlockedChatUser) : IDomainEvent;
}
