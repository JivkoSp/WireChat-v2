
namespace WireChat.Application.Commands
{
    public record RemoveOneToOneChatCommand(Guid ChatId) : ICommand;
}
