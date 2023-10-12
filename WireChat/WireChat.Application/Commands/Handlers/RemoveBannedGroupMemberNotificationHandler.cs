using WireChat.Application.Exceptions;
using WireChat.Application.Services.ReadServices;
using WireChat.Domain.Repositories;

namespace WireChat.Application.Commands.Handlers
{
    internal sealed class RemoveBannedGroupMemberNotificationHandler : ICommandHandler<RemoveBannedGroupMemberNotificationCommand>
    {
        private readonly INotificationHubRepository _notificationHubRepository;
        private readonly IUserReadService _userReadService;

        public RemoveBannedGroupMemberNotificationHandler(INotificationHubRepository notificationHubRepository, IUserReadService userReadService)
        {
            _notificationHubRepository = notificationHubRepository;
            _userReadService = userReadService;
        }

        public async Task HandleAsync(RemoveBannedGroupMemberNotificationCommand command)
        {
            var notificationHub = await _notificationHubRepository.GetNotificationHubByIdAsync(command.NotificationHubId);

            if (notificationHub is null)
            {
                throw new NotificationHubNotFoundException(command.NotificationHubId);
            }

            var groupMemberExists = await _userReadService.ExistsByIdAsync(command.GroupMemberUserId);

            if (groupMemberExists is false)
            {
                throw new UserNotFoundException(command.GroupMemberUserId);
            }

            notificationHub.RemoveBannedGroupMemberNotification(command.GroupMemberUserId);

            await _notificationHubRepository.UpdateNotificationHubAsync(notificationHub);
        }
    }
}
