using Microsoft.AspNetCore.Mvc;
using WireChat.Application.Queries;
using WireChat.Application.Queries.Dispatcher;

namespace WireChat.Components
{
    public class ContactViewComponent : ViewComponent
    {
        private readonly IQueryDispatcher _queryDispatcher;

        public ContactViewComponent(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        public async Task<IViewComponentResult> InvokeAsync(string userId)
        {
            var getChatUserQuery = new GetChatUserQuery(userId);

            var user = await _queryDispatcher.DispatchAsync(getChatUserQuery);

            return View(user);
        }
    }
}
