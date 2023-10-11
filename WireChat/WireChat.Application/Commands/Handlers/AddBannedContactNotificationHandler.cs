using WireChat.Application.Exceptions;
using WireChat.Application.Services.ReadServices;
using WireChat.Domain.Repositories;
using WireChat.Domain.ValueObjects;

namespace WireChat.Application.Commands.Handlers
{
    internal sealed class AddBannedContactNotificationHandler : ICommandHandler<AddBannedContactNotificationCommand>
    {
        private readonly INotificationHubRepository _notificationHubRepository;
        private readonly IUserReadService _userReadService;

        public AddBannedContactNotificationHandler(INotificationHubRepository notificationHubRepository, IUserReadService userReadService)
        {
            _notificationHubRepository = notificationHubRepository;
            _userReadService = userReadService; 
        }

        public async Task HandleAsync(AddBannedContactNotificationCommand command)
        {
            var notificationHub = await _notificationHubRepository.GetNotificationHubByIdAsync(command.NotificationHubId);

            if (notificationHub is null)
            {
                throw new NotificationHubNotFoundException(command.NotificationHubId);
            }

            var userExists = await _userReadService.ExistsByIdAsync(command.UserId);

            if (userExists is false)
            {
                throw new UserNotFoundException(command.UserId);
            }

            var bannedContactNotification = new BannedContactNotification(command.UserId, command.ChatId, command.DateTime);

            notificationHub.AddBannedContactNotification(bannedContactNotification);

            await _notificationHubRepository.UpdateNotificationHubAsync(notificationHub);
        }
    }
}
