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

        [HttpPost]
        public async Task AddAddedGroupMemberNotification(Guid notificationHubId, Guid groupAdminUserId, 
            Guid groupMemberUserId, Guid groupId)
        {
            var addAddedGroupMemberNotificationCommand = new AddAddedGroupMemberNotificationCommand(notificationHubId, 
                groupAdminUserId, groupMemberUserId, groupId, DateTimeOffset.Now);

            await _commandDispatcher.DispatchAsync(addAddedGroupMemberNotificationCommand);
        }

        [HttpPost]
        public async Task AddBannedContactNotification(Guid notificationHubId, Guid userId, Guid chatId)
        {
            var addBannedContactNotificationCommand = 
                new AddBannedContactNotificationCommand(notificationHubId, userId, chatId, DateTimeOffset.Now);

            await _commandDispatcher.DispatchAsync(addBannedContactNotificationCommand);
        }

        [HttpPost]
        public async Task AddBannedGroupMemberNotification(Guid notificationHubId, string groupMemberUserName, Guid groupId)
        {
            var groupAdminUserId = Guid.Parse(_userManager.GetUserId(User));

            var groupMember = await _userManager.FindByNameAsync(groupMemberUserName);

            var addBannedGroupMemberNotificationCommand = new AddBannedGroupMemberNotificationCommand(notificationHubId, 
                groupAdminUserId, Guid.Parse(groupMember.Id), groupId, DateTimeOffset.Now);

            await _commandDispatcher.DispatchAsync(addBannedGroupMemberNotificationCommand);
        }

        [HttpPost]
        public async Task AddCreatedGroupNotification(Guid notificationHubId, Guid userId, Guid groupId)
        {
            var addCreatedGroupNotificationCommand = 
                new AddCreatedGroupNotificationCommand(notificationHubId, userId, groupId, DateTimeOffset.Now);

            await _commandDispatcher.DispatchAsync(addCreatedGroupNotificationCommand);
        }

        [HttpPost]
        public async Task AddDeclinedContactRequestNotification(Guid notificationHubId, string senderUserName)
        {
            var receiverUserId = Guid.Parse(_userManager.GetUserId(User));

            var sender = await _userManager.FindByNameAsync(senderUserName);

            var addDeclinedContactRequestNotificationCommand = new AddDeclinedContactRequestNotificationCommand(notificationHubId, 
                Guid.Parse(sender.Id), receiverUserId, DateTimeOffset.Now);

            await _commandDispatcher.DispatchAsync(addDeclinedContactRequestNotificationCommand);
        }
    }
}
