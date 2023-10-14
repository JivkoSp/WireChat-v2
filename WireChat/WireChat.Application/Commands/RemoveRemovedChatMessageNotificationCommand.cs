
namespace WireChat.Application.Commands
{
    public record RemoveRemovedChatMessageNotificationCommand(Guid NotificationHubId, Guid ChatMessageId) : ICommand;
}
