using WireChat.Application.Exceptions;
using WireChat.Application.Services.ReadServices;
using WireChat.Domain.Factories.Interfaces;
using WireChat.Domain.Repositories;
using WireChat.Domain.ValueObjects;

namespace WireChat.Application.Commands.Handlers
{
    internal sealed class CreateGroupChatHandler : ICommandHandler<CreateGroupChatCommand>
    {
        private readonly IChatRepository _chatRepository;
        private readonly IUserReadService _userReadService;
        private readonly IChatFactory _chatFactory;
        private readonly IChatReadService _chatReadService;

        public CreateGroupChatHandler(IChatRepository chatRepository, IChatFactory chatFactory, 
            IUserReadService userReadService, IChatReadService chatReadService)
        {
            _chatRepository = chatRepository;
            _userReadService = userReadService;
            _chatFactory = chatFactory;
            _chatReadService = chatReadService;
        }
        public async Task HandleAsync(CreateGroupChatCommand command)
        {
            var userExists = await _userReadService.ExistsByIdAsync(command.UserId);

            if (userExists is false)
            {
                throw new UserNotFoundException(command.UserId);
            }

            var chatId = Guid.NewGuid();

            // There may be edge cases where the newly created chat has an ID that already exists in the database.
            var chatExists = await _chatReadService.ExistsByIdAsync(chatId);

            if (chatExists)
            {
                throw new ChatAlreadyExistsException(chatId);
            }

            var chat = _chatFactory.Create(chatId, "Group");

            var chatUser = new ChatUser(command.UserId, chat.Id);

            chat.AddChatUser(chatUser);

            await _chatRepository.AddChatAsync(chat);
        }
    }
}
