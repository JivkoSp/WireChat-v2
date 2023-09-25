
namespace WireChat.Application.Commands
{
    public record CreateGroupChatCommand(Guid UserId, string GroupName) : ICommand;
}
