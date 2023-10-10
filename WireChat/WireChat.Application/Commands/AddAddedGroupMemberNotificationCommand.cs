
namespace WireChat.Application.Commands
{
    public record AddAddedGroupMemberNotificationCommand(Guid NotificationHubId, Guid GroupAdminUserId, Guid GroupMemberUserId, 
        Guid GroupId, DateTimeOffset DateTime) : ICommand;
}
