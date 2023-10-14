
namespace WireChat.Application.Commands
{
    public record RemoveReceivedContactRequestNotificationCommand(Guid NotificationHubId, Guid SenderUserId) : ICommand;
}
