
namespace WireChat.Application.Commands
{
    public record BlockChatUserCommand(Guid ChatId, Guid UserId) : ICommand;
}
