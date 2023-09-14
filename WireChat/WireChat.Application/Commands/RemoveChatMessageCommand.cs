
namespace WireChat.Application.Commands
{
    public record RemoveChatMessageCommand(Guid ChatId, Guid ChatMessageId) : ICommand;
}
