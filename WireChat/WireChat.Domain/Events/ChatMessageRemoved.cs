using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Events
{
    public record ChatMessageRemoved(Chat Chat, ChatMessage ChatMessage) : IDomainEvent;
}
