using Microsoft.EntityFrameworkCore;
using WireChat.Domain.Entities;
using WireChat.Domain.Repositories;
using WireChat.Domain.ValueObjects;
using WireChat.Infrastructure.EntityFramework.Contexts;

namespace WireChat.Infrastructure.EntityFramework.Repositories
{
    internal sealed class PostgresNotificationHubRepository : INotificationHubRepository
    {
        private readonly WriteDbContext _writeDbContext;

        public PostgresNotificationHubRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
        }

        public Task<NotificationHub> GetNotificationHubByIdAsync(NotificationHubID notificationHubId)
            => _writeDbContext.NotificationHubs
                .Include(x => x.AcceptedContactRequestNotifications)
                .Include(x => x.ActiveGroupNotifications)
                .Include(x => x.AddedGroupMemberNotifications)
                .Include(x => x.BannedContactNotifications)
                .Include(x => x.BannedGroupMemberNotifications)
                .Include(x => x.CreatedGroupNotifications)
                .Include(x => x.DeclinedContactRequestNotifications)
                .Include(x => x.IssuedContactRequestNotifications)
                .Include(x => x.ReceivedContactRequestNotifications)
                .Include(x => x.RemovedChatMessageNotifications)
                .Include(x => x.RemovedGroupMemberNotifications)
                .SingleOrDefaultAsync(x => x.Id == notificationHubId);

        public async Task AddNotificationHubAsync(NotificationHub notificationHub)
        {
            await _writeDbContext.NotificationHubs.AddAsync(notificationHub);

            await _writeDbContext.SaveChangesAsync();
        }

        public async Task UpdateNotificationHubAsync(NotificationHub notificationHub)
        {
            _writeDbContext.NotificationHubs.Update(notificationHub);

            await _writeDbContext.SaveChangesAsync();
        }
    }
}
