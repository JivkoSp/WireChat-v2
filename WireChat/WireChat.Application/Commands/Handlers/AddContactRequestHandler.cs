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
            var issuer = await _userRepository.GetUserByIdAsync(command.SenderUserId);

            if (issuer is null)
            {
                throw new UserNotFoundException(command.SenderUserId);
            }

            var receiverExists = await _userReadService.ExistsByIdAsync(command.ReceiverUserId);

            if (receiverExists is false)
            {
                throw new UserNotFoundException(command.ReceiverUserId);
            }

            // TODO: Аdd a check to see if command.SenderUserId and command.ReceiverUserId are already in a chat.
            // Maybe add a chat read service that will have such method.

            var contactRequest = new UserContactRequest(command.SenderUserId, command.ReceiverUserId, command.Message);

            issuer.AddContactRequest(contactRequest);

            await _userRepository.UpdateUserAsync(issuer);
        }
    }
}
