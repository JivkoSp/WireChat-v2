using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Events
{
    public record ChatMessageAdded(Chat Chat, ChatMessage ChatMessage) : IDomainEvent;
}
