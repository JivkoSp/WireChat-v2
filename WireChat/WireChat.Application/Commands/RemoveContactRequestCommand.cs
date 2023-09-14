
namespace WireChat.Application.Commands
{
    public record RemoveContactRequestCommand(Guid SenderUserId, Guid ReceiverUserId) : ICommand;
}
