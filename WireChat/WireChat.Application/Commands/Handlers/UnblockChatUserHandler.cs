using WireChat.Application.Exceptions;
using WireChat.Domain.Repositories;

namespace WireChat.Application.Commands.Handlers
{
    internal sealed class UnblockChatUserHandler : ICommandHandler<UnblockChatUserCommand>
    {
        private readonly IChatRepository _chatRepository;

        public UnblockChatUserHandler(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task HandleAsync(UnblockChatUserCommand command)
        {
            var chat = await _chatRepository.GetChatByIdAsync(command.ChatId);

            if (chat is null)
            {
                throw new ChatNotFoundException(chat.Id);
            }

            chat.UnblockChatUser(command.UserId);

            await _chatRepository.UpdateChatAsync(chat);
        }
    }
}
