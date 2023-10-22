using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WireChat.Application.Commands;
using WireChat.Application.Commands.Dispatcher;
using WireChat.Application.Queries;
using WireChat.Application.Queries.Dispatcher;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Controllers
{
    public class NotificationHubController : Controller
    {
        private readonly UserManager<UserReadModel> _userManager;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public NotificationHubController(UserManager<UserReadModel> userManager, ICommandDispatcher commandDispatcher,
            IQueryDispatcher queryDispatcher)
        {
            _userManager = userManager;
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotificationHub()
        {
            var userId = Guid.Parse(_userManager.GetUserId(User));

            var getNotificationHubQuery = new GetNotificationHubQuery(userId);

            var notificationHub = await _queryDispatcher.DispatchAsync(getNotificationHubQuery);

            return new JsonResult(notificationHub);
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

        [HttpPost]
        public async Task AddActiveGroupNotification(Guid notificationHubId, Guid groupId)
        {
            var addActiveGroupNotificationCommand = new AddActiveGroupNotificationCommand(notificationHubId, groupId);

            await _commandDispatcher.DispatchAsync(addActiveGroupNotificationCommand);
        }
    }
}
