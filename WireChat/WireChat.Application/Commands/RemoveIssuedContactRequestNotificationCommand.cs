
namespace WireChat.Application.Commands
{
    public record RemoveIssuedContactRequestNotificationCommand(Guid NotificationHubId, Guid ReceiverUserId) : ICommand;
}
