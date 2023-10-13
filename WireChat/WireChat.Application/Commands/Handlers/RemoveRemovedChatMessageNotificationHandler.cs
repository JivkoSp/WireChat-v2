using WireChat.Application.Exceptions;
using WireChat.Application.Services.ReadServices;
using WireChat.Domain.Repositories;

namespace WireChat.Application.Commands.Handlers
{
    internal sealed class RemoveRemovedChatMessageNotificationHandler : ICommandHandler<RemoveRemovedChatMessageNotificationCommand>
    {
        private readonly INotificationHubRepository _notificationHubRepository;
        private readonly IChatReadService _chatReadService;

        public RemoveRemovedChatMessageNotificationHandler(INotificationHubRepository notificationHubRepository, IChatReadService chatReadService)
        {
            _notificationHubRepository = notificationHubRepository;
            _chatReadService = chatReadService;
        }

        public async Task HandleAsync(RemoveRemovedChatMessageNotificationCommand command)
        {
            var notificationHub = await _notificationHubRepository.GetNotificationHubByIdAsync(command.NotificationHubId);

            if (notificationHub is null)
            {
                throw new NotificationHubNotFoundException(command.NotificationHubId);
            }

            var chatMessageExists = await _chatReadService.ChatMessageExistsByIdAsync(command.ChatMessageId);

            if(chatMessageExists is false) 
            { 
                throw new ChatMessageNotFoundException(command.ChatMessageId);
            }

            notificationHub.RemoveRemovedChatMessageNotification(command.ChatMessageId);

            await _notificationHubRepository.UpdateNotificationHubAsync(notificationHub);
        }
    }
}
