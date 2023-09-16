
using WireChat.Application.Exceptions;
using WireChat.Application.Services.ReadServices;
using WireChat.Domain.Repositories;

namespace WireChat.Application.Commands.Handlers
{
    internal sealed class RemoveReceivedContactRequestHandler : ICommandHandler<RemoveReceivedContactRequestCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserReadService _userReadService;

        public RemoveReceivedContactRequestHandler(IUserRepository userRepository, IUserReadService userReadService)
        {
            _userRepository = userRepository;
            _userReadService = userReadService;
        }
        public async Task HandleAsync(RemoveReceivedContactRequestCommand command)
        {
            var senderExists = await _userReadService.ExistsByIdAsync(command.SenderUserId);

            if (senderExists is false)
            {
                throw new UserNotFoundException(command.SenderUserId);
            }

            var receiver = await _userRepository.GetUserByIdAsync(command.ReceiverUserId);

            if (receiver is null)
            {
                throw new UserNotFoundException(command.ReceiverUserId);
            }

            receiver.RemoveReceivedContactRequest(command.SenderUserId);

            await _userRepository.UpdateUserAsync(receiver);
        }
    }
}