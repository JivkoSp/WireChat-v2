
namespace WireChat.Application.Commands
{
    public record RemoveAddedGroupMemberNotificationCommand(Guid NotificationHubId, Guid GroupMemberUserId) : ICommand;
}
