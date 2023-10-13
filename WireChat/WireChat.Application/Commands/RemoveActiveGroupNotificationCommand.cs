
namespace WireChat.Application.Commands
{
    public record RemoveActiveGroupNotificationCommand(Guid NotificationHubId, Guid GroupId) : ICommand;
}
