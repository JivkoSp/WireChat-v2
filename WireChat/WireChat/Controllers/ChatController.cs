using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WireChat.Application.Commands;
using WireChat.Application.Commands.Dispatcher;
using WireChat.Application.Dtos;
using WireChat.Application.Queries;
using WireChat.Application.Queries.Dispatcher;
using WireChat.ViewModels;

namespace WireChat.Controllers
{
    public class ChatController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public ChatController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> Index(Guid chatId)
        {
            var getChatQuery = new GetChatQuery(chatId);

            var chatDto = await _queryDispatcher.DispatchAsync(getChatQuery);

            var chatViewModel = new ChatViewModel
            {
                CurrentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                ChatDto = chatDto,
            };

            return View(chatViewModel);
        }

        [HttpPost]
        public async Task PostMessage(Guid chatId, string message, DateTimeOffset dateTime)
        {
            var addChatMessageCommand = new AddChatMessageCommand(chatId, Guid.NewGuid(), 
                Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)), message, dateTime);

            await _commandDispatcher.DispatchAsync(addChatMessageCommand);
        }
    }
}
