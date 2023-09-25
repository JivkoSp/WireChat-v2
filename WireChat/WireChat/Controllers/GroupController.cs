using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WireChat.Application.Commands.Dispatcher;
using WireChat.Application.Commands;

namespace WireChat.Controllers
{
    public class GroupController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public GroupController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public async Task AddCroup(string groupName)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var createGroupChatCommand = new CreateGroupChatCommand(userId, groupName);

            await _commandDispatcher.DispatchAsync(createGroupChatCommand);
        }
    }
}
