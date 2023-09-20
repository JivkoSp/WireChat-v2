using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(UserID userId);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(User user);
    }
}
