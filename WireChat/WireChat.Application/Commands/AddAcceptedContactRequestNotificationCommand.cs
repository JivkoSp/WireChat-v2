
namespace WireChat.Application.Commands
{
    public record AddAcceptedContactRequestNotificationCommand(Guid NotificationHubId, Guid SenderUserId,
        Guid ReceiverUserId, DateTimeOffset DateTime) : ICommand;
}
