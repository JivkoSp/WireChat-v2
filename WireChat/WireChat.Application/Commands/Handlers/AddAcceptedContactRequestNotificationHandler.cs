using WireChat.Application.Exceptions;
using WireChat.Application.Services.ReadServices;
using WireChat.Domain.Repositories;
using WireChat.Domain.ValueObjects;

namespace WireChat.Application.Commands.Handlers
{
    internal sealed class AddAcceptedContactRequestNotificationHandler : ICommandHandler<AddAcceptedContactRequestNotificationCommand>
    {
        private readonly INotificationHubRepository _notificationHubRepository;
        private readonly IUserReadService _userReadService;

        public AddAcceptedContactRequestNotificationHandler(INotificationHubRepository notificationHubRepository, IUserReadService userReadService)
        {
            _notificationHubRepository = notificationHubRepository;
            _userReadService = userReadService;
        }

        public async Task HandleAsync(AddAcceptedContactRequestNotificationCommand command)
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

            if(receiverExists is false)
            {
                throw new UserNotFoundException(command.ReceiverUserId);
            }

            var acceptedContactRequestNotification = 
                new AcceptedContactRequestNotification(command.SenderUserId, command.ReceiverUserId, 
                command.NotificationHubId, command.DateTime);

            notificationHub.AddAcceptedContactRequestNotification(acceptedContactRequestNotification);

            await _notificationHubRepository.UpdateNotificationHubAsync(notificationHub);
        }
    }
}
