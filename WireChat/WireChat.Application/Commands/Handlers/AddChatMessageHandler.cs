using WireChat.Application.Exceptions;
using WireChat.Domain.Factories.Interfaces;
using WireChat.Domain.Repositories;

namespace WireChat.Application.Commands.Handlers
{
    internal sealed class AddChatMessageHandler : ICommandHandler<AddChatMessageCommand>
    {
        private readonly IChatRepository _chatRepository;
        private readonly IChatMessageFactory _chatMessageFactory;

        public AddChatMessageHandler(IChatRepository chatRepository, IChatMessageFactory chatMessageFactory)
        {
            _chatRepository = chatRepository;
            _chatMessageFactory = chatMessageFactory;
        }

        public async Task HandleAsync(AddChatMessageCommand command)
        {
            var chat = await _chatRepository.GetChatByIdAsync(command.ChatId);

            if (chat is null)
            {
                throw new ChatNotFoundException(command.ChatId);
            }

            var chatMessage = _chatMessageFactory.Create(command.ChatMessageId, command.UserId, command.Message,
                command.MessageDateTime);

            chat.AddMessage(chatMessage);

            await _chatRepository.UpdateChatAsync(chat);
        }
    }
}
