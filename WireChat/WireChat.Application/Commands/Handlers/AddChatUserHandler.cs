using WireChat.Application.Exceptions;
using WireChat.Domain.Repositories;
using WireChat.Domain.ValueObjects;

namespace WireChat.Application.Commands.Handlers
{
    internal sealed class AddChatUserHandler : ICommandHandler<AddChatUserCommand>
    {
        private readonly IChatRepository _chatRepository;

        public AddChatUserHandler(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task HandleAsync(AddChatUserCommand command)
        {
            var chat = await _chatRepository.GetChatByIdAsync(command.ChatId);

            if (chat is null)
            {
                throw new ChatNotFoundException(command.ChatId);
            }

            var chatUser = new ChatUser(command.UserId, command.ChatId);

            chat.AddChatUser(chatUser);

            await _chatRepository.UpdateChatAsync(chat);
        }
    }
}
