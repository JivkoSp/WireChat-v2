
namespace WireChat.Application.Services.ReadServices
{
    public interface INotificationHubReadService
    {
        Task<bool> ExistsByIdAsync(Guid id);
    }
}
