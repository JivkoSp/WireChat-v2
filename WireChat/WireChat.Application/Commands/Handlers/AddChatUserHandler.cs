﻿using WireChat.Application.Exceptions;
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
            
            var userExists = await _userReadService.ExistsByIdAsync(command.UserId);

            if (userExists is false)
            {
                throw new UserNotFoundException(command.UserId);
            }

            var chatUser = new ChatUser(command.UserId, command.ChatId);

            group.AddChatUser(chatUser);

            await _groupRepository.UpdateGroupAsync(group);
        }
    }
}
