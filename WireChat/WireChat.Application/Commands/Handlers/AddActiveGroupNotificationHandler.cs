using WireChat.Application.Exceptions;
using WireChat.Application.Services.ReadServices;
using WireChat.Domain.Repositories;
using WireChat.Domain.ValueObjects;

namespace WireChat.Application.Commands.Handlers
{
    internal sealed class AddActiveGroupNotificationHandler : ICommandHandler<AddActiveGroupNotificationCommand>
    {
        private readonly INotificationHubRepository _notificationHubRepository;
        private readonly IGroupReadService _groupReadService;

        public AddActiveGroupNotificationHandler(INotificationHubRepository notificationHubRepository, IGroupReadService groupReadService)
        {
            _notificationHubRepository = notificationHubRepository;
            _groupReadService = groupReadService;
        }

        public async Task HandleAsync(AddActiveGroupNotificationCommand command)
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

            var activeGroupNotification = new ActiveGroupNotification(command.GroupId, command.NotificationHubId);

            notificationHub.AddActiveGroupNotification(activeGroupNotification);

            await _notificationHubRepository.UpdateNotificationHubAsync(notificationHub);
        }
    }
}
