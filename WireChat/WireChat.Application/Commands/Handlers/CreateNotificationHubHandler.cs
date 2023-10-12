using WireChat.Application.Exceptions;
using WireChat.Application.Services.ReadServices;
using WireChat.Domain.Factories.Interfaces;
using WireChat.Domain.Repositories;

namespace WireChat.Application.Commands.Handlers
{
    internal sealed class CreateNotificationHubHandler : ICommandHandler<CreateNotificationHubCommand>
    {
        private readonly INotificationHubRepository _notificationHubRepository;
        private readonly INotificationHubReadService _notificationHubReadService;
        private readonly INotificationHubFactory _notificationHubFactory;

        public CreateNotificationHubHandler(INotificationHubRepository notificationHubRepository, 
            INotificationHubReadService notificationHubReadService, INotificationHubFactory notificationHubFactory)
        {
            _notificationHubRepository = notificationHubRepository;
            _notificationHubReadService = notificationHubReadService;
            _notificationHubFactory = notificationHubFactory;
        }

        public async Task HandleAsync(CreateNotificationHubCommand command)
        {
            var notificationHubExists = await _notificationHubReadService.ExistsByIdAsync(command.NotificationHubId);

            if(notificationHubExists)
            {
                throw new NotificationHubAlreadyExistsException(command.NotificationHubId);
            }

            var notificationHub = _notificationHubFactory.Create(command.NotificationHubId);

            await _notificationHubRepository.AddNotificationHubAsync(notificationHub);
        }
    }
}
