using Microsoft.AspNetCore.SignalR;
using WireChat.Infrastructure.Dtos.SignalR;

namespace WireChat.Infrastructure.SignalR.Hubs
{
    public sealed class UserNotificationHub : Hub
    {
        public async Task JoinGroup(string group)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
        }

        public async Task AcceptedContactRequestNotification(SignalRAcceptedContactRequestNotificationDto 
            acceptedContactRequestNotification)
        {
            await Clients.Group(acceptedContactRequestNotification.SenderUserName)
                .SendAsync("AcceptedContactRequestNotification", acceptedContactRequestNotification);

            await Clients.Group(acceptedContactRequestNotification.ReceiverUserName)
                .SendAsync("AcceptedContactRequestNotification", acceptedContactRequestNotification);
        }

        public async Task CreatedGroupNotification(SignalRCreatedGroupNotificationDto createdGroupNotification)
        {
            await Clients.Group(createdGroupNotification.UserName)
                .SendAsync("CreatedGroupNotification", createdGroupNotification);
        }

        public async Task DeclinedContactRequestNotification(SignalRDeclinedContactRequestNotificationDto declinedContactRequestNotification)
        {
            await Clients.Group(declinedContactRequestNotification.SenderUserName)
                .SendAsync("DeclinedContactRequestNotification", declinedContactRequestNotification);

            await Clients.Group(declinedContactRequestNotification.ReceiverUserName)
                .SendAsync("DeclinedContactRequestNotification", declinedContactRequestNotification);
        }

        public async Task IssuedContactRequestNotification(SignalRIssuedContactRequestNotificationDto issuedContactRequestNotification)
        {
            await Clients.Group(issuedContactRequestNotification.SenderUserName)
                .SendAsync("IssuedContactRequestNotification", issuedContactRequestNotification);

            await Clients.Group(issuedContactRequestNotification.ReceiverUserName)
                .SendAsync("ReceivedContactRequestNotification", issuedContactRequestNotification);
        }
    }
}