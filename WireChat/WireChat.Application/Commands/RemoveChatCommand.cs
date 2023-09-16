
namespace WireChat.Application.Commands
{
    public record RemoveChatCommand(Guid ChatId) : ICommand;
}
