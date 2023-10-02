using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Events
{
    public record BlockedChatUserAdded(Chat Chat, BlockedChatUser BlockedChatUser) : IDomainEvent;
}
