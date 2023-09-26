using WireChat.Application.Exceptions;
using WireChat.Application.Extensions;
using WireChat.Application.Services.ReadServices;
using WireChat.Domain.Factories.Interfaces;
using WireChat.Domain.Repositories;
using WireChat.Domain.ValueObjects;

namespace WireChat.Application.Commands.Handlers
{
    internal sealed class CreateOneToOneChatHandler : ICommandHandler<CreateOneToOneChatCommand>
    {
        private readonly IChatRepository _chatRepository;
        private readonly IChatFactory _chatFactory;
        private readonly IUserReadService _userReadService;
        private readonly IChatReadService _chatReadService;

        public CreateOneToOneChatHandler(IChatRepository chatRepository, IChatFactory chatFactory, 
            IUserReadService userReadService, IChatReadService chatReadService)
        {
            _chatRepository = chatRepository;
            _chatFactory = chatFactory;
            _userReadService = userReadService;
            _chatReadService = chatReadService;
        }

        public async Task HandleAsync(CreateOneToOneChatCommand command)
        {
            var senderExists = await _userReadService.ExistsByIdAsync(command.SenderUserId);

            if (senderExists is false)
            {
                throw new UserNotFoundException(command.SenderUserId);
            }

            var receiverExists = await _userReadService.ExistsByIdAsync(command.ReceiverUserId);

            if (receiverExists is false)
            {
                throw new UserNotFoundException(command.ReceiverUserId);
            }
            
            var chatId = command.SenderUserId.GenerateChatId(command.ReceiverUserId);

            var chatExists = await _chatReadService.ExistsByIdAsync(chatId);

            if (chatExists)
            {
                throw new ChatAlreadyExistsException(chatId);
            }

            var chat = _chatFactory.Create(chatId, "OneToOne");

            var sender = new ChatUser(command.SenderUserId, chat.Id);

            var receiver = new ChatUser(command.ReceiverUserId, chat.Id);

            chat.AddChatUser(sender);

            chat.AddChatUser(receiver);

            await _chatRepository.AddChatAsync(chat);
        }
    }
}