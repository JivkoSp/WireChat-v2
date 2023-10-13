
namespace WireChat.Application.Commands
{
    public record RemoveBannedContactNotificationCommand(Guid NotificationHubId, Guid UserId) : ICommand;
}
