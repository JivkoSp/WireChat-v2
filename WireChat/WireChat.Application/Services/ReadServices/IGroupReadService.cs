
namespace WireChat.Application.Services.ReadServices
{
    public interface IGroupReadService
    {
        Task<bool> ExistsByIdAsync(Guid id);
    }
}
