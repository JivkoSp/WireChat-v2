
namespace WireChat.Application.Commands
{
    public record RemoveReceivedContactRequestCommand(Guid SenderUserId, Guid ReceiverUserId) : ICommand;
}
