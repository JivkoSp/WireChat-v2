
namespace WireChat.Application.Commands
{
    public record UnblockChatUserCommand(Guid ChatId, Guid UserId) : ICommand;
}
