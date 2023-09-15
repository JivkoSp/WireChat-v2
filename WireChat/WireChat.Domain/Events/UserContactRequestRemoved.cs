using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Events
{
    public record UserContactRequestRemoved(User User, UserContactRequest UserContactRequest) : IDomainEvent;
}
