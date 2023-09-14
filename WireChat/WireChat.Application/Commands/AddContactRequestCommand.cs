
namespace WireChat.Application.Commands
{
    public record AddContactRequestCommand(Guid SenderUserId, Guid ReceiverUserId, string Message) : ICommand;
}
