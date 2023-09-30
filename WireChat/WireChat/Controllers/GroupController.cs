using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WireChat.Application.Commands.Dispatcher;
using WireChat.Application.Commands;
using Microsoft.AspNetCore.Identity;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Controllers
{
    public class GroupController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly UserManager<UserReadModel> _userManager;

        public GroupController(ICommandDispatcher commandDispatcher, UserManager<UserReadModel> userManager)
        {
            _commandDispatcher = commandDispatcher;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task AddCroup(string groupName)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var createGroupChatCommand = new CreateGroupChatCommand(userId, groupName);

            await _commandDispatcher.DispatchAsync(createGroupChatCommand);
        }

        [HttpPost]
        public async Task AddCroupMember(Guid chatId, string userName)
        {
            var currentUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var newChatUserId = await _userManager.FindByNameAsync(userName);

            var addChatUserCommand = new AddChatUserCommand(chatId, Guid.Parse(newChatUserId.Id), currentUserId);

            await _commandDispatcher.DispatchAsync(addChatUserCommand);
        }

        [HttpDelete]
        public async Task RemoveCroupMember(Guid chatId, string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            var removeChatUserCommand = new RemoveChatUserCommand(chatId, Guid.Parse(user.Id));

            await _commandDispatcher.DispatchAsync(removeChatUserCommand);
        }
    }
}
