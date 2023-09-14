using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Factories.Interfaces
{
    public interface IUserFactory
    {
        User Create(UserID userId, UserFirstName userFirstName, UserLastName userLastName, UserName userName, UserEmail userEmail);
    }
}
