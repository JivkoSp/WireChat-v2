
namespace WireChat.Application.Commands
{
    public record class RemoveBannedGroupMemberNotificationCommand(Guid NotificationHubId, Guid GroupMemberUserId) : ICommand;
}
