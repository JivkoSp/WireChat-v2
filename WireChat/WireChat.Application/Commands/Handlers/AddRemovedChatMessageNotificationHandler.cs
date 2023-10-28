using WireChat.Application.Exceptions;
using WireChat.Application.Services.ReadServices;
using WireChat.Domain.Repositories;
using WireChat.Domain.ValueObjects;

namespace WireChat.Application.Commands.Handlers
{
    internal sealed class AddRemovedChatMessageNotificationHandler : ICommandHandler<AddRemovedChatMessageNotificationCommand>
    {
        private readonly INotificationHubRepository _notificationHubRepository;
        private readonly IChatReadService _chatReadService;
        private readonly IUserReadService _userReadService;

        public AddRemovedChatMessageNotificationHandler(INotificationHubRepository notificationHubRepository, IChatReadService chatReadService,
            IUserReadService userReadService)
        {
            _notificationHubRepository = notificationHubRepository;
            _chatReadService = chatReadService;
            _userReadService = userReadService;
        }

        public async Task HandleAsync(AddRemovedChatMessageNotificationCommand command)
        {
            var notificationHub = await _notificationHubRepository.GetNotificationHubByIdAsync(command.NotificationHubId);

            if (notificationHub is null)
            {
                throw new NotificationHubNotFoundException(command.NotificationHubId);
            }

            var chatExists = await _chatReadService.ExistsByIdAsync(command.ChatId);

            if (chatExists is false)
            {
                throw new ChatNotFoundException(command.ChatId);
            }

            var chatMessageExists = await _chatReadService.ChatMessageExistsByIdAsync(command.ChatMessageId);

            if (chatMessageExists is false)
            {
                throw new ChatMessageNotFoundException(command.ChatMessageId);
            }

            var userExists = await _userReadService.ExistsByIdAsync(command.UserId);

            if (userExists is false)
            {
                throw new UserNotFoundException(command.UserId);
            }

            var removedChatMessageNotification = 
                new RemovedChatMessageNotification(command.ChatId, command.ChatMessageId, command.UserId, 
                command.NotificationHubId, command.DateTime);

            notificationHub.AddRemovedChatMessageNotification(removedChatMessageNotification);

            await _notificationHubRepository.UpdateNotificationHubAsync(notificationHub);
        }
    }
}
