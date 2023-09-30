
namespace WireChat.Application.Commands
{
    public record AddChatUserCommand(Guid ChatId, Guid NewChatUserId, Guid UserId) : ICommand;
}
