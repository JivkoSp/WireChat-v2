using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Events
{
    public record UserContactRequestAdded(User User, UserContactRequest UserContactRequest) : IDomainEvent;
}
