
namespace WireChat.Application.Commands
{
    public record AddChatMessageCommand(Guid ChatId, Guid ChatMessageId, Guid UserId, 
        string Message, DateTimeOffset MessageDateTime) : ICommand;
}
