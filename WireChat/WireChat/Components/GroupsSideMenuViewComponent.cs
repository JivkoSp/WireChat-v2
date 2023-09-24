using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WireChat.Application.Queries;
using WireChat.Application.Queries.Dispatcher;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Components
{
    [Authorize]
    public class GroupsSideMenuViewComponent : ViewComponent
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly UserManager<UserReadModel> _userManager;

        public GroupsSideMenuViewComponent(IQueryDispatcher queryDispatcher, UserManager<UserReadModel> userManager)
        {
            _queryDispatcher = queryDispatcher;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var getGroupsQuery = new GetGroupsQuery(user.Id);

            var groups = await _queryDispatcher.DispatchAsync(getGroupsQuery);

            return View(groups);
        }
    }
}
