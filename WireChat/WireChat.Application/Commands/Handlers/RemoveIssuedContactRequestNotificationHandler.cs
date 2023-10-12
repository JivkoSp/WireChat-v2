using WireChat.Application.Exceptions;
using WireChat.Application.Services.ReadServices;
using WireChat.Domain.Repositories;

namespace WireChat.Application.Commands.Handlers
{
    internal sealed class RemoveIssuedContactRequestNotificationHandler : ICommandHandler<RemoveIssuedContactRequestNotificationCommand>
    {
        private readonly INotificationHubRepository _notificationHubRepository;
        private readonly IUserReadService _userReadService;

        public RemoveIssuedContactRequestNotificationHandler(INotificationHubRepository notificationHubRepository, IUserReadService userReadService)
        {
            _notificationHubRepository = notificationHubRepository;
            _userReadService = userReadService;
        }

        public async Task HandleAsync(RemoveIssuedContactRequestNotificationCommand command)
        {
            var notificationHub = await _notificationHubRepository.GetNotificationHubByIdAsync(command.NotificationHubId);

            if (notificationHub is null)
            {
                throw new NotificationHubNotFoundException(command.NotificationHubId);
            }

            var receiverExists = await _userReadService.ExistsByIdAsync(command.ReceiverUserId);

            if (receiverExists is false)
            {
                throw new UserNotFoundException(command.ReceiverUserId);
            }

            notificationHub.RemoveIssuedContactRequestNotification(command.ReceiverUserId);

            await _notificationHubRepository.UpdateNotificationHubAsync(notificationHub);
        }
    }
}
