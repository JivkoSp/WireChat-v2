using WireChat.Application.Exceptions;
using WireChat.Application.Extensions;
using WireChat.Application.Services.ReadServices;
using WireChat.Domain.Factories.Interfaces;
using WireChat.Domain.Repositories;
using WireChat.Domain.ValueObjects;

namespace WireChat.Application.Commands.Handlers
{
    internal sealed class CreateGroupChatHandler : ICommandHandler<CreateGroupChatCommand>
    {
        private readonly IChatRepository _chatRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IUserReadService _userReadService;
        private readonly IChatFactory _chatFactory;
        private readonly IGroupFactory _groupFactory;
        private readonly IChatReadService _chatReadService;

        public CreateGroupChatHandler(IChatRepository chatRepository, IGroupRepository groupRepository, IChatFactory chatFactory, 
           IGroupFactory groupFactory, IUserReadService userReadService, IChatReadService chatReadService)
        {
            _chatRepository = chatRepository;
            _groupRepository = groupRepository;
            _userReadService = userReadService;
            _chatFactory = chatFactory;
            _groupFactory = groupFactory;
            _chatReadService = chatReadService;
        }
        public async Task HandleAsync(CreateGroupChatCommand command)
        {
            var userExists = await _userReadService.ExistsByIdAsync(command.UserId);

            if (userExists is false)
            {
                throw new UserNotFoundException(command.UserId);
            }

            var chatId = command.UserId.GenerateChatId(command.GroupName);
        
            var chatExists = await _chatReadService.ExistsByIdAsync(chatId);

            if (chatExists)
            {
                throw new ChatAlreadyExistsException(chatId);
            }

            var chat = _chatFactory.Create(chatId, "Group");

            await _chatRepository.AddChatAsync(chat);

            var chatUser = new ChatUser(command.UserId, chat.Id);

            var group = _groupFactory.Create(chatId, command.GroupName, chat);

            group.AddChatUser(chatUser);

            await _groupRepository.AddGroupAsync(group);
        }
    }
}
