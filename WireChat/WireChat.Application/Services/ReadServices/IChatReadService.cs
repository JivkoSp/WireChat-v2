
namespace WireChat.Application.Services.ReadServices
{
    public interface IChatReadService
    {
        Task<bool> ExistsByIdAsync(Guid id);
        Task<bool> ChatMessageExistsByIdAsync(Guid id);
    }
}
