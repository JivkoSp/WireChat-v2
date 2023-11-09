using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WireChat.Application.Commands;
using WireChat.Application.Commands.Dispatcher;
using WireChat.Application.Queries;
using WireChat.Application.Queries.Dispatcher;
using WireChat.Infrastructure.Dtos.SignalR;
using WireChat.Infrastructure.EntityFramework.Models;
using WireChat.ViewModels;

namespace WireChat.Controllers
{
    [Authorize]
    public class ContactRequestController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly UserManager<UserReadModel> _userManager;

        public ContactRequestController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher,
            UserManager<UserReadModel> userManager)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var getIssuedContactRequestsQuery = new GetIssuedContactRequestsQuery(_userManager.GetUserId(User));

            var getReceivedContactRequestsQuery = new GetReceivedContactRequestsQuery(_userManager.GetUserId(User));

            var issuedContactRequests = await _queryDispatcher.DispatchAsync(getIssuedContactRequestsQuery);

            var receivedContactRequests = await _queryDispatcher.DispatchAsync(getReceivedContactRequestsQuery);

            var contactRequestViewModel = new ContactRequestViewModel
            {
                IssuedContactRequests = issuedContactRequests,
                ReceivedContactRequests = receivedContactRequests
            };

            return View(contactRequestViewModel);
        }

        [HttpPost]
        public async Task IssueContactRequest(SignalRContactRequestDto contactRequestDto)
        {
            var senderUserId = Guid.Parse(_userManager.GetUserId(User));

            var receiver = await _userManager.FindByNameAsync(contactRequestDto.ReceiverUserName);

            var addContactRequestCommand = new AddContactRequestCommand(senderUserId, Guid.Parse(receiver.Id), 
                contactRequestDto.ContactMessage);

            await _commandDispatcher.DispatchAsync(addContactRequestCommand);
        }

        [HttpPost]
        public async Task AddContactRequest(string senderUserName)
        {
            var receiverUserId = Guid.Parse(_userManager.GetUserId(User));

            var sender = await _userManager.FindByNameAsync(senderUserName);

            var createOneToOneChatCommand = new CreateOneToOneChatCommand(Guid.Parse(sender.Id), receiverUserId);

            await _commandDispatcher.DispatchAsync(createOneToOneChatCommand);
        }

        [HttpDelete]
        public async Task RemoveIssuedContactRequest(string receiverUserName)
        {
            var senderUserId = Guid.Parse(_userManager.GetUserId(User));

            var receiver = await _userManager.FindByNameAsync(receiverUserName);

            var removeIssuedContactRequestCommand = new RemoveIssuedContactRequestCommand(senderUserId, Guid.Parse(receiver.Id));

            await _commandDispatcher.DispatchAsync(removeIssuedContactRequestCommand);
        }

        [HttpDelete]
        public async Task RemoveReceivedContactRequest(string senderUserName)
        {
            var receiverUserId = Guid.Parse(_userManager.GetUserId(User));

            var sender = await _userManager.FindByNameAsync(senderUserName);

            var removeIssuedContactRequestCommand = new RemoveReceivedContactRequestCommand(Guid.Parse(sender.Id), receiverUserId);

            await _commandDispatcher.DispatchAsync(removeIssuedContactRequestCommand);
        }
    }
}
