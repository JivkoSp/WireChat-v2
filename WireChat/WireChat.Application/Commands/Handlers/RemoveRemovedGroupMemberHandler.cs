using WireChat.Application.Exceptions;
using WireChat.Application.Services.ReadServices;
using WireChat.Domain.Repositories;

namespace WireChat.Application.Commands.Handlers
{
    internal sealed class RemoveRemovedGroupMemberHandler : ICommandHandler<RemoveRemovedGroupMemberNotification>
    {
        private readonly INotificationHubRepository _notificationHubRepository;
        private readonly IUserReadService _userReadService;

        public RemoveRemovedGroupMemberHandler(INotificationHubRepository notificationHubRepository, IUserReadService userReadService)
        {
            _notificationHubRepository = notificationHubRepository;
            _userReadService = userReadService;
        }

        public async Task HandleAsync(RemoveRemovedGroupMemberNotification command)
        {
            var notificationHub = await _notificationHubRepository.GetNotificationHubByIdAsync(command.NotificationHubId);

            if (notificationHub is null)
            {
                throw new NotificationHubNotFoundException(command.NotificationHubId);
            }

            var groupMemberExists = await _userReadService.ExistsByIdAsync(command.GroupMemberUserId);

            if(groupMemberExists is false) 
            { 
                throw new UserNotFoundException(command.GroupMemberUserId);
            }

            notificationHub.RemoveRemovedGroupMemberNotification(command.GroupMemberUserId);

            await _notificationHubRepository.UpdateNotificationHubAsync(notificationHub);
        }
    }
}
