
namespace WireChat.Application.Commands
{
    public record RemoveRemovedGroupMemberNotification(Guid NotificationHubId, Guid GroupMemberUserId) : ICommand;
}
