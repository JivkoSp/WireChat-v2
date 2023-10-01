
namespace WireChat.Application.Services.ReadServices
{
    public interface IUserReadService
    {
        Task<bool> ExistsByIdAsync(Guid id);
        Task<bool> HasUserInContactsAsync(Guid userId, Guid otherUserId);
    }
}
