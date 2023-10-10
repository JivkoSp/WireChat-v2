
namespace WireChat.Application.Commands
{
    public record AddBannedContactNotificationCommand(Guid NotificationHubId, Guid UserId, Guid ChatId, DateTimeOffset DateTime) : ICommand;
}
