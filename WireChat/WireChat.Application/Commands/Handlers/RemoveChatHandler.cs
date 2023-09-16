using WireChat.Application.Exceptions;
using WireChat.Domain.Repositories;

namespace WireChat.Application.Commands.Handlers
{
    internal sealed class RemoveChatHandler : ICommandHandler<RemoveChatCommand>
    {
        private readonly IChatRepository _chatRepository;

        public RemoveChatHandler(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task HandleAsync(RemoveChatCommand command)
        {
            var chat = await _chatRepository.GetChatByIdAsync(command.ChatId);

            if (chat is null)
            {
                throw new ChatNotFoundException(command.ChatId);
            }

            await _chatRepository.DeleteChatAsync(chat);
        }
    }
}