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

        public async Task ReceivedContactRequest(SignalRContactRequestDto contactRequest)
        {
            await Clients.Group(contactRequest.SenderUserName).SendAsync("IssuedContactRequest", contactRequest);

            await Clients.Group(contactRequest.ReceiverUserName).SendAsync("ReceivedContactRequest", contactRequest);
        }

        public async Task RemovedIssuedContactRequest(SignalRRemoveContactRequestDto removeContactRequest)
        {
            await Clients.Group(removeContactRequest.SenderUserName)
                .SendAsync("RemovedIssuedContactRequest", removeContactRequest);
        }

        public async Task RemovedReceivedContactRequest(SignalRRemoveContactRequestDto removeContactRequest)
        {
            await Clients.Group(removeContactRequest.ReceiverUserName)
                .SendAsync("RemovedReceivedContactRequest", removeContactRequest);
        }
    }
}
