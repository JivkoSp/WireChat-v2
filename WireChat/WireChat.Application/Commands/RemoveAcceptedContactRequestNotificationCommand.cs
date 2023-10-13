
namespace WireChat.Application.Commands
{
    public record RemoveAcceptedContactRequestNotificationCommand(Guid NotificationHubId, Guid SenderUserId) : ICommand;
}
