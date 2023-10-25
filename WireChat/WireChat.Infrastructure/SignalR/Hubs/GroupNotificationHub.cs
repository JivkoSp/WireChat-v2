using Microsoft.AspNetCore.SignalR;
using WireChat.Infrastructure.Dtos.SignalR;

namespace WireChat.Infrastructure.SignalR.Hubs
{
    public sealed class GroupNotificationHub : Hub
    {
        public async Task JoinGroup(string group)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
        }

        public async Task ActiveGroupNotification(SignalRActiveGroupNotificationDto activeGroupNotification)
        {
            await Clients.Group(activeGroupNotification.GroupId)
                .SendAsync("ActiveGroupNotification", activeGroupNotification);
        }

        public async Task AddedGroupMemberNotification(SignalRAddedGroupMemberNotificationDto addedGroupMemberNotification)
        {
            await Clients.Group(addedGroupMemberNotification.GroupId)
                .SendAsync("AddedGroupMemberNotification", addedGroupMemberNotification);
        }

        public async Task BannedGroupMemberNotification(SignalRBannedGroupMemberNotificationDto bannedGroupMemberNotification)
        {
            await Clients.Group(bannedGroupMemberNotification.GroupId)
                .SendAsync("BannedGroupMemberNotification", bannedGroupMemberNotification);
        }

        public async Task RemovedGroupMemberNotification(SignalRRemovedGroupMemberNotificationDto removedGroupMemberNotification)
        {
            await Clients.Group(removedGroupMemberNotification.GroupId)
                .SendAsync("RemovedGroupMemberNotification", removedGroupMemberNotification);
        }
    }
}
