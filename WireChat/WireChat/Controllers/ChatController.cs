using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json.Nodes;
using WireChat.Application.Commands;
using WireChat.Application.Commands.Dispatcher;
using WireChat.Application.Queries;
using WireChat.Application.Queries.Dispatcher;
using WireChat.Infrastructure.EntityFramework.Models;
using WireChat.ViewModels;

namespace WireChat.Controllers
{
    public class ChatController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly UserManager<UserReadModel> _userManager;

        public ChatController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher, 
            UserManager<UserReadModel> userManager)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(Guid chatId)
        {
            var getChatQuery = new GetChatQuery(chatId);

            var chatDto = await _queryDispatcher.DispatchAsync(getChatQuery);

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var chatViewModel = new ChatViewModel
            {
                CurrentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                CurrentUserPicture = user.UserPicture,
                ChatDto = chatDto,
            };

            return View(chatViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserChat(string issuerUserName)
        {
            var issuer = await _userManager.FindByNameAsync(issuerUserName);

            var receiver = await _userManager.FindByNameAsync(User.Identity.Name);

            var getUserChatQuery = new GetUserChatQuery(issuer.Id, receiver.Id);
        
            var chatId = await _queryDispatcher.DispatchAsync(getUserChatQuery);

            return new JsonResult(new { 
                IssuerUserPicture = issuer.UserPicture,
                ReceiverUserPicture = receiver.UserPicture,
                ChatId = chatId
            });
        }

        [HttpPost]
        public async Task<IActionResult> PostMessage(Guid chatId, string message, DateTimeOffset dateTime)
        {
            var addChatMessageCommand = new AddChatMessageCommand(chatId, Guid.NewGuid(), 
                Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)), message, dateTime);

            await _commandDispatcher.DispatchAsync(addChatMessageCommand);

            return new JsonResult(addChatMessageCommand.ChatMessageId);
        }

        [HttpDelete]
        public async Task RemoveMessage(Guid chatId, Guid chatMessageId)
        {
            var removeChatMessageCommand = new RemoveChatMessageCommand(chatId, chatMessageId);

            await _commandDispatcher.DispatchAsync(removeChatMessageCommand);
        }

        [HttpPost]
        public async Task BlockUser(Guid chatId, string userId)
        {
            var blockChatUserCommand = new BlockChatUserCommand(chatId, Guid.Parse(userId));

            await _commandDispatcher.DispatchAsync(blockChatUserCommand);
        }

        [HttpDelete]
        public async Task UnblockChatUser(Guid chatId, string userId)
        {
            var unblockChatUserCommand = new UnblockChatUserCommand(chatId, Guid.Parse(userId));

            await _commandDispatcher.DispatchAsync(unblockChatUserCommand);
        }

        [HttpGet]
        public async Task<IActionResult> IsUserBlocked(Guid chatId)
        {
            var getBlockedChatMembersQuery = new GetBlockedChatMembersQuery(chatId);

            var blockedChatMembers = await _queryDispatcher.DispatchAsync(getBlockedChatMembersQuery);

            var blockedUser = blockedChatMembers.SingleOrDefault(x => x.UserName == User.Identity.Name);

            return new JsonResult(new { 
            
                IsUserBlocked = blockedUser == null ? false : true
            });
        }
    }
}
