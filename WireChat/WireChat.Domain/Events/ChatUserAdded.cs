using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Events
{
    public record ChatUserAdded(Chat Chat, ChatUser UserChat) : IDomainEvent;
}
