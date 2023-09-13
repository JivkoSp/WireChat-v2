using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Events
{
    public record ChatUserRemoved(Chat Chat, ChatUser UserChat) : IDomainEvent;
}
