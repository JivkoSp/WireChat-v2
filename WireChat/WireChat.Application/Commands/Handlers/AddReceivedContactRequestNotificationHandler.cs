using WireChat.Application.Exceptions;
using WireChat.Application.Services.ReadServices;
using WireChat.Domain.Repositories;
using WireChat.Domain.ValueObjects;

namespace WireChat.Application.Commands.Handlers
{
    internal sealed class AddReceivedContactRequestNotificationHandler : ICommandHandler<AddReceivedContactRequestNotificationCommand>
    {
        private readonly INotificationHubRepository _notificationHubRepository;
        private readonly IUserReadService _userReadService;

        public AddReceivedContactRequestNotificationHandler(INotificationHubRepository notificationHubRepository, IUserReadService userReadService)
        {
            _notificationHubRepository = notificationHubRepository;
            _userReadService = userReadService;
        }

        public async Task HandleAsync(AddReceivedContactRequestNotificationCommand command)
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

            var receiverExists = await _userReadService.ExistsByIdAsync(command.ReceiverUserId);

            if (receiverExists is false)
            {
                throw new UserNotFoundException(command.ReceiverUserId);
            }

            var receivedContactRequestNotification = 
                new ReceivedContactRequestNotification(command.SenderUserId, command.ReceiverUserId, command.DateTime);

            notificationHub.AddReceivedContactRequestNotification(receivedContactRequestNotification);

            await _notificationHubRepository.UpdateNotificationHubAsync(notificationHub);
        }
    }
}
