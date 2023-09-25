using WireChat.Application.Exceptions;
using WireChat.Application.Services.ReadServices;
using WireChat.Domain.Repositories;
using WireChat.Domain.ValueObjects;

namespace WireChat.Application.Commands.Handlers
{
    internal sealed class AddChatMessageHandler : ICommandHandler<AddChatMessageCommand>
    {
        private readonly IChatRepository _chatRepository;
        private readonly IUserReadService _userReadService;

        public AddChatMessageHandler(IChatRepository chatRepository, IUserReadService userReadService)
        {
            _chatRepository = chatRepository;
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

            var chatMessage =  new ChatMessage(command.ChatMessageId, command.ChatId, command.UserId, command.Message,
                command.MessageDateTime);

            chat.AddMessage(chatMessage);

            await _chatRepository.UpdateChatAsync(chat);
        }
    }
}
