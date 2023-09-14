
namespace WireChat.Application.Commands
{
    public record class AddContactRequestCommand(Guid SenderUserId, Guid ReceiverUserId, string Message) : ICommand;
}
