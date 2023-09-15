using WireChat.Application.Exceptions;
using WireChat.Application.Services.ReadServices;
using WireChat.Domain.Repositories;
using WireChat.Domain.ValueObjects;

namespace WireChat.Application.Commands.Handlers
{
    internal sealed class AddContactRequestHandler : ICommandHandler<AddContactRequestCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserReadService _userReadService;

        public AddContactRequestHandler(IUserRepository userRepository, IUserReadService userReadService)
        {
            _userRepository = userRepository;
            _userReadService = userReadService;
        }

        public async Task HandleAsync(AddContactRequestCommand command)
        {
            var receiver = await _userRepository.GetUserByIdAsync(command.ReceiverUserId);

            if (receiver is null)
            {
                throw new UserNotFoundException(command.ReceiverUserId);
            }

            var senderExists = await _userReadService.ExistsByIdAsync(command.SenderUserId);

            if (senderExists is false)
            {
                throw new UserNotFoundException(command.SenderUserId);
            }

            var contactRequest = new UserContactRequest(command.SenderUserId, command.ReceiverUserId, command.Message);

            receiver.AddContactRequest(contactRequest);

            await _userRepository.UpdateUserAsync(receiver);
        }
    }
}
