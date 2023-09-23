using Microsoft.AspNetCore.SignalR;
using WireChat.Infrastructure.Dtos.SignalR;

namespace WireChat.Infrastructure.SignalR.Hubs
{
    public sealed class ChatHub : Hub
    {
        public async Task JoinGroup(string group)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
        }

        public async Task SendMessage(SignalRChatMessageDto chatMessage)
        {
            await Clients.Group(chatMessage.ChatId.ToString()).SendAsync("SendMessage", chatMessage);
        }

        public async Task RemoveMessage(SignalRChatMessageDto chatMessage)
        {
            await Clients.Group(chatMessage.ChatId.ToString()).SendAsync("RemoveMessage", chatMessage);
        }
    }
}
