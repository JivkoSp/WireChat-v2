using WireChat.Application.Exceptions;
using WireChat.Domain.Repositories;

namespace WireChat.Application.Commands.Handlers
{
    internal sealed class RemoveChatMessageHandler : ICommandHandler<RemoveChatMessageCommand>
    {
        private readonly IChatRepository _chatRepository;

        public RemoveChatMessageHandler(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task HandleAsync(RemoveChatMessageCommand command)
        {
            var chat = await _chatRepository.GetChatByIdAsync(command.ChatId);

            if (chat is null)
            {
                throw new ChatNotFoundException(chat.Id);
            }

            chat.RemoveMessage(command.ChatMessageId);

            await _chatRepository.UpdateChatAsync(chat);
        }
    }
}