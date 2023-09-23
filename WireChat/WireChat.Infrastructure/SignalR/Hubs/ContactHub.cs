using Microsoft.AspNetCore.SignalR;
using WireChat.Infrastructure.Dtos.SignalR;

namespace WireChat.Infrastructure.SignalR.Hubs
{
    public sealed class ContactHub : Hub
    {
        public async Task JoinGroup(string group)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
        }

        public async Task ContactRequest(SignalRContactRequestDto contactRequest)
        {
            await Clients.Group(contactRequest.ContactName).SendAsync("ContactRequest", contactRequest);
        }

        public async Task RemovedReceivedContactRequest(SignalRRemoveContactRequestDto removeContactRequestDto)
        {
            await Clients.Group(removeContactRequestDto.ReceiverUserName)
                .SendAsync("RemovedReceivedContactRequest", removeContactRequestDto);
        }
    }
}
