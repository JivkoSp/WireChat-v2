
namespace WireChat.Application.Commands
{
    public record CreateNotificationHubCommand(Guid NotificationHubId) : ICommand;
}
