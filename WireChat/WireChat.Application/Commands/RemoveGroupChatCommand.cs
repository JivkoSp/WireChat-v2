
namespace WireChat.Application.Commands
{
    public record RemoveGroupChatCommand(Guid ChatId) : ICommand;
}
