using WireChat.Application.Exceptions;
using WireChat.Application.Services.ReadServices;
using WireChat.Domain.Factories.Interfaces;
using WireChat.Domain.Repositories;

namespace WireChat.Application.Commands.Handlers
{
    internal sealed class AddChatMessageHandler : ICommandHandler<AddChatMessageCommand>
    {
        private readonly IChatRepository _chatRepository;
        private readonly IChatMessageFactory _chatMessageFactory;
        private readonly IUserReadService _userReadService;

        public AddChatMessageHandler(IChatRepository chatRepository, IChatMessageFactory chatMessageFactory, 
            IUserReadService userReadService)
        {
            _chatRepository = chatRepository;
            _chatMessageFactory = chatMessageFactory;
            _userReadService = userReadService;
        }

        public async Task HandleAsync(AddChatMessageCommand command)
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

            var chatMessage = _chatMessageFactory.Create(command.ChatMessageId, command.UserId, command.Message,
                command.MessageDateTime);

            chat.AddMessage(chatMessage);

            await _chatRepository.UpdateChatAsync(chat);
        }
    }
}
