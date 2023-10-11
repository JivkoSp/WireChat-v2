
namespace WireChat.Application.Commands
{
    public record AddRemovedChatMessageNotificationCommand(Guid NotificationHubId, Guid ChatId,
        Guid ChatMessageId, Guid UserId, DateTimeOffset DateTime) : ICommand;
}
