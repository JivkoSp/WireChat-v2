using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WireChat.Application.Commands.Dispatcher;
using WireChat.Application.Commands;
using Microsoft.AspNetCore.Identity;
using WireChat.Infrastructure.EntityFramework.Models;
using WireChat.Application.Queries.Dispatcher;
using WireChat.Application.Queries;
using WireChat.Application.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace WireChat.Controllers
{
    [Authorize]
    public class GroupController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly UserManager<UserReadModel> _userManager;

        public GroupController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher, UserManager<UserReadModel> userManager)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task AddCroup(string groupName)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var createGroupChatCommand = new CreateGroupChatCommand(userId, groupName);

            await _commandDispatcher.DispatchAsync(createGroupChatCommand);
        }

        [HttpGet]
        public async Task<IActionResult> GetGroupByName(string groupName)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var getGroupByNameQuery = new GetGroupByNameQuery(userId, groupName);
        
            var group = await _queryDispatcher.DispatchAsync(getGroupByNameQuery);

            return new JsonResult(group);
        }

        [HttpPost]
        public async Task AddCroupMember(Guid chatId, string userName)
        {
            var currentUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var newChatUserId = await _userManager.FindByNameAsync(userName);

            var addChatUserCommand = new AddChatUserCommand(chatId, Guid.Parse(newChatUserId.Id), currentUserId);

            await _commandDispatcher.DispatchAsync(addChatUserCommand);
        }

        [HttpGet]
        public async Task<IActionResult> GetGroupMember(Guid chatId, string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            var getChatUserQuery = new GetChatUserQuery(chatId, user.Id);

            var groupMember = await _queryDispatcher.DispatchAsync(getChatUserQuery);

            return new JsonResult(groupMember); 
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
