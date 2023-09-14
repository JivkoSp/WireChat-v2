using WireChat.Domain.Entities;
using WireChat.Domain.Factories.Interfaces;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Factories
{
    public sealed class UserFactory : IUserFactory
    {
        public User Create(UserID userId, UserFirstName userFirstName, UserLastName userLastName, UserName userName, UserEmail userEmail)
            => new User(userId, userFirstName, userLastName, userName, userEmail);
    }
}
