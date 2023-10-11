
namespace WireChat.Application.Commands
{
    public record AddReceivedContactRequestNotificationCommand(Guid NotificationHubId, Guid SenderUserId,
        Guid ReceiverUserId, DateTimeOffset DateTime) : ICommand;
}
