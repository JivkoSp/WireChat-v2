
namespace WireChat.Application.Commands
{
    public record CreateOneToOneChatCommand(Guid SenderUserId, Guid ReceiverUserId) : ICommand;
}
