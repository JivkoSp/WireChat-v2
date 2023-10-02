using WireChat.Application.Exceptions;
using WireChat.Application.Services.ReadServices;
using WireChat.Domain.Repositories;
using WireChat.Domain.ValueObjects;

namespace WireChat.Application.Commands.Handlers
{
    internal sealed class AddChatUserHandler : ICommandHandler<AddChatUserCommand>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IUserReadService _userReadService;

        public AddChatUserHandler(IGroupRepository groupRepository, IUserReadService userReadService)
        {
            _groupRepository = groupRepository;
            _userReadService = userReadService;
        }

        public async Task HandleAsync(AddChatUserCommand command)
        {
            var group = await _groupRepository.GetGroupByIdAsync(command.ChatId);

            if (group is null)
            {
                throw new GroupNotFoundException(command.ChatId);
            }

            var newChatUserExists = await _userReadService.ExistsByIdAsync(command.NewChatUserId);

            if (newChatUserExists is false)
            {
                throw new UserNotFoundException(command.NewChatUserId);
            }

            var userExists = await _userReadService.ExistsByIdAsync(command.UserId);

            if (userExists is false)
            {
                throw new UserNotFoundException(command.UserId);
            }

            var hasUserInContacts = await _userReadService.HasUserInContactsAsync(command.UserId, command.NewChatUserId);

            if(hasUserInContacts is false)
            {
                throw new ContactNotFoundException(command.UserId, command.NewChatUserId);
            }

            var chatUser = new ChatUser(command.NewChatUserId, command.ChatId);

            group.AddChatUser(chatUser);

            await _groupRepository.UpdateGroupAsync(group);
        }
    }
}
