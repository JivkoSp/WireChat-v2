using WireChat.Application.Exceptions;
using WireChat.Application.Services.ReadServices;
using WireChat.Domain.Repositories;
using WireChat.Domain.ValueObjects;

namespace WireChat.Application.Commands.Handlers
{
    internal sealed class AddCreatedGroupNotificationHandler : ICommandHandler<AddCreatedGroupNotificationCommand>
    {
        private readonly INotificationHubRepository _notificationHubRepository;
        private readonly IUserReadService _userReadService;
        private readonly IGroupReadService _groupReadService;

        public AddCreatedGroupNotificationHandler(INotificationHubRepository notificationHubRepository, 
            IUserReadService userReadService, IGroupReadService groupReadService)
        {
            _notificationHubRepository = notificationHubRepository;
            _userReadService = userReadService;
            _groupReadService = groupReadService;
        }

        public async Task HandleAsync(AddCreatedGroupNotificationCommand command)
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

            var groupExists = await _groupReadService.ExistsByIdAsync(command.GroupId);

            if (groupExists is false)
            {
                throw new GroupNotFoundException(command.GroupId);
            }

            var createdGroupNotification = new CreatedGroupNotification(command.UserId, command.GroupId, command.DateTime);

            notificationHub.AddCreatedGroupNotification(createdGroupNotification);

            await _notificationHubRepository.UpdateNotificationHubAsync(notificationHub);
        }
    }
}
