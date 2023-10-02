using WireChat.Application.Exceptions;
using WireChat.Application.Services.ReadServices;
using WireChat.Domain.Repositories;
using WireChat.Domain.ValueObjects;

namespace WireChat.Application.Commands.Handlers
{
    internal sealed class BlockChatUserHandler : ICommandHandler<BlockChatUserCommand>
    {
        private readonly IChatRepository _chatRepository;
        private readonly IUserReadService _userReadService;

        public BlockChatUserHandler(IChatRepository chatRepository, IUserReadService userReadService)
        {
            _chatRepository = chatRepository;
            _userReadService = userReadService;
        }

        public async Task HandleAsync(BlockChatUserCommand command)
        {
            var chat = await _chatRepository.GetChatByIdAsync(command.ChatId);

            if (chat is null)
            {
                throw new ChatNotFoundException(command.ChatId);
            }

            var userExists = await _userReadService.ExistsByIdAsync(command.UserId);

            if (userExists is false)
            {
                throw new UserNotFoundException(command.UserId);
            }

            var blockedChatUser = new BlockedChatUser(command.UserId, command.ChatId);

            chat.BlockChatUser(blockedChatUser);

            await _chatRepository.UpdateChatAsync(chat);
        }
    }
}
