
namespace WireChat.Application.Commands
{
    public record AddCreatedGroupNotificationCommand(Guid NotificationHubId, Guid UserId, Guid GroupId, DateTimeOffset DateTime) : ICommand;
}
