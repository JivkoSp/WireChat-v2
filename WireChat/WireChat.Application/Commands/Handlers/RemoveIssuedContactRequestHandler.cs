using WireChat.Application.Exceptions;
using WireChat.Application.Services.ReadServices;
using WireChat.Domain.Repositories;

namespace WireChat.Application.Commands.Handlers
{
    internal sealed class RemoveIssuedContactRequestHandler : ICommandHandler<RemoveIssuedContactRequestCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserReadService _userReadService;

        public RemoveIssuedContactRequestHandler(IUserRepository userRepository, IUserReadService userReadService)
        {
            _userRepository = userRepository;
            _userReadService = userReadService;
        }

        public async Task HandleAsync(RemoveIssuedContactRequestCommand command)
        {
            var receiverExists = await _userReadService.ExistsByIdAsync(command.ReceiverUserId);

            if (receiverExists is false)
            {
                throw new UserNotFoundException(command.ReceiverUserId);
            }

            var sender = await _userRepository.GetUserByIdAsync(command.SenderUserId);

            if (sender is null)
            {
                throw new UserNotFoundException(command.SenderUserId);
            }

            sender.RemoveIssuedContactRequest(command.ReceiverUserId);

            await _userRepository.UpdateUserAsync(sender);
        }
    }
}