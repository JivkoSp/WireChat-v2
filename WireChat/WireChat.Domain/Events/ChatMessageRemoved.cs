using WireChat.Domain.Entities;

namespace WireChat.Domain.Events
{
    public record ChatMessageRemoved(Chat Chat, ChatMessage ChatMessage) : IDomainEvent;
}
