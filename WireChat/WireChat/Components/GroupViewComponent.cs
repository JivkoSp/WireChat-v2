using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WireChat.Application.Queries;
using WireChat.Application.Queries.Dispatcher;

namespace WireChat.Components
{
    [Authorize]
    public class GroupViewComponent : ViewComponent
    {
        private readonly IQueryDispatcher _queryDispatcher;

        public GroupViewComponent(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid chatId)
        {
            var getGroupQuery = new GetGroupQuery(chatId);

            var group = await _queryDispatcher.DispatchAsync(getGroupQuery);

            return View(group);
        }
    }
}
