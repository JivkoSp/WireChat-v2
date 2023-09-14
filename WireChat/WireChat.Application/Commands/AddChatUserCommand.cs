
namespace WireChat.Application.Commands
{
    public record AddChatUserCommand(Guid ChatId, Guid UserId) : ICommand;
}
