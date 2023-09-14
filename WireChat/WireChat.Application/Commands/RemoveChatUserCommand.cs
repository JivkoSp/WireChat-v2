
namespace WireChat.Application.Commands
{
    public record RemoveChatUserCommand(Guid ChatId, Guid UserId) : ICommand;
}
