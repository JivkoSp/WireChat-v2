using WireChat.Application.Exceptions;
using WireChat.Application.Services.ReadServices;
using WireChat.Domain.Repositories;

namespace WireChat.Application.Commands.Handlers
{
    internal sealed class RemoveDeclinedContactRequestNotificationHandler : ICommandHandler<RemoveDeclinedContactRequestNotificationCommand>
    {
        private readonly INotificationHubRepository _notificationHubRepository;
        private readonly IUserReadService _userReadService;

        public RemoveDeclinedContactRequestNotificationHandler(INotificationHubRepository notificationHubRepository, IUserReadService userReadService)
        {
            _notificationHubRepository = notificationHubRepository;
            _userReadService = userReadService;
        }

        public async Task HandleAsync(RemoveDeclinedContactRequestNotificationCommand command)
        {
            var notificationHub = await _notificationHubRepository.GetNotificationHubByIdAsync(command.NotificationHubId);

            if (notificationHub is null)
            {
                throw new NotificationHubNotFoundException(command.NotificationHubId);
            }

            var senderExists = await _userReadService.ExistsByIdAsync(command.SenderUserId);

            if (senderExists is false)
            {
                throw new UserNotFoundException(command.SenderUserId);
            }

            notificationHub.RemoveDeclinedContactRequestNotification(command.SenderUserId);

            await _notificationHubRepository.UpdateNotificationHubAsync(notificationHub);
        }
    }
}
