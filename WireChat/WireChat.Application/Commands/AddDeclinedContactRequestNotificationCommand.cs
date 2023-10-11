
namespace WireChat.Application.Commands
{
    public record AddDeclinedContactRequestNotificationCommand(Guid NotificationHubId, Guid SenderUserId,
        Guid ReceiverUserId, DateTimeOffset DateTime) : ICommand;
}
