using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WireChat.Application.Commands;
using WireChat.Application.Commands.Dispatcher;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Controllers
{
    public class NotificationHubController : Controller
    {
        private readonly UserManager<UserReadModel> _userManager;
        private readonly ICommandDispatcher _commandDispatcher;

        public NotificationHubController(UserManager<UserReadModel> userManager, ICommandDispatcher commandDispatcher)
        {
            _userManager = userManager;
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public async Task AddAcceptedContactRequestNotification(Guid notificationHubId, string senderUserName)
        {
            var receiverUserId = Guid.Parse(_userManager.GetUserId(User));

            var sender = await _userManager.FindByNameAsync(senderUserName);

            var addAcceptedContactRequestNotificationCommand = 
                new AddAcceptedContactRequestNotificationCommand(notificationHubId, Guid.Parse(sender.Id), 
                receiverUserId, DateTimeOffset.Now);

            await _commandDispatcher.DispatchAsync(addAcceptedContactRequestNotificationCommand);
        }
    }
}
