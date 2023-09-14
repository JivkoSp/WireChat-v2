
namespace WireChat.Application.Commands
{
    public record AddedChatMessageCommand(Guid ChatId, Guid ChatMessageId, Guid UserId, 
        string Message, DateTimeOffset MessageDateTime) : ICommand;
}
