using Microsoft.AspNetCore.SignalR;
using WireChat.Application.Dtos;
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
            await Clients.Group(chatMessage.ChatId).SendAsync("SendMessage", chatMessage);
        }

        public async Task RemoveMessage(SignalRRemoveChatMessageDto removeChatMessage)
        {
            await Clients.Group(removeChatMessage.ChatId).SendAsync("RemoveMessage", removeChatMessage);
        }

        public async Task UserAdded(ChatUserDto chatUserDto)
        {
            await Clients.Group(chatUserDto.ChatId.ToString()).SendAsync("UserAdded", chatUserDto);
        }

        public async Task UserRemoved(SignalRRemoveChatUserDto removeChatUser)
        {
            await Clients.Group(removeChatUser.ChatId).SendAsync("UserRemoved", removeChatUser);
        }

        public async Task UserBlocked(SignalRBlockedChatUserDto blockedChatUser)
        {
            await Clients.Group(blockedChatUser.ChatId).SendAsync("UserBlocked", blockedChatUser);
        }

        public async Task UserUnblocked(SignalRBlockedChatUserDto blockedChatUser)
        {
            await Clients.Group(blockedChatUser.ChatId).SendAsync("UserUnblocked", blockedChatUser);
        }

        public async Task BlockedUserRemoved(SignalRRemoveChatUserDto removeChatUser)
        {
            await Clients.Group(removeChatUser.ChatId).SendAsync("BlockedUserRemoved", removeChatUser);
        }
    }
}
