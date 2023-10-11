using WireChat.Application.Exceptions;
using WireChat.Application.Services.ReadServices;
using WireChat.Domain.Repositories;
using WireChat.Domain.ValueObjects;

namespace WireChat.Application.Commands.Handlers
{
    internal sealed class AddBannedGroupMemberNotificationHandler : ICommandHandler<AddBannedGroupMemberNotificationCommand>
    {
        private readonly INotificationHubRepository _notificationHubRepository;
        private readonly IUserReadService _userReadService;
        private readonly IGroupReadService _groupReadService;

        public AddBannedGroupMemberNotificationHandler(INotificationHubRepository notificationHubRepository,
            IUserReadService userReadService, IGroupReadService groupReadService)
        {
            _notificationHubRepository = notificationHubRepository;
            _userReadService = userReadService;
            _groupReadService = groupReadService;
        }

        public async Task HandleAsync(AddBannedGroupMemberNotificationCommand command)
        {
            var notificationHub = await _notificationHubRepository.GetNotificationHubByIdAsync(command.NotificationHubId);

            if (notificationHub is null)
            {
                throw new NotificationHubNotFoundException(command.NotificationHubId);
            }

            var groupAdminExists = await _userReadService.ExistsByIdAsync(command.GroupAdminUserId);

            if (groupAdminExists is false)
            {
                throw new UserNotFoundException(command.GroupAdminUserId);
            }

            var groupMemberExists = await _userReadService.ExistsByIdAsync(command.GroupMemberUserId);

            if (groupMemberExists is false)
            {
                throw new UserNotFoundException(command.GroupMemberUserId);
            }

            var groupExists = await _groupReadService.ExistsByIdAsync(command.GroupId);

            if (groupExists is false)
            {
                throw new GroupNotFoundException(command.GroupId);
            }

            var bannedGroupMemberNotification = 
                new BannedGroupMemberNotification(command.GroupAdminUserId, command.GroupMemberUserId, command.GroupId, command.DateTime);

            notificationHub.AddBannedGroupMemberNotification(bannedGroupMemberNotification);

            await _notificationHubRepository.UpdateNotificationHubAsync(notificationHub);
        }
    }
}
