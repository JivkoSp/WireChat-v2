using Microsoft.EntityFrameworkCore;
using WireChat.Application.Services.ReadServices;
using WireChat.Infrastructure.EntityFramework.Contexts;

namespace WireChat.Infrastructure.EntityFramework.Services.ReadServices
{
    internal sealed class PostgresNotificationHubReadService : INotificationHubReadService
    {
        private readonly ReadDbContext _readDbContext;

        public PostgresNotificationHubReadService(ReadDbContext readDbContext)
        {
            _readDbContext = readDbContext;
        }

        public Task<bool> ExistsByIdAsync(Guid id)
            => _readDbContext.NotificationHubReadModels.AnyAsync(x => x.NotificationHubId == id);
    }
}
