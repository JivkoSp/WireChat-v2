using WireChat.Application.Exceptions;
using WireChat.Application.Services.ReadServices;
using WireChat.Domain.Repositories;
using WireChat.Domain.ValueObjects;

namespace WireChat.Application.Commands.Handlers
{
    internal sealed class RemoveChatUserHandler : ICommandHandler<RemoveChatUserCommand>
    {
        private readonly IChatRepository _chatRepository;

        public RemoveChatUserHandler(IChatRepository chatRepository, IUserReadService userReadService)
        {
            _chatRepository = chatRepository;
        }

        public async Task HandleAsync(RemoveChatUserCommand command)
        {
            var chat = await _chatRepository.GetChatByIdAsync(command.ChatId);

            if (chat is null)
            {
                throw new ChatNotFoundException(chat.Id);
            }

            chat.RemoveChatUser(command.UserId);

            await _chatRepository.UpdateChatAsync(chat);
        }
    }
}