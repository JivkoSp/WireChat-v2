
namespace WireChat.Application.Commands
{
    public record RemoveCreatedGroupNotificationCommand(Guid NotificationHubId, Guid GroupId) : ICommand;
}
