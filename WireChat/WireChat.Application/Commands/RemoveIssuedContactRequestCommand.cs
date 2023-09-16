namespace WireChat.Application.Commands
{
    public record RemoveIssuedContactRequestCommand(Guid SenderUserId, Guid ReceiverUserId) : ICommand;
}