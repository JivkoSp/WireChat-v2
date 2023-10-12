using WireChat.Application.Exceptions;
using WireChat.Application.Services.ReadServices;
using WireChat.Domain.Repositories;

namespace WireChat.Application.Commands.Handlers
{
    internal sealed class RemoveCreatedGroupNotificationHandler : ICommandHandler<RemoveCreatedGroupNotificationCommand>
    {
        private readonly INotificationHubRepository _notificationHubRepository;
        private readonly IGroupReadService _groupReadService;

        public RemoveCreatedGroupNotificationHandler(INotificationHubRepository notificationHubRepository, IGroupReadService groupReadService)
        {
            _notificationHubRepository = notificationHubRepository;
            _groupReadService = groupReadService;
        }

        public async Task HandleAsync(RemoveCreatedGroupNotificationCommand command)
        {
            var notificationHub = await _notificationHubRepository.GetNotificationHubByIdAsync(command.NotificationHubId);

            if (notificationHub is null)
            {
                throw new NotificationHubNotFoundException(command.NotificationHubId);
            }

            var groupExists = await _groupReadService.ExistsByIdAsync(command.GroupId);

            if (groupExists is false)
            {
                throw new GroupNotFoundException(command.GroupId);
            }

            notificationHub.RemoveCreatedGroupNotification(command.GroupId);

            await _notificationHubRepository.UpdateNotificationHubAsync(notificationHub);
        }
    }
}
