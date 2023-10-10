
namespace WireChat.Application.Commands
{
    public record AddActiveGroupNotificationCommand(Guid NotificationHubId, Guid GroupId) : ICommand;
}
