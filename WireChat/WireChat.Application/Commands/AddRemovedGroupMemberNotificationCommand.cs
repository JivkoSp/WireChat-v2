
namespace WireChat.Application.Commands
{
    public record AddRemovedGroupMemberNotificationCommand(Guid NotificationHubId, Guid GroupAdminUserId, 
        Guid GroupMemberUserId, Guid GroupId, DateTimeOffset DateTime) : ICommand;
}
