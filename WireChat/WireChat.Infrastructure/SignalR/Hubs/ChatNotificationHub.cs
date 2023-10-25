using Microsoft.AspNetCore.SignalR;
using WireChat.Infrastructure.Dtos.SignalR;

namespace WireChat.Infrastructure.SignalR.Hubs
{
    public sealed class ChatNotificationHub : Hub
    {
        public async Task JoinGroup(string group)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
        }

        public async Task BannedContactNotification(SignalRBannedContactNotificationDto bannedContactNotification)
        {
            await Clients.Group(bannedContactNotification.ChatId)
                .SendAsync("BannedContactNotification", bannedContactNotification);
        }

        public async Task RemovedChatMessageNotification(SignalRRemovedChatMessageNotificationDto removedChatMessageNotification)
        {
            await Clients.Group(removedChatMessageNotification.ChatId)
                .SendAsync("RemovedChatMessageNotification", removedChatMessageNotification);
        }
    }
}
