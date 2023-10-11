
namespace WireChat.Application.Commands
{
    public record AddIssuedContactRequestNotificationCommand(Guid NotificationHubId, Guid SenderUserId, 
        Guid ReceiverUserId, DateTimeOffset DateTime) : ICommand;
}
