
namespace WireChat.Application.Commands
{
    public record class AddBannedGroupMemberNotificationCommand(Guid NotificationHubId, Guid GroupAdminUserId, 
        Guid GroupMemberUserId, Guid GroupId, DateTimeOffset DateTime) : ICommand;
}
