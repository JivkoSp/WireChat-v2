
namespace WireChat.Application.Commands
{
    public record RemoveDeclinedContactRequestNotificationCommand(Guid NotificationHubId, Guid SenderUserId) : ICommand;
}
